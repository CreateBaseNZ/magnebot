using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(-Screen.width/2 + 75, Screen.height/2 - 75, 0);
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    }
}
