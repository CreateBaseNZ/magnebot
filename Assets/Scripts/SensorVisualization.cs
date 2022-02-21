using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SensorVisualization : MonoBehaviour
{
    public List<GameObject> sensorModels;
    public List<Renderer> renderers;
    public Material xrayMaterial;

    private List<Material[]> _materials = new List<Material[]>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var renderer in renderers)
        {
            _materials.Add(renderer.materials);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleVisualization(Toggle toggle)
    {
        if (toggle.isOn)
        {
            ToggleOn();
        }
        else
        {
            ToggleOff();
        }
    }

    private void ToggleOn()
    {
        foreach (var renderer in renderers)
        {
            Material[] temp = new Material[renderer.materials.Length];
            for (int i = 0; i < renderer.materials.Length; i++)
            {
                temp[i] = xrayMaterial;
            }
            renderer.materials = temp;
        }

        foreach (var sensorModel in sensorModels)
        {
            sensorModel.SetActive(true);
        }
    }

    private void ToggleOff()
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].materials = _materials[i];
        }

        foreach (var sensorModel in sensorModels)
        {
            sensorModel.SetActive(false);
        }
    }

}
