using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Resume();
        }
    }

    public void Pause()
    {
        Debug.Log("Pausing Game");
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Debug.Log("Resuming Game");
        Time.timeScale = 1;
    }

}
