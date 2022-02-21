using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ReactSensors : MonoBehaviour
{
    public List<Sensor> sensors;

    [DllImport("__Internal")]
    private static extern void GetSensorData(string sensorData);
    private PlayerSensors _sensorData = new PlayerSensors();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _sensorData.x = 1;
        
#if !UNITY_EDITOR && UNITY_WEBGL
        GetSensorData(JsonUtility.ToJson(_sensorData));
#endif
    }

    [Serializable]
    public struct PlayerSensors
    {
        public int x;
    }

    public PlayerSensors GetSensorData()
    {
        return _sensorData;
    }

}
