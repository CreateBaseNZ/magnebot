using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalEnable : MonoBehaviour
{
    public string creationStage;
    public bool invert;

    // Start is called before the first frame update
    void Start()
    {
        if (!invert)
        {
            if (PlayerPrefs.GetString("creationStage") == creationStage)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (PlayerPrefs.GetString("creationStage") != creationStage)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
