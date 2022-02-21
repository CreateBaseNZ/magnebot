using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoSettings : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start()
    {
        _dropdown = GetComponentInChildren<TMP_Dropdown>();
        _dropdown.value = PlayerPrefs.GetInt("quality");
        SetGraphics();
    }

    public void IncreaseQualityLevel()
    {
        QualitySettings.IncreaseLevel(true);
    }


    public void SetGraphics()
    {
        var qualityLevel = _dropdown.value;
        PlayerPrefs.SetInt("quality", qualityLevel);
        QualitySettings.SetQualityLevel(qualityLevel);
    }
}
