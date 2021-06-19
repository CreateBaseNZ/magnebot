using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleSpawner : MonoBehaviour
{
    public bool varySize;
    public bool varyHeight;
    public bool varyBreakable;
    public float speed = 3f;
    public float acceleration = 5f;

    private ObjectPooler _objPool;
    private List<string> _poolKeys;
    private float _time;
    private float _cooldown;

    // Start is called before the first frame update
    void Start()
    {
        _objPool = GetComponent<ObjectPooler>();
        _poolKeys = new List<string>(new string[] { "Small" });
        _time = 0;
        _cooldown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        KeyCheck(varySize, "Large");
        KeyCheck(varyHeight, "Flying");
        KeyCheck(varyBreakable, "Breakable");

        _time += Time.deltaTime;
        speed += acceleration * Time.deltaTime;

        if (_time > _cooldown && GameController.Instance.gameState == GameController.GameState.PLAY)
        {
            var key = _poolKeys[Random.Range(0, _poolKeys.Count)];
            var height = key == "Flying" ? Random.Range(1, 4) * 0.833f : 0.6f;
            _objPool.SpawnFromPool(key, speed, height);
            _time = 0;
        }
    }

    private void KeyCheck(bool keyBoolean, string keyString)
    {
        if (keyBoolean && !_poolKeys.Contains(keyString))
        {
            _poolKeys.Add(keyString);
        }
        else if (!keyBoolean && _poolKeys.Contains(keyString))
        {
            _poolKeys.Remove(keyString);
        }
    }
}
