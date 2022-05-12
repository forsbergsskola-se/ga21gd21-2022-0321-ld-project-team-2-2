using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearSound : MonoBehaviour
{
    public EnterExitVehicle VehicleCheck;
    public FMODUnity.EventReference disappearSoundPlaceEventHere;
    private FMOD.Studio.EventInstance disappearSoundInstance;
    public FMODUnity.EventReference appearSoundPlaceEventHere;
    private FMOD.Studio.EventInstance appearSoundInstance;
    public FMODUnity.EventReference platformEnginePlaceEventHere;
    private FMOD.Studio.EventInstance platformEngineInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            platformEngineInstance = FMODUnity.RuntimeManager.CreateInstance(platformEnginePlaceEventHere);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(platformEngineInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            platformEngineInstance.start();
            Debug.Log("Started instance");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            platformEngineInstance.release();
        }
    }
    public void PlayAppearingSound()
    {
        appearSoundInstance = FMODUnity.RuntimeManager.CreateInstance(appearSoundPlaceEventHere);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(appearSoundInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        appearSoundInstance.start();
        platformEngineInstance.setParameterByName("Active", 1);
        appearSoundInstance.release();
    }
    public void PlayDisappearingSound()
    {
        disappearSoundInstance = FMODUnity.RuntimeManager.CreateInstance(disappearSoundPlaceEventHere);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(disappearSoundInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        disappearSoundInstance.start();
        platformEngineInstance.setParameterByName("Active", 0);
        disappearSoundInstance.release();

    }
}
