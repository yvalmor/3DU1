using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public List<LayerMask> groundMask;
    [Range(0.1f, 2)] public float groundDistance = 0.4f;

    public float jumpHeight = 3f;

    Vector3 velocity;
    public bool isGrounded;

    void FixedUpdate()
    {
        isGrounded = groundMask.Any(mask => Physics.CheckSphere(groundCheck.position, groundDistance, mask));

        if (isGrounded && velocity.y < 0)
            velocity.y = 0f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * move);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        if (!isGrounded)
            velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}