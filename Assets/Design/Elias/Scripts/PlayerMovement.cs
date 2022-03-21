using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed;
    public float rotationSpeed;
    public float runSpeed;

    [Header("Jump")] 
    public float jumpSpeed;
    public float gravityScale;
    private float _ySpeed;

    [Header("Camera")] 
    [SerializeField] private Transform cameraTransform;
    
    //Components
    private CharacterController CharacterController;
    private Animation animator;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (CharacterController.isGrounded)
        {
            Jump();
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = movementDirection.magnitude;
        magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = _ySpeed;
        
        CharacterController.Move(velocity * Time.deltaTime);
        _ySpeed += Physics.gravity.y * gravityScale * Time.deltaTime;

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        _ySpeed = -0.5f;
        if (Input.GetButtonDown("Jump"))
        {
            _ySpeed = jumpSpeed;
        }
    }
}
