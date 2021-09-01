using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    public List<GameObject> grounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var ground in grounds)
        {
            ground.transform.position -= new Vector3(10, 0, 0) * Time.deltaTime;
            if(ground.transform.position.x < -30)
            {
                ground.transform.position += new Vector3(60, 0, 0);
            }
        }  
    }
}
