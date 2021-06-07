using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public GameObject _base;
    public List<HingeJoint> hingeJoints;
    public Vector3 ikTarget;
    [Range(-180, 180)] public List<float> targets;
    public float gain = 1f;

    private float L, M, N, h;

    // Start is called before the first frame update
    void Start()
    {
        h = (_base.transform.position - hingeJoints[0].transform.TransformPoint(hingeJoints[0].connectedAnchor)).magnitude;
        L = (hingeJoints[2].transform.TransformPoint(hingeJoints[2].connectedAnchor) - hingeJoints[1].transform.TransformPoint(hingeJoints[1].anchor)).magnitude;
        M = (hingeJoints[3].transform.TransformPoint(hingeJoints[3].anchor) - hingeJoints[2].transform.TransformPoint(hingeJoints[2].anchor)).magnitude;
        N = -0.5f;
    }

    private void FixedUpdate()
    {
        InverseKinematics();

        for (int i = 0; i < hingeJoints.Count; i++)
        {
            if (hingeJoints[i] != null)
            {
                var refAngles = targets.Select(a => ((a + 180) % 360) - 180).ToArray();

                var error = refAngles[i] - hingeJoints[i].angle;
                var absError = Mathf.Abs(error);
                var errorCheck = refAngles[i] - hingeJoints[i].angle + 360;
                if (Mathf.Abs(errorCheck) < absError)
                {
                    error = errorCheck;
                    absError = Mathf.Abs(errorCheck);
                }
                errorCheck = refAngles[i] - hingeJoints[i].angle - 360;
                if (Mathf.Abs(errorCheck) < absError)
                {
                    error = errorCheck;
                    absError = Mathf.Abs(errorCheck);
                }

                var newMotor = new JointMotor();
                var vel = error * gain;
                if (error < 10)
                {
                    vel *= 1.5f;
                }
                else if (error < 5)
                {
                    vel *= 0.8f;
                }
                else if (error < 2)
                {
                    vel *= 0.2f;
                }
                newMotor.targetVelocity = Mathf.Clamp(vel, -60, 60);


                newMotor.force = Mathf.Infinity;

                hingeJoints[i].motor = newMotor;
                hingeJoints[i].useMotor = true;
            }
        }
    }

    public void InverseKinematics()
    {
        var t = new Vector3(-ikTarget.z, ikTarget.y - 2.5f, -ikTarget.x);
        var R = Mathf.Sqrt(Mathf.Pow(t.x, 2) + Mathf.Pow(t.z, 2));
        var s = R - N;

        var Q = Mathf.Sqrt(Mathf.Pow(s, 2) + Mathf.Pow(t.y + h, 2));
        var f = Mathf.Atan2(t.y + h, s);
        var g = Mathf.Acos((Mathf.Pow(L, 2) + Mathf.Pow(Q, 2) - Mathf.Pow(M, 2)) / (2 * L * Q));

        var a = f + g;
        var b = Mathf.Acos((Mathf.Pow(M, 2) + Mathf.Pow(L, 2) - Mathf.Pow(Q, 2)) / (2 * L * M));
        var c = -b - a + 2 * Mathf.PI;
        var d = Mathf.Atan2(t.x, t.z);

        targets[0] = -Mathf.Rad2Deg * d - 180;
        targets[1] = -(Mathf.Rad2Deg * a - 90);
        targets[2] = -(Mathf.Rad2Deg * b - 180);
        targets[3] = -(Mathf.Rad2Deg * c - 180);
    }

    private void OnEnable()
    {
        for (int i = 0; i < Mathf.Min(targets.Count, hingeJoints.Count); i++)
        {
            targets[i] = hingeJoints[i].angle;
        }
    }
}