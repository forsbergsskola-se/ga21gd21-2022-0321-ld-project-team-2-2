using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverMovement : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider rearRight;
    [SerializeField] private WheelCollider rearLeft;

    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform rearRightTransform;
    [SerializeField] private Transform rearLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnangle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakforce = 0f;
    private float currentTurnangle = 0f;

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentBreakforce = breakingForce;
        }
        else
        {
            currentBreakforce = 0f;
        }

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakforce;
        frontLeft.brakeTorque = currentBreakforce;
        rearRight.brakeTorque = currentBreakforce;
        rearLeft.brakeTorque = currentBreakforce;

        currentTurnangle = maxTurnangle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnangle;
        frontRight.steerAngle = currentTurnangle;
        
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(rearLeft, rearLeftTransform);
        UpdateWheel(rearRight, rearRightTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}
