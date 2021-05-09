using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTween : MonoBehaviour
{
    public Vector3 point;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.move(gameObject, transform.position + point, time).setEaseLinear().setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
