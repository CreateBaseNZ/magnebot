using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBreakScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJointBreak(float breakForce)
    {
        GameController.Instance.GameLose("An arm joint has broken");
    }

}
