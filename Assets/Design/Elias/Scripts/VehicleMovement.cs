using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    #region

    [Header("Movement")] 
    public float moveSpeed;
    public float rotationSpeed;
    public float boostSpeed;

    [Header("Camera")] 
    public Transform cameraTransform;
    
    //Components
    private Rigidbody _rigidbody;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
