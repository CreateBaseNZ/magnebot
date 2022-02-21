using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    public int maxCounter;

    public GameObject checkmarkTick;
    public TMP_Text counter;


    private int _currentCounter;


    // Start is called before the first frame update
    void Start()
    {
        _currentCounter = 0;
        counter.text = _currentCounter + "/ " + maxCounter;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementObjectiveCounter()
    {
        _currentCounter = Mathf.Clamp(_currentCounter + 1, 0, maxCounter);
        counter.text = _currentCounter + "/" + maxCounter;
        if(_currentCounter == maxCounter)
        {
            checkmarkTick.SetActive(true);
            GameController.Instance.GameWin();
        }
    }

    public int GetScore()
    {
        return _currentCounter;
    }

}
