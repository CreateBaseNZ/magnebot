using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private ObjectiveGroup _objectiveGroup;

    // Start is called before the first frame update
    void Start()
    {
        _objectiveGroup = GetComponentInParent<ObjectiveGroup>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag) && other.GetComponent<Objective>() == null)
        {
            _objectiveGroup.RemoveObjective(this);
        }
    }
}
