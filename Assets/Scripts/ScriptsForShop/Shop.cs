using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public TankPurchased[] tanks;
    private bool[] stockCheck;

    public TMP_Text tankName;
    public TMP_Text priceText;
    [SerializeField] private TMP_Text crystalsText;
    [SerializeField] private Image countCrystals;
    [SerializeField] private Transform player;

    [SerializeField] private GameObject panelNotEnoughCrystals;
    [SerializeField] private List<GameObject> panelCharacteristicsUpdateTanks;

    public Button playButton;
    //public GameObject panelPriceTanks;
    [SerializeField] private UpdateTanks updateTanks;
    [SerializeField] private CrystalsManager crystalsManager;
    private float hideDelay = 0.3f; // Время задержки перед скрытием панели

    public Button buy;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    public int index;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        crystalsManager.numberOfCrystals = PlayerPrefs.GetInt("crystals");
        index = PlayerPrefs.GetInt("chosenTank");
        crystalsText.text = crystalsManager.numberOfCrystals.ToString();

        stockCheck = new bool[9];
        if (PlayerPrefs.HasKey("StockCheck")) 
        {
            stockCheck = PlayerPrefsX.GetBoolArray("StockCheck");
        }

        else
            stockCheck[0] = true;

        tanks[index].isTankSelected = true;

        for (int i = 0; i < tanks.Length; i++) 
        {
            tanks[i].isTankPurchased = stockCheck[i];
            if (i == index)
                player.GetChild(i).gameObject.SetActive(true);
            else
                player.GetChild(i).gameObject.SetActive(false);
        }

        TankChosen(priceText);

        buy.interactable = false;

        if (tanks[index].isTankPurchased && tanks[index].isTankSelected) 
            UpdateCharacteristics();
        
    }

    private void Update()
    {
        tankName.text = tanks[index].name;
    }

    public void Save() 
    {
        PlayerPrefsX.SetBoolArray("StockCheck", stockCheck);
    }

    public void BuyButtonAction()
    {
        if (buy.interactable && !tanks[index].isTankPurchased) 
        {
            if (crystalsManager.numberOfCrystals >= int.Parse(priceText.text))
            {
                crystalsManager.numberOfCrystals -= int.Parse(priceText.text);

                crystalsText.text = crystalsManager.numberOfCrystals.ToString();
                PlayerPrefs.SetInt("crystals", crystalsManager.numberOfCrystals);
                stockCheck[index] = true;
                tanks[index].isTankPurchased = true;
                TankChoose(priceText);
                countCrystals.gameObject.SetActive(false);
                Save();
 
                Progress.Instance.Save();

            }

            else
            {
                ShowPanelCanvasAfterUnsuccessfulPurchase();
                StartCoroutine(HidePanelAfterDelay());
                stockCheck[index] = false;
                tanks[index].isTankPurchased = false;
            }
        }

        if (buy.interactable && !tanks[index].isTankSelected && tanks[index].isTankPurchased) 
        {
            PlayerPrefs.SetInt("chosenTank", index);
            UpdateCharacteristics();
            ShowPlayButton();
            tanks[index].isTankSelected = true;
            buy.interactable = false;
            
            countCrystals.gameObject.SetActive(false);

            TankChosen(priceText);

            Progress.Instance.Save();

        }
    }

    public void ScrollRight() 
    {
        if (index < 8) 
        {
            index++;
            UpdateTankSelectionUI();
        } 
    }

    public void ScrollLeft() 
    {
        if (index > 0) 
        {
            index--;
            UpdateTankSelectionUI();
        }
    }

    public void ShowPlayButton() => playButton.enabled = true;
    public void HidePlayButton() => playButton.enabled = false;


    public void HidePanelCanvasAfterSuccessfulPurchase() 
    {
        panelNotEnoughCrystals.SetActive(false);

        foreach(GameObject panel in panelCharacteristicsUpdateTanks)
            panel.SetActive(false);
    }

    public void ShowPanelCanvasAfterUnsuccessfulPurchase()
    {
        panelNotEnoughCrystals.SetActive(true);

        foreach (GameObject panel in panelCharacteristicsUpdateTanks)
            panel.SetActive(true);
    }

    public IEnumerator HidePanelAfterDelay() 
    {
        yield return new WaitForSeconds(hideDelay);
        panelNotEnoughCrystals.SetActive(false);
    }

    public void UpdateCharacteristics() 
    {
        updateTanks.UpdateCharacteristicsTanksHealth();
        updateTanks.UpdateCharacteristicsTanksArmor();
        updateTanks.UpdateCharacteristicsTanksPower();
    }

    public void UpdateTankSelectionUI() 
    {
        if (tanks[0].isTankPurchased && tanks[index].isTankSelected)
            updateTanks.BaseCharacteristics();
                

        if (tanks[index].isTankPurchased && tanks[index].isTankSelected)
        {
            TankChosen(priceText);

            countCrystals.gameObject.SetActive(false);
            buy.interactable = false;
            ShowPlayButton();
            UpdateCharacteristics();

            Progress.Instance.Save();

        }

        else if (!tanks[index].isTankPurchased)
        {
            priceText.text = tanks[index].cost.ToString();
            buy.interactable = true;
            countCrystals.gameObject.SetActive(true);
            HidePlayButton();
            updateTanks.BaseCharacteristics();


            Progress.Instance.Save();

        }

        else if (tanks[index].isTankPurchased && !tanks[index].isTankSelected)
        {
            TankChoose(priceText);
            buy.interactable = true;
            countCrystals.gameObject.SetActive(false);
            HidePlayButton();
            updateTanks.BaseCharacteristics();

            Progress.Instance.Save();

        }

        for (int i = 0; i < player.childCount; i++)
            player.GetChild(i).gameObject.SetActive(false);

        player.GetChild(index).gameObject.SetActive(true);
    }

    public void TankChosen(TMP_Text text)
    {

        if (Language.Instance.CurrentLanguage == "en")
            text.text = "CHOSEN";

        else if (Language.Instance.CurrentLanguage == "ru")
            text.text = "ВЫБРАН";

        else
            text.text = "CHOSEN";

    }

    public void TankChoose(TMP_Text text)
    {

        if (Language.Instance.CurrentLanguage == "en")
            text.text = "CHOOSE";

        else if (Language.Instance.CurrentLanguage == "ru")
            text.text = "ВЫБРАТЬ";

        else
            text.text = "CHOOSE";

    }


}

[System.Serializable]
public class TankPurchased
{
    public bool isTankPurchased;
    public bool isTankSelected;
    //public int currentTankIndex;

    public int cost;
    public string name;

    public int health;
    public int armor;
    public int power;
}


