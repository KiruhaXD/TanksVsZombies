using UnityEngine;

public class GateHealthMultiplication : MonoBehaviour
{
    [SerializeField] private int healthValue;
    [SerializeField] private GateAppereanceMultiplication appereanceMultiplication;
    [SerializeField] private GameObject updateEffect;
    [SerializeField] private Transform player;
    [SerializeField] private TankModifier modifier;

    private void OnValidate()
    {
        appereanceMultiplication.UpdateVisual(healthValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        modifier = other.attachedArticulationBody.GetComponent<TankModifier>();
        if (modifier != null)
        {
            if (appereanceMultiplication.upgrade)
                modifier.MultiplicationHealth(healthValue);

            modifier.Died();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(updateEffect, player.transform.position, Quaternion.identity);
            Destroy(effect, 2.5f);
        }
    }
}
