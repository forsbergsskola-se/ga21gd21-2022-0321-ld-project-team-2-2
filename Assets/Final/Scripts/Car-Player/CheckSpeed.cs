using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpeed : MonoBehaviour
{
    public Rigidbody car;
    public SoundManager VehicleSound;
    public EnterExitVehicle EnterExit;
    public CarController CarController;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnterExit.inCar && CarController.isCarGrounded)
        {
            speed = car.velocity.magnitude / 2;
            VehicleSound.SetVehicleRPM(speed);
            VehicleSound.SetVehicleGroundParameter(1);
        }
        else if (EnterExit.inCar && !CarController.isCarGrounded)
        {
            VehicleSound.SetVehicleGroundParameter(0);
        }
        
    }
}
