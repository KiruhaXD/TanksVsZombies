using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour // доделать выключение и включение звука!!!
{
    [SerializeField] private Sprite audioOn;
    [SerializeField] private Sprite audioOff;
    [SerializeField] private GameObject buttonAudio;

    [SerializeField] private Slider slider;
    [SerializeField] private RectTransform handleSlider;
    private static AudioController Instance;

    [SerializeField] private List<AudioSource> audioSources;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", slider.value);

        // Сохранять положение handle на всех сценах 
        //float savedHandlePosition = PlayerPrefs.GetFloat("HandlePosition", slider.value);

        //handleSlider.anchoredPosition = new Vector2(savedHandlePosition * slider.GetComponent<RectTransform>().sizeDelta.x, handleSlider.anchoredPosition.y);
    }

    public void SliderChangeValue()
    {
        foreach (AudioSource audio in audioSources) 
        {
            audio.volume = slider.value;
        }
    }

    public void OnOffAudio() 
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }

        else 
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }

    public void OnChangeValue() 
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("Volume", slider.value);
        //PlayerPrefs.SetFloat("HandlePosition", slider.value);

        PlayerPrefs.Save();
    }
}
