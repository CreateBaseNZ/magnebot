using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GravityClaw : MonoBehaviour
{
    public bool dropObject = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dropObject)
        {
            var list = GetComponentsInChildren<Transform>().ToList();
            list[0].gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
            list[0].transform.parent = null;
            GetComponent<SphereCollider>().enabled = false;
        }
        else
        {
            GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower().Contains("objective"))
        {
            other.transform.parent = gameObject.transform;
            other.transform.localPosition = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void DisableGravitySphere()
    {
        dropObject = true;
    }

    public void EnableGravitySphere()
    {
        dropObject = false;
    }
}
