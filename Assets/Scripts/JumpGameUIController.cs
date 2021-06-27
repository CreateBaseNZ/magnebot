using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameUIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseMain;
    public GameObject settings;
    public Slider volumeSlider;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton();
        pauseMenu.SetActive(false);
        SetGraphics(PlayerPrefs.GetString("quality"));
        SetVolume(PlayerPrefs.GetFloat("volume"));
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.gameState != GameController.GameState.PLAY)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        SceneController.Instance.ResetScene();
    }

    public void PauseButton()
    {
        GameController.Instance.Pause();
        pauseMenu.SetActive(true);
    }

    public void ResumeButton()
    {
        GameController.Instance.Resume();
        pauseMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneController.Instance.LoadScene("Project_Jump_0");
    }

    public void SettingsButton()
    {
        pauseMain.SetActive(false);
        settings.SetActive(true);
    }

    public void SettingsBackButton()
    {
        pauseMain.SetActive(true);
        settings.SetActive(false);
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
