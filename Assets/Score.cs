using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.gameState == GameController.GameState.PLAY)
        {
            score.text = (Time.time * 10).ToString("00000");
        }
    }
}
