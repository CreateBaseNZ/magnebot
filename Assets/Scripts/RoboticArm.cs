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
    private ArmController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<ArmController>();

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
        if (_controller.enabled)
        {
            _controller.enabled = false;
        }
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