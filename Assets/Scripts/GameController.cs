using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GameController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetGameState(string gameState);

    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    private void Awake()
    {
        Application.targetFrameRate = 1000;
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
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
#if !UNITY_EDITOR && UNITY_WEBGL
        GetGameState("Win");
#endif
    }

    public void GameLose()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            GetGameState("Lose");
#endif
    }

    // This function will be called from the webpage
    public void FocusCanvas(string p_focus)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        if (p_focus == "0") {
            WebGLInput.captureAllKeyboardInput = false;
        } else {
            WebGLInput.captureAllKeyboardInput = true;
        }
#endif

    }


}
