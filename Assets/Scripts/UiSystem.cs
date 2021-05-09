using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSystem : MonoBehaviour
{
    public Text score;
    public ObjectiveGroup objectiveGroup;

    public Text fps;
    public GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateFps", 0f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateFps()
    {
        fps.text = (1f / Time.deltaTime).ToString("0");
    }
}