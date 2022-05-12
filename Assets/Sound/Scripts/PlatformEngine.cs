using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormEngineSound : MonoBehaviour
{
    public FMODUnity.EventReference platformEnginePlaceEventHere;
    private FMOD.Studio.EventInstance platformEngineInstance;
    public EnterExitVehicle VehicleCheck;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            platformEngineInstance = FMODUnity.RuntimeManager.CreateInstance(platformEnginePlaceEventHere);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(platformEngineInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            platformEngineInstance.release();
        }
    }
}
