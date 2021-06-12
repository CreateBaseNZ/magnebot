using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoObstacle : MonoBehaviour
{
    private float _speed = 3f;
    private float _height = 0.8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(_speed, 0, 0) * Time.deltaTime;
        if (gameObject.transform.position.x < -15)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetHeight(float height)
    {
        _height = height;
    }

    private void OnEnable()
    {
        gameObject.transform.position = new Vector3(15, _height, 0);
    }
}
