using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    private Slider _slider;
    private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _slider = GetComponentInChildren<Slider>();

        _slider.value = PlayerPrefs.GetFloat("volume", 0.2f);
        SetVolume();
    }

    public void SetVolume()
    {
        _text.text = "Volume: " + (_slider.value * 100).ToString("0");
        AudioListener.volume = _slider.value;
        PlayerPrefs.SetFloat("volume", _slider.value);
    }
}
