using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GateAppereance : MonoBehaviour
{
    [SerializeField] public TMP_Text textGate;

    [SerializeField] private Image topImage;
    [SerializeField] private Image downImage;

    public Color colorPositive;
    public Color colorNegative;

    public GameObject upgrade;
    public GameObject downgrade;

    public void UpdateVisual(int value)
    {
        string prefix = "";

        upgrade.SetActive(false);
        downgrade.SetActive(false);

        if (value > 0)
        {
            prefix = "+";
            SetColor(colorPositive);
            upgrade.SetActive(true);
        }

        else
        {
            SetColor(colorNegative);
            downgrade.SetActive(true);
        }

        textGate.text = prefix + value.ToString();
    }

    void SetColor(Color color) 
    {
        topImage.color = color;
        downImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }
}

