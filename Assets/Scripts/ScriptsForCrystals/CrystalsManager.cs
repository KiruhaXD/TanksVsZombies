using TMPro;
using UnityEngine;

public class CrystalsManager : MonoBehaviour
{
    public int numberOfCrystals;
    [SerializeField] private TMP_Text countCrystals;

    private void Awake()
    {
        numberOfCrystals = Progress.Instance.playerInfo.crystals;
        UpdateUI();

        //PlayerPrefs.DeleteAll();
        //numberOfCrystals = PlayerPrefs.GetInt("crystals");
    }

    public void AddOne()
    {
        numberOfCrystals++;
        //SaveCrystals();
        UpdateUI();
    }

    public void SaveCrystals() 
    {
        PlayerPrefs.SetInt("crystals", numberOfCrystals);
        PlayerPrefs.Save();
    }

    public void SaveToProgress() 
    {
        Progress.Instance.playerInfo.crystals = numberOfCrystals;
        UpdateUI();

    }

    public void UpdateUI() => countCrystals.text = numberOfCrystals.ToString();
}
