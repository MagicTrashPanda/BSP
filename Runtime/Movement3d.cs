using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3d : MonoBehaviour
{
    #region Variables

    [Header("Modules")]
    [SerializeField] private bool jumpEnabled;
    [SerializeField] private bool sprintEnabled;
    [SerializeField] private bool speedSmoothing;
    [Header("Directional Movement")]
    [SerializeField] private float forward;
    [SerializeField] private float horizontal;
    [SerializeField] private bool isMoving;
   
    [Header("Speed Statistics")]
    [SerializeField] private float baseSpeed = 5;
    [SerializeField] private float targetSpeed;
   
    [Header("Movement Modifiers")]
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float inertiaMultiplier = 1;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float sprintSpeedMultiplier = 1f;
    [SerializeField] private bool sprintPressed;
   
    [Header("Position Checks")]
    [SerializeField] private bool grounded;
    private bool isGrounded;

    [Header("Misc")]
    [SerializeField] private LayerMask mask;

    Rigidbody rb;

    #endregion

    #region Unity Functions
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
        if (jumpEnabled)
        {
            HandleJump();
        }
        if (sprintEnabled)
        {
            HandleSprint();
        }
        GetGrounded();
        if (speedSmoothing)
        {
            SpeedSmoothing();
        }
        ApplyMovement();
    }

    #endregion

    #region Core Movement

    //basic movement
    void HandleInput()
    {
        horizontal = 0;
        forward = 0;

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            forward = 1f;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            forward = -1f;
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            isMoving = false;
        }
    }


    void SpeedCalculation(float directionalSpeed, string direction)
    {
        targetSpeed = speedMultiplier * baseSpeed * directionalSpeed * sprintSpeedMultiplier;
        Vector3 velocity = rb.linearVelocity;
        switch (direction)
        {
            case "x":
                rb.linearVelocity = new Vector3(targetSpeed, velocity.y, velocity.z);
                break;
            case "z":
                rb.linearVelocity = new Vector3(velocity.x, velocity.y, targetSpeed);
                break;
        }
    }

    void ApplyMovement()
    {
        SpeedCalculation(horizontal, "x");
        SpeedCalculation(forward, "z");
    }
    #endregion

    #region Optional Movement

    void HandleJump()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintPressed = true;
            sprintSpeedMultiplier = 2f;
        }
        else
        {
            sprintPressed = false;
            sprintSpeedMultiplier = 1f;
        }
    }
    void SpeedSmoothing()
    {
        if (isMoving && speedMultiplier < 1)
        {
            speedMultiplier += Time.deltaTime * inertiaMultiplier;
        }
        else if (!isMoving && speedMultiplier > 0)
        {
            speedMultiplier -= Time.deltaTime * 2;
            if (speedMultiplier < 0) speedMultiplier = 0;
        }
    }

    #endregion

    #region Checks
    void GetGrounded()
    {
        RaycastHit hitLeft;
        RaycastHit hitRight;
        RaycastHit hit;

        Vector3 playerLeft = transform.position - new Vector3(0.40f, 0, 0);
        Vector3 playerRight = transform.position + new Vector3(0.40f, 0, 0);


        grounded = Physics.Raycast(transform.position, Vector3.down, out hit, .6f, mask) ||
                   Physics.Raycast(playerLeft, Vector3.down, out hitLeft, .6f, mask) ||
                   Physics.Raycast(playerRight, Vector3.down, out hitRight, .6f, mask);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, .6f, mask) && (Physics.Raycast(playerLeft, Vector3.down, out hitLeft, .6f, mask) || Physics.Raycast(playerRight, Vector3.down, out hitRight, .6f, mask)) ||
                     Physics.Raycast(playerLeft, Vector3.down, out hitLeft, .6f, mask) && Physics.Raycast(playerRight, Vector3.down, out hitRight, .6f, mask);
    }
    #endregion
}
