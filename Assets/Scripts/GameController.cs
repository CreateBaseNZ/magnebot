using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

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
    private GameState m_gameState;

    public delegate void OnGameStateChangeDelegate(GameState newState);
    public event OnGameStateChangeDelegate OnGameStateChange;
    public GameState gameState
    {
        get { return m_gameState; }
        set
        {
            if (m_gameState == value) return;
            m_gameState = value;
            if (OnGameStateChange != null)
                OnGameStateChange(m_gameState);
        }
    }

    public string stateDescription = "";

    // Start is called before the first frame update
    void Start()
    {
        Resume();
#if !UNITY_EDITOR && UNITY_WEBGL
        FocusCanvas(PlayerPrefs.GetString("p_focus"));
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;
        gameState = GameState.PAUSE;
#if !UNITY_EDITOR && UNITY_WEBGL
        GetGameState("Pause");
#endif
    }
    public void Resume()
    {
        Time.timeScale = PlayerPrefs.GetFloat("simulationSpeed", 1);
        gameState = GameState.PLAY;
#if !UNITY_EDITOR && UNITY_WEBGL
        GetGameState("Play");
#endif
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

    public void GameLose(string description)
    {
        if (gameState == GameState.PLAY)
        {
            stateDescription = description;
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
