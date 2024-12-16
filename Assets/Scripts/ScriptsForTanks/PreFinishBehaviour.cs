using System.Collections.Generic;
using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private TankController controller;
    [SerializeField] private TankAudio tankAudio;
    [SerializeField] private List<EnemyController> enemyController;

    private void Update()
    {
        /*float x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime);

        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, Time.deltaTime * 1f);
        transform.localEulerAngles = new Vector3(0, rot, 0);*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (player != null) 
        {
            DisableComponents();

            other.GetComponent<TankController>().SetMovementState(false);

            if (tankAudio.tanksSoundPitch > 0.7f) 
            {
                tankAudio.tanksSoundPitch -= 0.1f * Time.deltaTime;

                if (tankAudio.tanksSoundPitch < 0.7f)
                {
                    //tankAudio.tanksAudio.Stop(); ÄÎÄÅËÀÒÜ ÎÒÊËÞ×ÅÍÈÅ ÇÂÓÊÀ!!!
                    //tankAudio.tanksSoundPitch = 0.7f;
                }    
            }

            foreach (EnemyController controller in enemyController) 
            {
                controller.ChangeDistance(EnemyState.run);
            }
        }
    }

    public void DisableComponents() 
    {
        controller.ver = 0f;

        controller.buttonOnTheLeft.enabled = false;
        controller.buttonOnTheRight.enabled = false;

        controller.textForReloadMovement.enabled = false;

    }



}
