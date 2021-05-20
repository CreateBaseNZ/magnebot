using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class RoboticArm : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void GetSensorData(string sensorData);

    public HingeJoint[] _hingeJoints;
    private Actuators actuators = new Actuators();
    private SensorData sensorData = new SensorData();
    // Start is called before the first frame update
    void Start()
    {
        actuators.motors = new List<Motor>();
        sensorData.jointData = new List<JointData>();
        
        for (int i = 0; i < _hingeJoints.Length; i++)
        {
            var newMotor = new Motor();
            var newJointData = new JointData();
            actuators.motors.Add(newMotor);
            sensorData.jointData.Add(newJointData);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetActuators(string actuatorSpecs)
    {
        actuators = JsonUtility.FromJson<Actuators>(actuatorSpecs);
    }

    [Serializable]
    struct SensorData
    {
        public List<JointData> jointData;
    }

    [Serializable]
    struct JointData
    {
        public int motorIndex;
        public float angle;
        public Vector3 axis;
        public Vector3 currentForce;
        public Vector3 currentTorque;
        public float velocity;
    }

    [Serializable]
    struct Actuators
    {
        public List<Motor> motors;
    }

    [Serializable]
    struct Motor
    {
        public int motorIndex;
        public float force;
        public float targetVelocity;
        public bool freeSpin;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < Mathf.Min(_hingeJoints.Length, actuators.motors.Count); i++)
        {
            var newMotor = new JointMotor();
            newMotor.force = actuators.motors[i].force;
            newMotor.targetVelocity = actuators.motors[i].targetVelocity;
            newMotor.freeSpin = actuators.motors[i].freeSpin;

            _hingeJoints[actuators.motors[i].motorIndex].motor = newMotor;
            _hingeJoints[actuators.motors[i].motorIndex].useMotor = true;
        }

        for (int i = 0; i < Mathf.Min(_hingeJoints.Length, actuators.motors.Count); i++)
        {
            var newJointData = new JointData();
            newJointData.motorIndex = i;
            newJointData.angle = _hingeJoints[i].angle;
            newJointData.axis = _hingeJoints[i].axis;
            newJointData.currentForce = _hingeJoints[i].currentForce;
            newJointData.currentTorque = _hingeJoints[i].currentTorque;
            newJointData.velocity = _hingeJoints[i].velocity;

            sensorData.jointData[i] = newJointData;
        }
        
#if !UNITY_EDITOR && UNITY_WEBGL
        GetSensorData(JsonUtility.ToJson(sensorData));
#endif
        
    }

}
/*
{
    "motors": [
        {
            "motorIndex": 1,
            "force": 1.0,
            "targetVelocity": 1.0,
            "freeSpin": true
        },
        {
            "motorIndex": 1,
            "force": 1.0,
            "targetVelocity": 1.0,
            "freeSpin": true
        },
        {
            "motorIndex": 1,
            "force": 1.0,
            "targetVelocity": 1.0,
            "freeSpin": true
        },
        {
            "motorIndex": 1,
            "force": 1.0,
            "targetVelocity": 1.0,
            "freeSpin": true
        }
    ]
}*/

/*
 {
    "jointData": [
        {
            "motorIndex": 0,
            "angle": 0.11945667117834091,
            "axis": {
                "x": 0.0,
                "y": 0.0,
                "z": 1.0
            },
            "currentForce": {
                "x": -106.29212951660156,
                "y": -862.5377807617188,
                "z": 11.459287643432618
            },
            "currentTorque": {
                "x": -2.2538552284240724,
                "y": -0.0000053783878684043888,
                "z": -21.659191131591798
            },
            "velocity": 7.166347026824951
        },
        {
            "motorIndex": 1,
            "angle": -2.316192626953125,
            "axis": {
                "x": 0.0,
                "y": 1.0,
                "z": 0.0
            },
            "currentForce": {
                "x": -106.30310821533203,
                "y": -872.34765625,
                "z": 11.48809814453125
            },
            "currentTorque": {
                "x": -347.8370666503906,
                "y": 46.20326614379883,
                "z": 0.0
            },
            "velocity": -25.898653030395509
        },
        {
            "motorIndex": 2,
            "angle": 4.156731128692627,
            "axis": {
                "x": 0.0,
                "y": 1.0,
                "z": 0.0
            },
            "currentForce": {
                "x": -113.68535614013672,
                "y": 140.86767578125,
                "z": 17.97743797302246
            },
            "currentTorque": {
                "x": 80.42326354980469,
                "y": 36.33415985107422,
                "z": 0.0
            },
            "velocity": 146.79638671875
        },
        {
            "motorIndex": 3,
            "angle": -1.749298095703125,
            "axis": {
                "x": 0.0,
                "y": 1.0,
                "z": 0.0
            },
            "currentForce": {
                "x": 39.86400604248047,
                "y": -0.2608591616153717,
                "z": 3.080277919769287
            },
            "currentTorque": {
                "x": 6.005659103393555,
                "y": 5.459183692932129,
                "z": -0.0000022351741790771486
            },
            "velocity": -112.81038665771485
        },
        {
            "motorIndex": 4,
            "angle": 0.4470725357532501,
            "axis": {
                "x": 0.0,
                "y": 0.0,
                "z": 1.0
            },
            "currentForce": {
                "x": -155.7217254638672,
                "y": 62.155784606933597,
                "z": 29.349506378173829
            },
            "currentTorque": {
                "x": 1.0204479694366456,
                "y": -0.3840804100036621,
                "z": 13.97286319732666
            },
            "velocity": -43.276554107666019
        },
        {
            "motorIndex": 5,
            "angle": 0.49289488792419436,
            "axis": {
                "x": 0.0,
                "y": 0.0,
                "z": 1.0
            },
            "currentForce": {
                "x": -113.87754821777344,
                "y": 39.57666778564453,
                "z": -9.427406311035157
            },
            "currentTorque": {
                "x": -2.261148452758789,
                "y": -8.830086708068848,
                "z": -13.844034194946289
            },
            "velocity": -3.700623035430908
        }
    ]
}
*/

