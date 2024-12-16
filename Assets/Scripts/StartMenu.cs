using RimuruDev;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void GoWindowOnMobile()
    {
        SceneManager.LoadScene(Progress.Instance.playerInfo.level + 1);
        Debug.Log("Go");
    }

    public void GoWindowOnPK()
    {
        SceneManager.LoadScene(Progress.Instance.playerInfo.level + 1);
        Debug.Log("Go");
    }
}
