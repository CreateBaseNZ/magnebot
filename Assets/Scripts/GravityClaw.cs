using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GravityClaw : MonoBehaviour
{
    public bool dropObject = false;
    public Material shader;
    public GameObject targetVisual;
    private Material _targetMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _targetMaterial = targetVisual.GetComponent<Renderer>().material;
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
        if (Vector3.Distance(targetVisual.transform.position, transform.position) < 0.5f)
        {
            _targetMaterial.color = new Color(0, 1, 0, 0.8f);
        }
        else
        {
            _targetMaterial.color = new Color(1, 0, 0, 0.8f);
        }

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
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActiveAndEnabled && !dropObject)
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

    public void EnableGravitySphere(Toggle toggle)
    {
        if (toggle.isOn)
        {
            EnableGravitySphere();
        }
        else
        {
            DisableGravitySphere();
        }
    }
}
