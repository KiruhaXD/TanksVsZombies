using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform tower;
    //[SerializeField] private float speedRotateTower = 50f;

    [SerializeField] private GameObject fireEffectPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPosition;

    public Transform firePoint;

    [SerializeField] private float fireForce = 10f;

    [SerializeField] private float delayBetweenShoots = 3.0f;
    public bool isReloading = false; // перезарядка орудия

    [SerializeField] private TMP_Text textReload;

    public void Shoot()
    {
        if (!isReloading)
        {
            if(Language.Instance.CurrentLanguage == "en")
                textReload.text = "Reloading...";

            else if(Language.Instance.CurrentLanguage == "ru")
                textReload.text = "Перезарядка...";

            else
                textReload.text = "Reloading...";

            StartCoroutine(SpawnEffectBullet(15f));

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            bulletRb.AddForce(bulletPosition.up * fireForce, ForceMode.Impulse);

            Destroy(bullet, 3f);

            isReloading = true;
            Invoke("FinishReloading", delayBetweenShoots);

            StartCoroutine(UpdateReloadUI(delayBetweenShoots));

        }
    }

    public void FinishReloading()
    {
        isReloading = false;
    }

    public IEnumerator UpdateReloadUI(float reloadTime) // создаем корутину для UI-элементов перезарядки
    {
        float timer = 0f;

        while (timer < reloadTime)
        {

            if (Language.Instance.CurrentLanguage == "en")
                textReload.text = "Reloading... " + (reloadTime - timer).ToString("0.0") + "s";

            else if (Language.Instance.CurrentLanguage == "ru")
                textReload.text = "Перезарядка... " + (reloadTime - timer).ToString("0.0") + "с";

            else
                textReload.text = "Reloading... " + (reloadTime - timer).ToString("0.0") + "s";

            yield return null;
            timer += Time.deltaTime;
        }

        if(Language.Instance.CurrentLanguage == "en")
            textReload.text = "You ready!";

        else if(Language.Instance.CurrentLanguage == "ru")
            textReload.text = "Ты готов!";

        else
            textReload.text = "You ready!";

    }

    public IEnumerator SpawnEffectBullet(float time)
    {
        GameObject fireEffect = Instantiate(fireEffectPrefab, firePoint.position, firePoint.rotation);
        Destroy(fireEffect, 2f);

        yield return new WaitForSeconds(time);
    }
}
