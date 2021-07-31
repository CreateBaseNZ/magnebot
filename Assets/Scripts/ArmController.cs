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
    public GameObject targetVisual;

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
        targetVisual.transform.position = ikTarget + new Vector3(0,-0.75f,0);
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
                    vel *= 2f;
                }
                else if (error < 5)
                {
                    vel *= 1f;
                }
                else if (error < 2)
                {
                    vel *= 0.5f;
                }
                newMotor.targetVelocity = Mathf.Clamp(vel, -100, 100);
                newMotor.force = Mathf.Infinity;
                newMotor.freeSpin = false;
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

        float[] tempTargets = new float[4];
        tempTargets[0] = -Mathf.Rad2Deg * d - 180;
        tempTargets[1] = -(Mathf.Rad2Deg * a - 90);
        tempTargets[2] = -(Mathf.Rad2Deg * b - 180);
        tempTargets[3] = -(Mathf.Rad2Deg * c - 180);

        if (!tempTargets.Any(a => float.IsNaN(a)))
        {
            targets[0] = tempTargets[0];
            targets[1] = tempTargets[1];
            targets[2] = tempTargets[2];
            targets[3] = tempTargets[3];
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