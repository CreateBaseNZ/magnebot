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
    bool m_HitDetect;
    RaycastHit m_Hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_HitDetect = Physics.BoxCast(new Vector3(0, 1.5f, 0), new Vector3(0.1f, 4f, 4f), Vector3.right, out m_Hit);
        if (m_HitDetect && m_Hit.collider.GetComponent<DinoObstacle>())
        {
            _sensorData.obstacleDistance = new Vector2(m_Hit.transform.position.x - transform.position.x, m_Hit.point.y);
            _sensorData.obstacleSpeed = m_Hit.collider.GetComponent<DinoObstacle>().GetSpeed();
            _sensorData.obstacleSize = new Vector2(m_Hit.collider.bounds.extents.x, m_Hit.collider.bounds.extents.y);
        }
        else
        {
            _sensorData.obstacleDistance = new Vector2(100, _sensorData.obstacleDistance.y);
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
