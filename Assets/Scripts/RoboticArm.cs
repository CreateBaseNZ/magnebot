using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RoboticArm : MonoBehaviour
{
    public Vector3 target = Vector3.zero;
    public float motorForce = 100f;

    private HingeJoint[] _hingeJoints;
    private float[] targetAngles;

    void OnJointBreak(float breakForce)
    {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
    }

    // Start is called before the first frame update
    void Start()
    {
        targetAngles = new float[4];
        _hingeJoints = GetComponentsInChildren<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _hingeJoints.Length; i++)
        {
            if (_hingeJoints[i] != null)
            {
                var refAngles = targetAngles.Select(a => ((a + 180) % 360) - 180).ToArray();

                var error = refAngles[i] - _hingeJoints[i].angle;
                var absError = Mathf.Abs(error);
                var errorCheck = refAngles[i] - _hingeJoints[i].angle + 360;
                if (Mathf.Abs(errorCheck) < absError)
                {
                    error = errorCheck;
                    absError = Mathf.Abs(errorCheck);
                }
                errorCheck = refAngles[i] - _hingeJoints[i].angle - 360;
                if (Mathf.Abs(errorCheck) < absError)
                {
                    error = errorCheck;
                    absError = Mathf.Abs(errorCheck);
                }

                float motorVelocity = 80;
                if (absError < 10)
                {
                    motorVelocity = 40;
                }
                if (absError < 5)
                {
                    motorVelocity = 20;
                }
                if (absError < 2)
                {
                    motorVelocity = 10;
                }
                if (absError < 1)
                {
                    motorVelocity = 5;
                }

                JointMotor motor = _hingeJoints[i].motor;
                motor.force = motorForce * (4 - i);
                motor.targetVelocity = motorVelocity * Mathf.Sign(error);
                motor.freeSpin = false;
                _hingeJoints[i].motor = motor;
                _hingeJoints[i].useMotor = true;
            }
        }
    }

    public void SetMotorAngles(string motorAngles)
    {
        Motor4 output = JsonUtility.FromJson<Motor4>(motorAngles);
        target[0] = output.bottom;
        target[1] = output.shoulder;
        target[2] = output.elbow;
        target[3] = output.wrist;
    }

    struct Motor4
    {
        public float bottom;
        public float shoulder;
        public float elbow;
        public float wrist;
    }

}
