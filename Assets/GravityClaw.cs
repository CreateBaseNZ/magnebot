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
            list.RemoveAt(0);
            list[0].gameObject.GetComponent<Rigidbody>().isKinematic = false;
            list[0].transform.parent = null;
            dropObject = false;
            GetComponent<SphereCollider>().enabled = false;
            Invoke("EnableCollider", 2);

        }
    }

    private void EnableCollider()
    {
        GetComponent<SphereCollider>().enabled = true;
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
        dropObject = false;
    }
}
