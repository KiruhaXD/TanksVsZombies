using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20;
    [SerializeField] private float damageRadius = 5f;

    private Collider[] collidersEnemy;

    private bool hasExpoded = false;

    [SerializeField] private GameObject explosionEffectPrefab;

    private void Start()
    {
        collidersEnemy = GetComponents<Collider>();

        damageAmount = FindAnyObjectByType<TankModifier>().power;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyController enemyController = other.GetComponent<EnemyController>();
        if(!hasExpoded && enemyController != null) 
        {
            hasExpoded = true;
            SpawnEffectBullet();

            ApplySplashDamage();
            Destroy(gameObject);
        }

        else if (other.CompareTag("Wall")) 
        {
            damageRadius = 0;
            damageAmount = 0;
            SpawnEffectBullet();
        }

    }

    public void SpawnEffectBullet() 
    {
        GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(explosionEffect, 2f);
    }

    public void ApplySplashDamage() 
    {
        collidersEnemy = Physics.OverlapSphere(transform.position, damageRadius);

        foreach (Collider colliders in collidersEnemy) 
        {
            if (colliders.gameObject != gameObject) 
            {
                EnemyController enemyController = colliders.gameObject.GetComponent<EnemyController>();
                if (enemyController != null) 
                {
                    float distance = Vector3.Distance(transform.position, colliders.transform.position);
                    int damage = (int)Mathf.Lerp(0f, damageAmount, distance / damageRadius);
                    enemyController.TakeDamage(damage);
                }
            }
        }
    }
}
