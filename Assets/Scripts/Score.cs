using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TMP_Text _scoreText;
    private int _score;
    private int _highScore;
    private float _scoreMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _scoreText = GetComponent<TMP_Text>();
        _highScore = PlayerPrefs.GetInt("highScore");
        _scoreMultiplier = PlayerPrefs.GetFloat("scoreMultiplier");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.gameState == GameController.GameState.PLAY)
        {
            int distRemain = Mathf.Clamp((int)(1000 - Time.timeSinceLevelLoad * 20), 0, 1000);
            _scoreText.text = "Distance remaining: " + distRemain + "m";
            if (distRemain == 0)
            {
                GameController.Instance.GameWin();
            }
        }
        else
        {
            if (_highScore < _score)
            {
                PlayerPrefs.SetInt("highScore", _score);
            }
            enabled = false;
        }
    }
}
