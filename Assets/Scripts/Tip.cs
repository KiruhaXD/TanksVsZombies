using RimuruDev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour
{
    [SerializeField] private List<GameObject> panelsTip;

    [SerializeField] private Canvas canvasCountCristals;
    [SerializeField] private Canvas canvasCharacteristics;

    [SerializeField] private GameObject panelCommon;

    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnClosePanel;

    [SerializeField] private GameObject scenePC;
    [SerializeField] private GameObject sceneMobile;

    [SerializeField] private DeviceTypeDetector detector;

    private int indexTip;

    private void Awake()
    {
        if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile || detector.CurrentDeviceType == CurrentDeviceType.WebPC) 
        {
            panelCommon.SetActive(true);
            btnClosePanel.gameObject.SetActive(false);

            if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile) 
            {
                sceneMobile.SetActive(true);
                scenePC.SetActive(false);
            }

            else
            {
                sceneMobile.SetActive(false);
                scenePC.SetActive(true);
            }
        }
    }

    private void Start()
    {
        /*if (IsMobileDevice() || !IsMobileDevice())
        {
            panelCommon.SetActive(true);
            btnClosePanel.gameObject.SetActive(false);

            if (IsMobileDevice())
            {
                sceneMobile.SetActive(true);
                scenePC.SetActive(false);
            }

            else
            {
                sceneMobile.SetActive(false);
                scenePC.SetActive(true);
            }
        }*/
    }

    public void NextDisplayTipManagment()
    {
        scenePC.SetActive(false);
        sceneMobile.SetActive(false);
        btnNext.gameObject.SetActive(true);
    }

    public void NextDisplayTip()
    {
        GameObject currentObject = panelsTip[indexTip];

        switch (currentObject.name)
        {
            case "Panel(CountCristals)":
                canvasCountCristals.sortingOrder = 6;
                break;

            case "Panel(Characteristics)":
                canvasCharacteristics.sortingOrder = 6;
                break;

            case "Panel(Gates)":
                btnNext.gameObject.SetActive(false);
                btnClosePanel.gameObject.SetActive(true);
                break;
        }

        panelsTip[indexTip++].SetActive(true);
    }

    public void ClosePanel() => panelCommon.SetActive(false);

    /*public bool IsMobileDevice()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            return true;

        return false;
    }*/
}



