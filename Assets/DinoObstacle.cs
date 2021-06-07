using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoObstacle : MonoBehaviour
{
    public float speed = 3f;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        if (gameObject.transform.position.x < -15)
        {
            gameObject.transform.position = new Vector3(15, 0.8f, 0);
            gameObject.SetActive(false);
        }
        speed += acceleration * Time.deltaTime;
    }
}
