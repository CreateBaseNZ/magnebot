using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GravityClaw : MonoBehaviour
{
    public bool dropObject = false;
    public Material shader;

    // Start is called before the first frame update
    void Start()
    {
        if (dropObject)
        {
            DisableGravitySphere();
        }
        else
        {
            EnableGravitySphere();
        }
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
        shader.SetFloat("Speed", 0);
        shader.SetColor("Base_Color", Color.black);
        shader.SetFloat("Line_Transparency", 0.01f);
        shader.SetColor("Glow_Colour", new Color(0.8f, 0.8f, 0.8f) * 5);
        shader.SetFloat("Line_Thickness", 0.02f);

    }

    public void EnableGravitySphere()
    {
        dropObject = false;
        shader.SetFloat("Speed", 2);
        shader.SetColor("Base_Color", Color.white);
        shader.SetFloat("Line_Transparency", 1);
        shader.SetColor("Glow_Colour", new Color(3f / 255f, 191f / 255f, 0) * 8);
        shader.SetFloat("Line_Thickness", 0.12f);
    }
}
