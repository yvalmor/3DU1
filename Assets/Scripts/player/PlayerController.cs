using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActions _inputActions;
    private Rigidbody _rb;
    private Vector2 _moveInput;
    private Transform _tr;

    [SerializeField] private bool isGrounded = false;

    [Range(0, 10)] public float speed = 1f;
    [Range(0, 20)] public float movementDrag = 20f;
    [Range(0, 20)] public float jumpHeight = 20f;

    public Camera playerPOV;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb is null)
            Debug.LogError("Rigidbody of player is null");

        _tr = transform;
    }

    private void Awake()
    {
        _inputActions = new InputActions();

        _inputActions.Player.Jump.performed += x => Jump();
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    private void Jump()
    {
        // FIXME isGrounded needs to be updated (is at false for now)
        if (!isGrounded)
            return;

        Debug.Log("jump");
        _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 movement = _tr.forward * _moveInput.y + _tr.right * _moveInput.x;
        
        Vector3 velocity = _rb.velocity + movement * speed;

        float multiplier = 1.0f - movementDrag * Time.fixedDeltaTime;
        if (multiplier < 0.0f) multiplier = 0.0f;

        velocity.x = Mathf.Clamp(velocity.x, -10, 10) * multiplier;
        velocity.z = Mathf.Clamp(velocity.z, -10, 10) * multiplier;

        _rb.velocity = velocity;
    }
}