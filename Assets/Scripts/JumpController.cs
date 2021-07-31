using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool invincible = false;
    public bool enableKeyboardControls = false;
    public float gravityScale = 1f;
    public float jumpForce = 20f;
    public ParticleSystem deathParticles;

    private Rigidbody _rigidbody;
    private BoxCollider _collider;
    private bool _isJumping;
    private Animator _animator;
    private float _crouchTimer;
    private float _jumpTimer;
    private Bounds _standingBounds;
    private bool _onResearchStage;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<BoxCollider>();
        _standingBounds = _collider.bounds;
        _standingBounds.center -= transform.position;
        _isJumping = true;
        _onResearchStage = PlayerPrefs.GetString("creationStage") == "research";
    }

    // Update is called once per frame
    void Update()
    {
        if (_onResearchStage || enableKeyboardControls)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Crouch();
            }
        }
        if (_crouchTimer == 0 && !_isJumping)
        {
            _collider.center = _standingBounds.center;
            _collider.size = _standingBounds.size;
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isDucking", false);
        }
        _crouchTimer = Mathf.Clamp(_crouchTimer -= Time.deltaTime, 0, 0.6f);
        _jumpTimer = Mathf.Clamp(_jumpTimer -= Time.deltaTime, 0, 0.5f);
    }

    public void Crouch()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(new Vector3(0, -jumpForce * 0.1f, 0), ForceMode.Impulse);
        }
        else
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isDucking", true);
            _collider.center = new Vector3(0, 1, 0);
            _collider.size = new Vector3(1, 1, 1);
            _crouchTimer = 0.6f;
            //Crouch
        }
    }

    public void Jump()
    {
        if (!_isJumping && _jumpTimer == 0)
        {
            _isJumping = true;
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isDucking", false);
            _crouchTimer = 0;
            _jumpTimer = 0.5f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isJumping = false;
        _animator.SetBool("isRunning", true);
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
