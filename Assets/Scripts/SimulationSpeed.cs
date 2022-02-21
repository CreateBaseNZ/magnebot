using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationSpeed : MonoBehaviour
{
    private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponentInChildren<Slider>();

        _slider.value = PlayerPrefs.GetFloat("simulationSpeed", 1);
        SetSimulationSpeed();
    }

    public void SetSimulationSpeed()
    {
        Time.timeScale = _slider.value;
        PlayerPrefs.SetFloat("simulationSpeed", _slider.value);
    }
}
