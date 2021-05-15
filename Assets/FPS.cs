using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FPS : MonoBehaviour
{
    private Text _fps;

    // Start is called before the first frame update
    void Start()
    {
        _fps = GetComponent<Text>();
        InvokeRepeating("UpdateFPS", 0, 0.2f);
    }

    private void UpdateFPS()
    {
        _fps.text = (1 / Time.deltaTime).ToString("0");

    }
}
