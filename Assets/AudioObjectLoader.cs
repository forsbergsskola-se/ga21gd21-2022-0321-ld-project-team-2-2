using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObjectLoader : MonoBehaviour
{
    public EnterExitVehicle VehicleCheck;
    public FMODUnity.EventReference audioObjectPlaceEventHere;
    private FMOD.Studio.EventInstance audioObjectInstance;
    public bool playOnlyOnce = false;
    private bool soundHasBeenPlayed = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (playOnlyOnce)
        {
            if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar) && !soundHasBeenPlayed)
            {
                audioObjectInstance = FMODUnity.RuntimeManager.CreateInstance(audioObjectPlaceEventHere);
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(audioObjectInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
                audioObjectInstance.start();
                soundHasBeenPlayed = true;
            }
        }
        else
        {
            if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
            {
                audioObjectInstance = FMODUnity.RuntimeManager.CreateInstance(audioObjectPlaceEventHere);
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(audioObjectInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
                audioObjectInstance.start();
            }
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar)) && playOnlyOnce)
        {
            audioObjectInstance.release();
        }
        else if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            StopPlaying();
        }
    }
    public void StopPlaying()
    {
        audioObjectInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        audioObjectInstance.release();
    }
}
