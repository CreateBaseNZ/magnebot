using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class SensorDataUI : MonoBehaviour
{
    [System.Serializable]
    public struct SensorUI
    {
        public string name;
        public Sensor sensor;
        public Color zeroColor;
        public Color oneColor;
    }

    public List<SensorUI> sensors;
    public GameObject template;

    private List<GameObject> _gameObject = new List<GameObject>();
    private List<Slider> _slider = new List<Slider>();
    private List<Image> _fill = new List<Image>();
    private List<TMP_Text> _text = new List<TMP_Text>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sensors.Count; i++)
        {
            var obj = Instantiate(template, transform);
            _gameObject.Add(obj);
            _slider.Add(obj.GetComponentInChildren<Slider>());
            _slider[i].minValue = sensors[i].sensor.minValue;
            _slider[i].maxValue = sensors[i].sensor.maxValue;
            _fill.Add(obj.GetComponentInChildren<Image>());
            _text.Add(obj.GetComponentsInChildren<TMP_Text>().Last());
            obj.GetComponent<TMP_Text>().text = sensors[i].name.ToUpper();
            obj.transform.SetSiblingIndex(i + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sensors.Count; i++)
        {
            var sensorValue = sensors[i].sensor.value;
            var color = (sensors[i].oneColor - sensors[i].zeroColor) * sensors[i].sensor.valuePercentage + sensors[i].zeroColor;
            _fill[i].color = color;
            _slider[i].value = sensorValue;
            _text[i].text = sensorValue.ToString("0.00");
            _text[i].color = color;
        }
    }

    public void ToggleVisualization(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Hide()
    {
        _gameObject.ForEach(f => f.SetActive(false));
    }

    private void Show()
    {
        _gameObject.ForEach(f => f.SetActive(true));
    }
}
