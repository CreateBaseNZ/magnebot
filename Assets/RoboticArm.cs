using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoboticArm : MonoBehaviour
{
    public Slider[] sliders;
    public float motorForce = 100f;

    private HingeJoint[] _hingeJoints;


    // Start is called before the first frame update
    void Start()
    {
        _hingeJoints = GetComponentsInChildren<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _hingeJoints.Length; i++)
        {
            var error = sliders[i].value - _hingeJoints[i].angle;
            var absError = Mathf.Abs(error);

            var motorVelocity = 80;
            if (absError < 10)
            {
                motorVelocity = 40;
            }
            if (absError < 5)
            {
                motorVelocity = 15;
            }
            if (absError < 2)
            {
                motorVelocity = 5;
            }

            JointMotor motor = _hingeJoints[i].motor;
            motor.force = motorForce * (4-i);
            motor.targetVelocity = motorVelocity * Mathf.Sign(error);
            motor.freeSpin = false;
            _hingeJoints[i].motor = motor;
            _hingeJoints[i].useMotor = true;

            
        }

    }
}
