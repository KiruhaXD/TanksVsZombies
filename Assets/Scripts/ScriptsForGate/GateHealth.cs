using Unity.VisualScripting;
using UnityEngine;

public class GateHealth : MonoBehaviour
{
    public MoveReloading canMove;

    [SerializeField] private int healthValue;
    [SerializeField] private GateAppereance gateAppereance;
    [SerializeField] private GameObject updatingEffect;
    [SerializeField] private Transform player;
    [SerializeField] private TankModifier tankModifier;
    [SerializeField] private TankController controller;

    private void OnValidate()
    {
        gateAppereance.UpdateVisual(healthValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        tankModifier = other.attachedRigidbody.GetComponent<TankModifier>();
        if (tankModifier != null) 
        {
            if (gateAppereance.upgrade)
            {
                tankModifier.AddHealth(healthValue);
            }

            else if (gateAppereance.downgrade) 
            {
                tankModifier.RemoveHealth(healthValue);                
            }

            tankModifier.Died();
        }

        if (other.gameObject.tag == "Player") 
        {
            canMove.CantMove(controller.textForReloadMovement);

            controller.canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove.CanMove(controller.textForReloadMovement);

            controller.canMove = true;

            Destroy(gameObject);
            GameObject effect = Instantiate(updatingEffect, player.transform.position, Quaternion.identity);
            Destroy(effect, 2.5f);
        }
    }
}
