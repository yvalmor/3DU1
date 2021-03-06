using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public Animator animator;

    public Transform groundCheck;
    public List<LayerMask> groundMask;
    [Range(0.1f, 2)] public float groundDistance = 0.4f;

    public float jumpHeight = 3f;

    Vector3 velocity;
    public bool isGrounded;

    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    void FixedUpdate()
    {
        isGrounded = groundMask.Any(mask => Physics.CheckSphere(groundCheck.position, groundDistance, mask));

        if (isGrounded && velocity.y < 0)
            velocity.y = 0f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        animator.SetBool(IsRunning, x != 0 || z != 0);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * move);

        if (!isGrounded)
            velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger(IsJumping);
        }
    }
}