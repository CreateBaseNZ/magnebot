using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private List<GameObject> _objPool;
    private float time;
    private int index;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        index = 0;
        cooldown = 3;
        _objPool = new List<GameObject>();

        for (int i = 0; i < 4; i++)
        {
            _objPool.Add(Instantiate(obstaclePrefab));
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > cooldown && GameController.Instance.gameState == GameController.GameState.PLAY)
        {
            index = (index + 1) % 4;
            time = 0;
            _objPool[index].SetActive(true);
            cooldown = Random.Range(1.5f, 3f);
        }
    }
}
