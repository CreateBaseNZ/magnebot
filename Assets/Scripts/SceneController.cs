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
        Application.targetFrameRate = 240;

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

    public string sceneName;
    public List<Animator> transitions;
    public float transitionTime = 1f;

    private string _currentScene;
    private List<string> scenesInBuild = new List<string>();

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

    public void ResetScene()
    {
        LoadScene(_currentScene);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadLevel(scenesInBuild[index]));
    }

    private IEnumerator LoadLevel(string sceneString)
    {
        //transitions.ForEach(f => f.SetTrigger("Start"));
        var parseScene = sceneString.Split(',');
        var sceneName = parseScene[0];
        if (parseScene.Length == 2)
        {
            PlayerPrefs.SetString("creationStage", parseScene[1].ToLower());
        }

        yield return new WaitForSeconds(transitionTime);

        if (scenesInBuild.Contains(sceneName.ToLower()))
        {
            if (sceneName.ToLower().Contains("training"))
            {
                SceneManager.LoadScene(sceneName);
                SceneManager.LoadScene("Training_Base_0", LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
            _currentScene = sceneName;
        }
    }



}
