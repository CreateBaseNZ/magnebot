using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalEnable : MonoBehaviour
{
    public string modifier;
    public bool setActive = true;

    // Start is called before the first frame update
    void Start()
    {
        if (modifier == PlayerPrefs.GetString("modifier"))
        {
            gameObject.SetActive(setActive);
        }
        else
        {
            gameObject.SetActive(!setActive);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
