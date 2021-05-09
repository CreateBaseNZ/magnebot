using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveLabel : MonoBehaviour
{
    private Camera _camera;
    private TextMesh _textMesh;

    // Start is called before the first frame update
    void Start()
    {
        _textMesh = GetComponent<TextMesh>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(_camera.transform, Vector3.up);
        _textMesh.text = transform.parent.position.ToString();
    }
}
