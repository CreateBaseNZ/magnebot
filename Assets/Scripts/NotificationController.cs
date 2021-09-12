using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    #region Singleton
    public static NotificationController Instance { get { return _instance; } }
    private static NotificationController _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    private LeanPulse _leanPulse;
    private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _leanPulse = GetComponent<LeanPulse>();
        _text = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Notify(string message)
    {
        _text.text = message;
        _leanPulse.Pulse();
    }

}
