using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGameUIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.gameState != GameController.GameState.PLAY)
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

}
