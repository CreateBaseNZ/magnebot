using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ObjectiveProgress : MonoBehaviour
{
    private TMP_Text _text;
    private string _description;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _description = _text.text.Substring(_text.text.IndexOf(' ') + 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(int currentProgress, int requiredProgress)
    {
        _text.text = currentProgress + "/" + requiredProgress + " " + _description;
        if(currentProgress == requiredProgress)
        {
            GetComponentsInChildren<TMP_Text>().ToList().ForEach(f => f.color = Color.grey);
        }
    }
}
