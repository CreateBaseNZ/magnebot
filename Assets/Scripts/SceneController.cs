using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneController : MonoBehaviour
{
    #region Singleton
    public static SceneController Instance { get { return _instance; } }
    private static SceneController _instance;
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

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        var parseScene = sceneName.Split(',');
        var sceneToLoad = parseScene[0];
        if (parseScene.Length == 2)
        {
            PlayerPrefs.SetString("creationStage", parseScene[1].ToLower());
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}

