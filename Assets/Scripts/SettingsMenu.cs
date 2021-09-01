using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        SetGraphics(PlayerPrefs.GetString("quality"));
        SetVolume(PlayerPrefs.GetFloat("volume"));
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetVolume(Slider slider)
    {
        AudioListener.volume = slider.normalizedValue;
        PlayerPrefs.SetFloat("volume", slider.normalizedValue);
    }

    public void SetGraphics(string setting)
    {
        PlayerPrefs.SetString("quality", setting);
        switch (setting)
        {
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            case "Med":
                QualitySettings.SetQualityLevel(1);
                break;
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
            default:
                QualitySettings.SetQualityLevel(2);
                PlayerPrefs.SetString("quality", "High");
                break;
        }
    }
}
