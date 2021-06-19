using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Runtime.InteropServices;

public class PlayerSensor : MonoBehaviour
{
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
        RaycastHit hit;
        if (Physics.BoxCast(transform.position + new Vector3(0, 1.6f, 0), new Vector3(0.1f, 1.5f, 1f), Vector3.right, out hit))
        {
            if (hit.collider.GetComponent<DinoObstacle>())
            {
                _sensorData.obstacleDistance = new Vector2(hit.distance, hit.point.y);
                _sensorData.obstacleSpeed = hit.collider.GetComponent<DinoObstacle>().GetSpeed();
                _sensorData.obstacleSize = new Vector2(hit.collider.bounds.extents.x, hit.collider.bounds.extents.y);
            }
        }

#if !UNITY_EDITOR && UNITY_WEBGL
            GetSensorData(JsonUtility.ToJson(_sensorData));
#endif
    }

    [Serializable]
    struct PlayerSensors
    {
        public Vector2 obstacleDistance;
        public float obstacleSpeed;
        public Vector2 obstacleSize;
    }
}
