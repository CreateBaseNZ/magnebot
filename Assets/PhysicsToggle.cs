using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhysicsToggle : MonoBehaviour
{
    public Toggle physicsToggle;
    private bool _toggleState;

    // Start is called before the first frame update
    void Start()
    {
        _toggleState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (physicsToggle.isOn != _toggleState)
        {
            _toggleState = physicsToggle.isOn;
            Rigidbody[] allRigidBodies = Object.FindObjectsOfType<Rigidbody>();
            foreach (var rb in allRigidBodies)
            {
                if (rb.gameObject.activeInHierarchy)
                {
                    rb.isKinematic = !_toggleState;
                    rb.useGravity = _toggleState;
                }
            }
        }
    }
}
