using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavascriptHook : MonoBehaviour
{
    public GameObject box;
    public KeyCode redKey;
    public KeyCode greenKey;


    public void TintRed()
    {
        box.GetComponent<Renderer>().material.color = Color.red;
    }

    public void TintGreen()
    {
        box.GetComponent<Renderer>().material.color = Color.green;
    }

    public void StartCountingToTen(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            InvokeRepeating("Count", 0, 1);
        }
    }

    public void Count(int number)
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
}
