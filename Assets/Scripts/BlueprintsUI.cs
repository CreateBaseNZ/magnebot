using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintsUI : MonoBehaviour
{
    public List<Sensor> sensors;
    public List<TMP_Text> text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Mathf.Min(sensors.Count, text.Count); i++)
        {
            text[i].text = sensors[i].value.ToString("0.00");
        }
    }

    public void ToggleVisualization(Toggle toggle)
    {
        gameObject.SetActive(toggle.isOn);
    }
}
