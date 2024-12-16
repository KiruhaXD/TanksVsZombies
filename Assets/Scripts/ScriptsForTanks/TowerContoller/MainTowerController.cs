using UnityEngine.UI;
using UnityEngine;
using RimuruDev;

public class MainTowerController : MonoBehaviour
{
    [SerializeField] protected Transform tower;
    [SerializeField] protected float speedRotateTower = 50f;
    [SerializeField] protected bool isReloading = false; // перезарядка орудия

    [SerializeField] protected TowerBehaviour towerBehaviour;

    [SerializeField] protected Joystick joystickTowards;
    [SerializeField] protected Joystick joystickFire;

    [SerializeField] protected Image joystickTowardsBG;
    [SerializeField] protected Image joystickFireBG;

    //[SerializeField] protected DeviceType type;
    [SerializeField] protected DeviceTypeDetector detector;

    private void Awake()
    {
        /*if (IsMobileDevice())
        {
            joystickTowards.gameObject.SetActive(true);
            joystickFire.gameObject.SetActive(true);

            joystickTowardsBG.gameObject.SetActive(true);
            joystickFireBG.gameObject.SetActive(true);
        }

        else 
        {
            joystickTowards.gameObject.SetActive(false);
            joystickFire.gameObject.SetActive(false);

            joystickTowardsBG.gameObject.SetActive(false);
            joystickFireBG.gameObject.SetActive(false);
        }*/

        if (detector.CurrentDeviceType == CurrentDeviceType.WebPC)
        {
            joystickTowards.gameObject.SetActive(false);
            joystickFire.gameObject.SetActive(false);

            joystickTowardsBG.gameObject.SetActive(false);
            joystickFireBG.gameObject.SetActive(false);
        }

        else 
        {
            joystickTowards.gameObject.SetActive(true);
            joystickFire.gameObject.SetActive(true);

            joystickTowardsBG.gameObject.SetActive(true);
            joystickFireBG.gameObject.SetActive(true);
        }

    }

    /*public bool IsMobileDevice()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            return true;

        return false;
    }*/
}
