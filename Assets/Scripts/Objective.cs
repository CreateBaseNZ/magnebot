using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public float stayTime = 0f;
    public GameObject collectEffect;
    private float _currentStayTime = 0f;
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
        Check(other);
    }

    private void OnTriggerStay(Collider other)
    {
        Check(other);
    }

    private void OnTriggerExit(Collider other)
    {
        _currentStayTime = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Check(collision.collider);
    }

    private void OnCollisionStay(Collision collision)
    {
        Check(collision.collider);
    }

    private void OnCollisionExit(Collision collision)
    {
        _currentStayTime = 0;
    }

    private void Check(Collider other)
    {
        if (other.CompareTag(tag) && other.GetComponent<Objective>() == null)
        {
            _currentStayTime += Time.deltaTime;
            if(_currentStayTime >= stayTime)
            {
                if (collectEffect != null)
                {
                    Instantiate(collectEffect, other.transform);
                }
                _objectiveGroup.RemoveObjective(this);
            }
        }
    }
}
