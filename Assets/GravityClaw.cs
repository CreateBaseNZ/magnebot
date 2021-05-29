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
            var rb = list[0].gameObject.GetComponentInChildren<Rigidbody>();

            if (rb)
            {
                rb.isKinematic = false;
            }
            if (list.Count > 1)
            {
                list[1].transform.parent = null;
            }
            GetComponent<SphereCollider>().enabled = false;
        }
        else
        {
            GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActiveAndEnabled)
        {
            if (other.tag.ToLower().Contains("objective"))
            {
                other.transform.parent = gameObject.transform;
                other.transform.localPosition = Vector3.zero;
                var rb = other.gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.isKinematic = true;
                }
            }
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
