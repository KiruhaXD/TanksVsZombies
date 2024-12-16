using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateAppereanceMultiplication : MonoBehaviour
{
    public TMP_Text textGate;

    public Image topImage;
    public Image downImage;

    public Color colorMultiplicate;

    public GameObject upgrade;

    public void UpdateVisual(int value) 
    {
        string prefix = "";

        upgrade.SetActive(false);

        if (value > 0)
        {
            prefix = "x";
            SetColor(colorMultiplicate);
            upgrade.SetActive(true);
        }

        else 
            value = 0;

        textGate.text = prefix + value.ToString();
    }

    public void SetColor(Color color) 
    {
        topImage.color = color;
        downImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }

}
