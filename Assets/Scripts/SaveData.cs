using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    [SerializeField] private GameObject panelCommon;

    // сохрнение уровней не работает!
    /*public void SaveScene()
    {
        if (CompareTag("Player") && CompareTag("Finish")) 
        {
            PlayerPrefs.SetInt("Level ", SceneManager.GetActiveScene().buildIndex + 1); // сохрнение уровней не работает!
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            if (SceneManager.GetActiveScene().buildIndex > 0) 
            {
                panelCommon.SetActive(false);
            }
        }
    }*/
}
