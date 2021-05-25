using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public List<HingeJoint> hingeJoints;
    [Range(-180, 180)] public List<float> targets;
    public float gain = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        for (int i = 0; i < hingeJoints.Count; i++)
        {
            var error = targets[i] - hingeJoints[i].angle;
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
        }
    }


    private void OnEnable()
    {
        for (int i = 0; i < Mathf.Min(targets.Count, hingeJoints.Count); i++)
        {
            targets[i] = hingeJoints[i].angle;
        }
    }

}