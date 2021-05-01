using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RoboticArm : MonoBehaviour
{
    public Vector3 target = Vector3.zero;
    public float motorForce = 100f;

    private HingeJoint[] _hingeJoints;
    private GameObject _base;
    private float[] targetAngles;
    private float L, M, N, h;

    // Start is called before the first frame update
    void Start()
    {
        targetAngles = new float[4];
        //var myJSON = "{\"x\": 0, \"y\": 1.25, \"z\": 0.5}";
        //SetMotorAngle(myJSON);
        _hingeJoints = GetComponentsInChildren<HingeJoint>();
        _base = GetComponentInChildren<Rigidbody>().gameObject;
        h = (_base.transform.position - _hingeJoints[0].transform.TransformPoint(_hingeJoints[0].connectedAnchor)).magnitude;
        L = (_hingeJoints[2].transform.TransformPoint(_hingeJoints[2].connectedAnchor) - _hingeJoints[1].transform.TransformPoint(_hingeJoints[1].anchor)).magnitude;
        M = (_hingeJoints[3].transform.TransformPoint(_hingeJoints[3].anchor) - _hingeJoints[2].transform.TransformPoint(_hingeJoints[2].anchor)).magnitude;
        N = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAngles();
        for (int i = 0; i < _hingeJoints.Length; i++)
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

    public void CalculateAngles()
    {
        var t = target;
        var R = Mathf.Sqrt(Mathf.Pow(t.x, 2) + Mathf.Pow(t.z, 2));
        var s = R - N;

        var Q = Mathf.Sqrt(Mathf.Pow(s, 2) + Mathf.Pow(t.y + h, 2));
        var f = Mathf.Atan2(t.y + h, s);
        var g = Mathf.Acos((Mathf.Pow(L, 2) + Mathf.Pow(Q, 2) - Mathf.Pow(M, 2)) / (2 * L * Q));

        var a = f + g;
        var b = Mathf.Acos((Mathf.Pow(M, 2) + Mathf.Pow(L, 2) - Mathf.Pow(Q, 2)) / (2 * L * M));
        var c = -b - a + 2 * Mathf.PI;
        var d = Mathf.Atan2(t.x, t.z);

        targetAngles[0] = Mathf.Rad2Deg * d + 180;
        targetAngles[1] = Mathf.Rad2Deg * a - 90;
        targetAngles[2] = Mathf.Rad2Deg * b - 180;
        targetAngles[3] = Mathf.Rad2Deg * c - 180;
    }

    public void MoveXYZ(string motorAngles)
    {
        Vector3 output = JsonUtility.FromJson<Vector3>(motorAngles);
        target = output;
    }

}
