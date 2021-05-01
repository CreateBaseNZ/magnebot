using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameObject.FindObjectsOfType(typeof(Transform)).Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
