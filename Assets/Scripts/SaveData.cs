using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    [SerializeField] private GameObject panelCommon;

    // ��������� ������� �� ��������!
    /*public void SaveScene()
    {
        if (CompareTag("Player") && CompareTag("Finish")) 
        {
            PlayerPrefs.SetInt("Level ", SceneManager.GetActiveScene().buildIndex + 1); // ��������� ������� �� ��������!
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            if (SceneManager.GetActiveScene().buildIndex > 0) 
            {
                panelCommon.SetActive(false);
            }
        }
    }*/
}
