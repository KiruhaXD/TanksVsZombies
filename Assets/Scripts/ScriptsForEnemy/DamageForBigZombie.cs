using UnityEngine;

public class DamageForBigZombie : MonoBehaviour
{
    [SerializeField] private GameObject effectForPunch;
    [SerializeField] private GameObject damagePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject punch = Instantiate(effectForPunch, new Vector3(transform.position.x, 1f, transform.position.z), transform.rotation);
            Destroy(punch, 1f);
        }
    }
}
