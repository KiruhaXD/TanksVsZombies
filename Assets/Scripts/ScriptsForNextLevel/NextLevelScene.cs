using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScene : MonoBehaviour
{
    [SerializeField] private CrystalsManager crystalsManager;

    [SerializeField] private TMP_Text levelText;
    //private TankPurchased tankPurchased;

    //private int currentLevel;

    /*private void Awake()
    {
        if (PlayerPrefs.HasKey("CurrentLevel")) 
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        else
            currentLevel = 0;
    }*/

    private void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            crystalsManager.SaveToProgress();

            Progress.Instance.playerInfo.level = SceneManager.GetActiveScene().buildIndex;

            Progress.Instance.Save();

            SceneManager.LoadScene(next);
            
        }

    }
}
