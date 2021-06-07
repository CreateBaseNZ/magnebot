using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 20f;
    private Rigidbody _rigidbody;
    private bool _isJumping;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position + new Vector3(3f, 0, 0), Vector3.right, out hit);
        if(hit.distance < 2)
        {
            Jump();
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (!_isJumping)
        {
            _isJumping = true;
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isJumping = false;
    }
}
