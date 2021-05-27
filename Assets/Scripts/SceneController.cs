using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get { return _instance; } }
    public string sceneName;

    private static SceneController _instance;
    private string _currentScene;
    private List<string> scenesInBuild = new List<string>();

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

    // Start is called before the first frame update
    void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
        scenesInBuild = scenesInBuild.Select(a => a.ToLower()).ToList();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadScene(string sceneName)
    {
        if (scenesInBuild.Contains(sceneName.ToLower())) 
        {
            if (sceneName.ToLower().Contains("training"))
            {
                SceneManager.LoadScene("Training_Base_0");
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
            _currentScene = sceneName;
        }
    }

    public void ResetScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
}
