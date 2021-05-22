using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float yawSpeed = 100f;
    public float pitchSpeed = 100f;

    private float _currentZoom = 10f;
    private float _currentYaw = 0f;
    private float _currentPitch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _currentZoom = 36.7999f;
        _currentYaw = -149.2203f;
        _currentPitch = 7.727794f;
    }

    // Update is called once per frame
    void Update()
    {
        _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        _currentZoom = Mathf.Clamp(_currentZoom, minZoom, maxZoom);

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            _currentYaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
            _currentPitch += Input.GetAxis("Mouse Y") * pitchSpeed * Time.deltaTime;
        }
        _currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        _currentPitch -= Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;

    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * _currentZoom;
        transform.LookAt(target.position);

        transform.RotateAround(target.position, Vector3.up, _currentYaw);
        transform.RotateAround(target.position, -transform.right, _currentPitch);
    }
}