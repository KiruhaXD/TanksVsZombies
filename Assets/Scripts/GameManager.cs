using UnityEngine;
using RimuruDev;

public class GameManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject startMenuCanvas;
    [SerializeField] private GameObject choiseTanksCanvas;
    [SerializeField] private GameObject shopCanvas;

    [Header("Scripts")]
    [SerializeField] private Shop shop;
    [SerializeField] private MobileController mobileController;
    [SerializeField] private MobileControllerTower mobileTower;
    [SerializeField] private MobileControllerFire mobileFire;
    [SerializeField] private TankBehaviour tankBehaviour;

    /*[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] // данный атрибут позволяет вызвать сцену один раз и только при запуске игры
    private static void OnBeforeSceneLoadRuntimeMethod()
    {
        if (IsMobileDevice()) 
        {
            Debug.Log("Mobile");
            SceneManager.LoadScene("ManagementOnMobileAndPK");
        }

        else 
        {
            SceneManager.LoadScene("ManagementOnMobileAndPK");
            Debug.Log("PC");
        }
    }*/

    /*public static bool IsMobileDevice() 
    {
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            return true;

        return false;
    }*/

    public void Play() 
    {
        startMenuCanvas.SetActive(false);
        choiseTanksCanvas.SetActive(false);
        shopCanvas.SetActive(false);

        tankBehaviour.Play();
        shop.HidePanelCanvasAfterSuccessfulPurchase();

        EnabledJoysticks();
        //audioTankController.tanksAudio.Play();
        FindAnyObjectByType<TankAudio>().tanksAudio.Play();

        Progress.Instance.Save();

        /*TankAnimation tankAnimation = FindAnyObjectByType<TankAnimation>();
        tankAnimation.transform.position = Vector3.zero;*/
    }

    public void EnabledJoysticks()
    {
        mobileController.joystickBG.gameObject.SetActive(true);
        mobileController.joystick.gameObject.SetActive(true);

        mobileFire.buttonFireBG.gameObject.SetActive(true);
        mobileFire.buttonFire.gameObject.SetActive(true);

        mobileTower.joystickBGTower.gameObject.SetActive(true);
        mobileTower.joystickTower.gameObject.SetActive(true);
    }
}