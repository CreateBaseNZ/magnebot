using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController Instance { get { return _instance; } }
    private static GameController _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [DllImport("__Internal")]
    private static extern void GetGameState(string gameState);

    public GameState gameState = GameState.PLAY;

    public enum GameState
    {
        PLAY = 0,
        WIN = 1,
        LOSE = 2
    }

    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        FocusCanvas(PlayerPrefs.GetString("p_focus"));
        GetGameState("Play");
#endif
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void GameWin()
    {
        if (gameState == GameState.PLAY)
        {
            gameState = GameState.WIN;
#if !UNITY_EDITOR && UNITY_WEBGL
        GetGameState("Win");
#endif
        }
    }

    public void GameLose()
    {
        if (gameState == GameState.PLAY)
        {
            gameState = GameState.LOSE;
#if !UNITY_EDITOR && UNITY_WEBGL
            GetGameState("Lose");
#endif
        }
    }

    // This function will be called from the webpage
    public void FocusCanvas(string p_focus)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        if (p_focus == "0") {
            WebGLInput.captureAllKeyboardInput = false;
            PlayerPrefs.SetString("p_focus", "0");
        } else {
            WebGLInput.captureAllKeyboardInput = true;
            PlayerPrefs.SetString("p_focus", "1");
        }
#endif
    }
}
