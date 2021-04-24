using UnityEngine;
using UnityEngine.UI;

public class RoboticArm : MonoBehaviour
{
    public float motorForce = 100f;

    private HingeJoint[] _hingeJoints;
    private float[] targetAngles;

    // Start is called before the first frame update
    void Start()
    {
        targetAngles = new float[4];
        var myJSON = "{\"Motor1\": 1, \"Motor2\": 23, \"Motor3\": 32, \"Motor4\": 72}";
        SetMotorAngle(myJSON);
        _hingeJoints = GetComponentsInChildren<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _hingeJoints.Length; i++)
        {
            var error = targetAngles[i] - _hingeJoints[i].angle;
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

    public void SetMotorAngle(string motorAngles)
    {
        MotorAngles output = JsonUtility.FromJson<MotorAngles>(motorAngles);
        targetAngles[0] = output.Motor1;
        targetAngles[1] = output.Motor2;
        targetAngles[2] = output.Motor3;
        targetAngles[3] = output.Motor4;
    }


    private class MotorAngles
    {
        public float Motor1;
        public float Motor2;
        public float Motor3;
        public float Motor4;
    }
}
