using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get { return _instance; } }

    private static SceneController _instance;
    private uint _currentSubsceneIndex = 0;
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
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            LoadSubscene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            LoadSubscene(2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            LoadSubscene(3);
        }
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName.ToLower().Contains("project") && !sceneName.ToLower().Contains("sub"))
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene must be a main Project scene");
        }
    }

    public void LoadSubscene(uint subsceneIndex)
    {
        var sceneName = SceneManager.GetActiveScene().name + "Sub" + subsceneIndex;
        if (SceneManager.GetActiveScene().name.Contains("Project") && (scenesInBuild.Contains(sceneName)))
        {
            if (_currentSubsceneIndex > 0)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name + "Sub" + _currentSubsceneIndex);
            }
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            _currentSubsceneIndex = subsceneIndex;
        }
    }
}
