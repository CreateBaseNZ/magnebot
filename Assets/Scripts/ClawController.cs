using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public bool closeClaw;
    public float angle;
    public HingeJoint leftClaw;
    public HingeJoint rightClaw;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var angle = closeClaw ? -5 : 70;
        leftClaw.motor = CreateMotor(angle, leftClaw.angle);
        leftClaw.useMotor = true;

        rightClaw.motor = CreateMotor(angle * -1, rightClaw.angle);
        rightClaw.useMotor = true;
    }

    private JointMotor CreateMotor(float targetAngle, float currentAngle)
    {
        var error = targetAngle - currentAngle;
        var newMotor = new JointMotor();
        var vel = error * 4;
        newMotor.targetVelocity = vel;
        newMotor.force = Mathf.Infinity;

        return newMotor;
    }
}
