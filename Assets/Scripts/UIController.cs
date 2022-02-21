using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseMain;
    public GameObject settings;
    public GameObject controls;
    public GameObject credits;
    public GameObject gameWinUI;
    public GameObject gameLoseUI;

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton();
        pauseMenu.SetActive(false);
        GameController.Instance.OnGameStateChange += OnGameOver;
    }

    public void OnGameOver(GameState newState)
    {
         if (newState == GameState.WIN)
        {
            gameWinUI.SetActive(true);
        }
        else if (newState == GameState.LOSE)
        {
            gameLoseUI.SetActive(true);
        }
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

    public void ControlsButton()
    {
        pauseMain.SetActive(false);
        controls.SetActive(true);
    }

    public void ControlsBackButton()
    {
        pauseMain.SetActive(true);
        controls.SetActive(false);
    }

    public void CreditsButton()
    {
        pauseMain.SetActive(false);
        credits.SetActive(true);
    }

    public void CreditsBackButton()
    {
        pauseMain.SetActive(true);
        credits.SetActive(false);
    }

}
