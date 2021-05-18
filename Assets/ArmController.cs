using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public List<HingeJoint> hingeJoints;
    [Range(-90,90)]public List<float> target;
    public float gain = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        for (int i = 0; i < hingeJoints.Count; i++)
        {
            var error = target[i] - hingeJoints[i].angle;
            Debug.Log("Motor " + i + ": target: " + hingeJoints[i].angle);
            var newMotor = new JointMotor();
            var vel = error * gain;
            if (error < 10)
            {
                vel *= 0.8f;
            }
            else if (error < 5)
            {
                vel *= 0.4f;
            }
            else if (error < 2)
            {
                vel *= 0.2f;
            }
            newMotor.targetVelocity = vel;


            newMotor.force = Mathf.Infinity;

            hingeJoints[i].motor = newMotor;
            hingeJoints[i].useMotor = true;
            //Debug.Log("Motor " + i + "error: " + error);
        }
    }
}
