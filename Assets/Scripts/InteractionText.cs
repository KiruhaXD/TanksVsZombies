using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionText : MonoBehaviour
{
    [SerializeField] string en;
    [SerializeField] string ru;

    private void Start()
    {
        switch (Language.Instance.CurrentLanguage) 
        {
            case "en":
                GetComponent<TMP_Text>().text = en;
                break;

            case "ru":
                GetComponent<TMP_Text>().text = ru;
                break;

            default:
                GetComponent<TMP_Text>().text = en;
                break;
        }
    }
}
