using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JumpGameUIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseMain;
    public GameObject settings;
    public GameObject gameOverUI;
    public GameObject simulationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton();
        pauseMenu.SetActive(false);
        if(PlayerPrefs.GetString("CreationStage") == "research")
        {
            simulationSpeed.SetActive(false);
        }
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
        if (GameController.Instance.gameState == GameController.GameState.WIN)
        {
            gameOverUI.GetComponentInChildren<TMP_Text>().text = "Complete!";
        }
        else if (GameController.Instance.gameState == GameController.GameState.LOSE)
        {
            gameOverUI.GetComponentInChildren<TMP_Text>().text = "Game Over";
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

    public void ReturnToMainMenu()
    {
        GameController.Instance.Resume();
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

}
