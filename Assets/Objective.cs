using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public float rotationSpeed = 360;

    private ObjectiveGroup _objectiveGroup;

    // Start is called before the first frame update
    void Start()
    {
        _objectiveGroup = GetComponentInParent<ObjectiveGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localEulerAngles += new Vector3(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndEffector"))
        {
            _objectiveGroup.RemoveObjective(this);
        }
    }
}
