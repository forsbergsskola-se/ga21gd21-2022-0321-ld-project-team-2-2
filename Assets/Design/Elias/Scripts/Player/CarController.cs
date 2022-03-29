using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float moveInput;
    private float turnInput;
    
    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    
    public Rigidbody sphereRB;
    // Start is called before the first frame update
    void Start()
    {
        sphereRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        
        moveInput *= fwdSpeed > 0 ? fwdSpeed : revSpeed;

        transform.position = sphereRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);
    }

    private void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
