using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileControllerFire : MonoBehaviour
{
    [Header("Fire")]
    public Image buttonFireBG;
    public Image buttonFire;

    private void Start()
    {
        buttonFireBG.gameObject.SetActive(false);
        buttonFire.gameObject.SetActive(false);
    }
}
