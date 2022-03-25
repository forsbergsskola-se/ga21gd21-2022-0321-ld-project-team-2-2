using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitVehicle : MonoBehaviour
{
    //Car
    private bool inVehicle = false;
    
    //Components
    private VehicleMovement vehicleScript;

    public LayerMask entervehicle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VehicleUpdate();
    }
    void VehicleUpdate()
    {
        Collider[] hitcollider = Physics.OverlapSphere(transform.position, 5f, entervehicle);
        
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            transform.position = vehicleScript.transform.position + new Vector3(3, vehicleScript.transform.position.y, vehicleScript.transform.position.z);
            gameObject.SetActive(true);
        }
        //If player is inside a trigger, a bool will go on, and turn of when you leave. If it's on and press F you enter vehicle.
    }
}
