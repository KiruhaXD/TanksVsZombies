using UnityEngine;

public class WallBarrier : MonoBehaviour
{
    [SerializeField] private GameObject stoneEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        EnemyController enemyController = other.attachedRigidbody.GetComponent<EnemyController>();
        if (enemyController != null) 
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(stoneEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 6f);
        }
    }
}
