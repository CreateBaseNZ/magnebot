using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float gravityScale = 1f;
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
        Physics.Raycast(gameObject.transform.position + new Vector3(0.51f, 0, 0), Vector3.right, out hit);
        if (hit.distance < 0.5 && hit.distance != 0)
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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameController.Instance.GameLose();
        }
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(Physics.gravity * gravityScale);
    }
}
