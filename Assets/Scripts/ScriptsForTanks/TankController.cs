using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using RimuruDev;


public class TankController : MonoBehaviour
{
    public MoveReloading iCanMove;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 3f;

    [Header("Mobile Input")]
    public Button buttonOnTheLeft;
    public Button buttonOnTheRight;

    [SerializeField] private TankAudio tankAudio;
    [SerializeField] private List<TextureMoveForTracks> textureMoveForTracks;
    [SerializeField] private GameObject effectPrefabTeleport;

    private Transform localTrans;

    public float ver = 1f;

    private float timeForeMove = 2f;
    private bool isMoveX = false;
    public TMP_Text textForReloadMovement;

    public bool canMove = true;

    [SerializeField] private DeviceTypeDetector detector;

    private void Start()
    {
        localTrans = GetComponent<Transform>();

        buttonOnTheLeft.gameObject.SetActive(false);
        buttonOnTheRight.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile)
        {
            buttonOnTheLeft.gameObject.SetActive(true);
            buttonOnTheRight.gameObject.SetActive(true);
        }

        /*if (IsMobileDevice()) 
        {
            buttonOnTheLeft.gameObject.SetActive(true);
            buttonOnTheRight.gameObject.SetActive(true);
        }*/

        if (canMove)
            Move();

        if (ver > 0) // т.к направление вперед  это +1, а направление назад это -1 
        {
            Vector3 moveVertical = new Vector3(0f, 0f, ver);
            transform.Translate(moveVertical * moveSpeed * Time.deltaTime);
        }

        if (ver > 0)
        {
            foreach (TextureMoveForTracks texture in textureMoveForTracks)
            {
                var currentOffset = Time.time * texture.moveTrackSpeedOffset;
                texture.rendTrackLeft.material.mainTextureOffset = new Vector2(0f, currentOffset);
                texture.rendTrackRight.material.mainTextureOffset = new Vector2(0f, currentOffset);
            }

        }

        tankAudio.DinamicMove(ver);
    }

    /*public bool IsMobileDevice()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            return true;

        return false;
    }*/

    private void OnEnable()
    {
        buttonOnTheLeft.onClick.AddListener(() => MoveMobile(buttonOnTheLeft));
        buttonOnTheRight.onClick.AddListener(() => MoveMobile(buttonOnTheRight));
    }

    public void Move()
    {
        if (detector.CurrentDeviceType == CurrentDeviceType.WebPC /*!IsMobileDevice()*/) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MovementOnTheLeft();
            }

            else if (Input.GetKeyDown(KeyCode.D)) 
            {
                MovementOnTheRight();
            }
        }
    }

    public void MoveMobile(Button buttonPressed) 
    {
        if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile /*IsMobileDevice()*/)
        {
            if (buttonPressed == buttonOnTheLeft)
            {
                MovementOnTheLeft();
            }

            else if (buttonPressed == buttonOnTheRight)
            {
                MovementOnTheRight();
            }
        }
    }

    private void OnDisable()
    {
        buttonOnTheLeft.onClick.RemoveAllListeners();
        buttonOnTheRight.onClick.RemoveAllListeners();
    }

    public void FinishingReloadMove() => isMoveX = false;

    public void MovementOnTheLeft() 
    {
        if (!isMoveX)
        {
            isMoveX = true;
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
            Invoke("FinishingReloadMove", timeForeMove);

            GameObject teleportEffect = Instantiate(effectPrefabTeleport, new Vector3(transform.position.x, 2f, transform.position.z), transform.rotation);
            Destroy(teleportEffect, 1f);

            StartCoroutine(MovementTime(timeForeMove));

        }
    }

    public void MovementOnTheRight() 
    {
        if (!isMoveX)
        {
            isMoveX = true;
            transform.position = new Vector3(2f, transform.position.y, transform.position.z);
            Invoke("FinishingReloadMove", timeForeMove);

            GameObject teleportEffect = Instantiate(effectPrefabTeleport, new Vector3(transform.position.x, 2f, transform.position.z), transform.rotation);
            Destroy(teleportEffect, 1f);

            StartCoroutine(MovementTime(timeForeMove));

        }
    }

    public void SetMovementState(bool state) => canMove = state;

    public IEnumerator MovementTime(float reloadTime) 
    {
        float timer = 0f;

        while (timer < reloadTime) 
        {
            if (Language.Instance.CurrentLanguage == "en")    
                textForReloadMovement.text = "Reloading... " + (reloadTime - timer).ToString("0.0") + "s";

            else if (Language.Instance.CurrentLanguage == "ru")
                textForReloadMovement.text = "Перезарядка... " + (reloadTime - timer).ToString("0.0") + "с";

            else
                textForReloadMovement.text = "Reloading... " + (reloadTime - timer).ToString("0.0") + "s";

            yield return null;
            timer += Time.deltaTime;
        }

        iCanMove.CanMove(textForReloadMovement);

    }
}
