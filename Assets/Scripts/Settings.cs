using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        CurrentActivity();
    }

    public void PauseButton() 
    {
        Time.timeScale = 0f; // ставим игру на паузу при нажтии на кнопку настроек
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        settingsPanel.gameObject.SetActive(true);
    }

    public void PlayButton() 
    {
        Time.timeScale = 1f;
        CurrentActivity();
    }

    public void CurrentActivity() 
    {
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
    }
}
