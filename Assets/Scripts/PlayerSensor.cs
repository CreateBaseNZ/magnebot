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
    RaycastHit[] _boxHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _boxHit = Physics.BoxCastAll(new Vector3(transform.position.x, 1.5f, 0), new Vector3(0.05f, 4f, 4f), Vector3.right);
        var hit = _boxHit.Where(w => w.collider.GetComponent<DinoObstacle>()).ToList();
        if (hit.Count > 0)
        {
            _sensorData.obstacleDistance = new Vector2(hit[0].transform.position.x - transform.position.x, hit[0].point.y);
            _sensorData.obstacleSpeed = hit[0].collider.GetComponent<DinoObstacle>().GetSpeed();
            _sensorData.obstacleSize = new Vector2(hit[0].collider.bounds.extents.x, hit[0].collider.bounds.extents.y);
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
