using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConditionalButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool onImproveStage = PlayerPrefs.GetString("CreationStage") == "improve";
        var tmp_text = GetComponentInChildren<TMP_Text>();
        if (onImproveStage)
        {
            GetComponent<Button>().interactable = true;
            tmp_text.text = "Modifiers";
            tmp_text.fontSize = 26;
            tmp_text.color = new Color(0.8f, 0.8f, 0.8f);
            tmp_text.fontStyle = FontStyles.Bold;
        }
        else
        {
            GetComponent<Button>().interactable = false;
            tmp_text.text = "Requires Improve\nstage";
            tmp_text.fontSize = 16;
            tmp_text.color = new Color(0.5f, 0, 0); ;
            tmp_text.fontStyle = FontStyles.Normal;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
