using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        var parseScene = sceneName.Split(',');
        var sceneToLoad = parseScene[0];

        if (parseScene.Length >= 2)
        {
            PlayerPrefs.SetString("modifier", parseScene[1].ToLower());
            if(parseScene[1] == "manual")
            {
                GameController.Instance.FocusCanvas("1");
            }
        }
        else
        {
            PlayerPrefs.SetString("modifier", "");
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
