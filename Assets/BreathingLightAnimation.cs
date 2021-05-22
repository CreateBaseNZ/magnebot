using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingLightAnimation : MonoBehaviour
{
    public Material mat;
    public float frequency = 1f;
    public float amplitude = 1f;
    public float offset = 0.5f;

    private Color _startColor;
    private float _intensity;

    // Start is called before the first frame update
    void Start()
    {
        _startColor = mat.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        _intensity = (Mathf.Sin(Time.time * frequency) * amplitude) + offset;


        mat.SetColor("_EmissionColor", new Color(_startColor.r, _startColor.g, _startColor.b, _intensity));
    }
}
