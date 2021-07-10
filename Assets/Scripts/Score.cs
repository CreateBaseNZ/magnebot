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
            _score = (int)(Time.timeSinceLevelLoad * _scoreMultiplier);
            _scoreText.text = "HI " + _highScore.ToString("00000") + " " + _score.ToString("00000");
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
