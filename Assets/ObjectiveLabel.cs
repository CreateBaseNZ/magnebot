using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveLabel : MonoBehaviour
{
    private Camera _camera;
    private TextMesh _textMesh;
    private GameObject _objective;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _objective = transform.parent.GetComponentInChildren<Objective>().gameObject;
        _textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(_camera.transform, Vector3.up);
        _textMesh.text = _objective.transform.position.ToString();
    }
}
