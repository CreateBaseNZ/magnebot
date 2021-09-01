using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceRemaining : MonoBehaviour
{
    private TMP_Text _distanceRemaining;
    // Start is called before the first frame update
    void Start()
    {
        _distanceRemaining = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.gameState == GameController.GameState.PLAY)
        {
            int distRemain = Mathf.Clamp((int)(1000 - Time.timeSinceLevelLoad * 20), 0, 1000);
            _distanceRemaining.text = "Distance remaining: " + distRemain + "m";
            if (distRemain == 0)
            {
                GameController.Instance.GameWin();
            }
        }
    }
}
