using UnityEngine;

public class GateHealthDivision : MonoBehaviour
{
    [SerializeField] private int healthValue;
    [SerializeField] private GateAppereanceDivision appereanceDivision;
    [SerializeField] private GameObject updateEffect;
    [SerializeField] private Transform player;
    [SerializeField] private TankModifier modifier;

    private void OnValidate()
    {
        appereanceDivision.UpdateVisual(healthValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        modifier = other.attachedArticulationBody.GetComponent<TankModifier>();
        if (modifier != null) 
        {
            if (appereanceDivision.downgrade)
                modifier.DivisionHealth(healthValue);

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
