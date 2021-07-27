using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text score;

    private void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (GameController.Instance.gameState != GameController.GameState.PLAY)
        {
            var playerScore = 0;
            if (PlayerPrefs.GetString("CreationStage") == "research")
            {
                playerScore = (int)(Time.timeSinceLevelLoad * 2.55f);
            }
            else if (PlayerPrefs.GetString("CreationStage") == "create")
            {
                playerScore = (int)Time.timeSinceLevelLoad;
            }
            else if(PlayerPrefs.GetString("CreationStage") == "improve")
            {
                playerScore = (int)(Time.time * PlayerPrefs.GetFloat("scoreMultiplier"));
            }
            score.text = playerScore.ToString();
            enabled = false;
        }
    }
}
