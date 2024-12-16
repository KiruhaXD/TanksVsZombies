using UnityEngine;

public class Crystals : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private GameObject crystalEffect;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            FindAnyObjectByType<CrystalsManager>().AddOne();
            Destroy(gameObject);
            GameObject effect = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
