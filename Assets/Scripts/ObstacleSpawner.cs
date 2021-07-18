using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleSpawner : MonoBehaviour
{
    public float speed = 15f;
    public float acceleration = 5f;

    private float _time;
    private float _cooldown;
    private List<string> _keys = new List<string>() {"Small"};

    // Start is called before the first frame update
    void Start()
    {
        _time = 0;
        _cooldown = 2;

        switch (PlayerPrefs.GetString("CreationStage"))
        {
            case "research":
                acceleration = 0.4f;
                _keys.Add("Flying");
                _keys.Add("Large");
                break;
            case "create":
                acceleration = 0;
                break;
            case "improve":
                if (PlayerPrefs.GetInt("Acceleration") == 0)
                {
                    acceleration = 0;
                }
                if (PlayerPrefs.GetInt("Flying", 0) == 1)
                {
                    _keys.Add("Flying");
                }
                if (PlayerPrefs.GetInt("Large", 0) == 1)
                {
                    _keys.Add("Large");
                }
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        speed += acceleration * Time.deltaTime;

        if (_time > _cooldown && GameController.Instance.gameState == GameController.GameState.PLAY)
        {
            var key = _keys[Random.Range(0, _keys.Count)];
            Vector3 pos = new Vector3(15, 0, 0);
            GameObject spawnedObj = null;
            if (key == "Flying")
            {
                pos = new Vector3(15, Random.Range(1, 4) * 0.9f, 0);
                spawnedObj = Pool.Instance.Activate(key, pos, true);
            }
            else
            {
                spawnedObj = Pool.Instance.Activate(key, pos);
            }
            spawnedObj.GetComponent<DinoObstacle>().SetSpeed(speed);
            _cooldown = Random.Range(0.5f, 1.5f);
            _time = 0;
        }
    }
}
