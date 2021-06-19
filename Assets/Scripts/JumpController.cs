using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool invincible = false;
    public float gravityScale = 1f;
    public float jumpForce = 20f;
    public ParticleSystem deathParticles;

    private Rigidbody _rigidbody;
    private BoxCollider _collider;
    private bool _isJumping;
    private Animator _animator;
    private AudioSource _deathSound;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<BoxCollider>();
        _deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position + new Vector3(0.51f, 0, 0), Vector3.right, out hit);
        if (hit.distance < 0.5 && hit.distance != 0)
        {
            Jump();
        }
        */
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Crouch();
            _collider.center = new Vector3(0, 1, 0);
            _collider.size = new Vector3(1, 1, 1);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _collider.center = new Vector3(0, 1.75f, 0);
            _collider.size = new Vector3(1.5f, 2.5f, 1);
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isDucking", false);
        }
    }

    public void Crouch()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(new Vector3(0, -jumpForce * 0.1f, 0), ForceMode.Impulse);
        }
        else
        {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isDucking", true);
            //Crouch

        }
    }

    public void Jump()
    {
        if (!_isJumping)
        {
            _isJumping = true;
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isDucking", false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isJumping = false;
        _animator.SetBool("isWalking", true);
        _animator.SetBool("isJumping", false);
        _animator.SetBool("isDucking", false);


        if (collision.gameObject.CompareTag("Obstacle") && !invincible)
        {
            GameController.Instance.GameLose();
            Instantiate(deathParticles, gameObject.transform.position + Vector3.up * 1.5f, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(Physics.gravity * gravityScale);
    }
}
