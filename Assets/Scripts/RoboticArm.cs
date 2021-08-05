using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class RoboticArm : MonoBehaviour
{
    public GameObject endEffector;

    [DllImport("__Internal")]
    private static extern void GetSensorData(string sensorData);
    private SensorData sensorData = new SensorData();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        sensorData.endEffectorPosition = endEffector.transform.position;
#if !UNITY_EDITOR && UNITY_WEBGL
        GetSensorData(JsonUtility.ToJson(sensorData));
#endif
    }

    [Serializable]
    struct SensorData
    {
        public Vector3 endEffectorPosition;
    }

}