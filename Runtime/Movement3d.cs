using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3d : MonoBehaviour
{
    #region Variables

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
        SpeedSmoothing();
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

        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            forward = 1f;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            forward = -1f;
            isMoving = true;
        }
        else
        {
            isMoving = false;
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

    void SpeedCalculation(float directionalSpeed, string direction)
    {
        targetSpeed = speedMultiplier * baseSpeed * directionalSpeed;
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
