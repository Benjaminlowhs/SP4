using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -19.62f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float defaultSpeed = 12f;
    public float runMultiplier = 2f;
    public float currentStamina;
    private float maxStamina = 100f;
    public bool isRegenStamina = false;
    public bool isRunning = false;

    Vector3 velocity;
    bool isGrounded;

    void Movement(float x, float z)
    {
        Vector3 move;
        move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentStamina >= 0 && !isRegenStamina)
            {
                // Can run
                isRunning = true;
            }

            if (currentStamina >= maxStamina)
                isRegenStamina = false;
        }
        else
        {
            isRunning = false;
            if (currentStamina < maxStamina)
                isRegenStamina = true;
            else
                isRegenStamina = false;
        }

        if (isRunning)
            currentStamina -= 20f * Time.deltaTime;

        if (isRegenStamina)
            currentStamina += 8f * Time.deltaTime;

        if (isRunning)
            controller.Move(move * defaultSpeed * runMultiplier * Time.deltaTime);
        else
            controller.Move(move * defaultSpeed * Time.deltaTime);
    }

    void Start()
    {
        currentStamina = maxStamina;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Movement(x, z);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
