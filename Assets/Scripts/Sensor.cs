using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public float valuePercentage;
    public float minValue = 0;
    public float maxValue = 1;
    public float value
    {
        get { return _value; }
        set
        {
            _value = Mathf.Clamp(value, minValue, maxValue);
            valuePercentage = (_value - minValue) / (maxValue - minValue);
        }
    }

    private float _value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected float Map(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
