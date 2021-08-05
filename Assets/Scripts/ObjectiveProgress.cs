using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ObjectiveProgress : MonoBehaviour
{
    private TMP_Text _text;
    private string _description;
    private bool _complete;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _description = _text.text.Substring(_text.text.IndexOf(' ') + 1);
        _complete = false;
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
        if (currentProgress == requiredProgress)
        {
            CompleteObjective();
        }
    }

    public void CompleteObjective()
    {
        if (!_complete)
        {
            _text.text = "<s>" + _text.text + "</s>";
            GetComponentsInChildren<TMP_Text>().ToList().ForEach(f => f.color = Color.grey);
            _complete = true;
            enabled = false;
        }
    }
}
