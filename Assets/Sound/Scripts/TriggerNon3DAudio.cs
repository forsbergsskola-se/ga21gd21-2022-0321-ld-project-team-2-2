using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNon3DAudio : MonoBehaviour
{
    public FMODUnity.EventReference audioObjectPlaceEventHere;
    private FMOD.Studio.EventInstance audioObjectInstance;
    public EnterExitVehicle VehicleCheck;
    bool soundHasBeenPlayed = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar) && !soundHasBeenPlayed)
        {
            soundHasBeenPlayed = true;
            audioObjectInstance = FMODUnity.RuntimeManager.CreateInstance(audioObjectPlaceEventHere);
            audioObjectInstance.start();
            audioObjectInstance.release();
        }
    }

}
