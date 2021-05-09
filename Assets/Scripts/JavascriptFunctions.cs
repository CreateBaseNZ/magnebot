using UnityEngine;
using System.Runtime.InteropServices;

public class JavascriptFunctions : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetSensorValues(float baseAngle, float shoulderAngle, float elbowAngle, float wristAngle);

    void Start()
    {

    }

    public void GetArmAngles(float baseAngle, float shoulderAngle, float elbowAngle, float wristAngle)
    {
        GetSensorValues(baseAngle, shoulderAngle, elbowAngle, wristAngle);
    }
}
