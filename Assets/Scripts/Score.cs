using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    private void OnEnable()
    {
        if (GameController.Instance.gameState == GameState.WIN)
        {
            var t = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
            GetComponent<TMP_Text>().text = $"{t.Minutes.ToString("00")}<size=50%>M</size>{t.Seconds.ToString("00")}<size=50%>S</size>";
        }
        else if (GameController.Instance.gameState == GameState.LOSE)
        {
            GetComponent<TMP_Text>().text = GameController.Instance.stateDescription;
        }
    }
}
