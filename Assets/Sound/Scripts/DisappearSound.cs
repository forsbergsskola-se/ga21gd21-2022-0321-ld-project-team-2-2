using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearSound : MonoBehaviour
{
    public EnterExitVehicle VehicleCheck;
    public PlatFormEngineSound PlatformEngine;
    public FMODUnity.EventReference disappearSoundPlaceEventHere;
    private FMOD.Studio.EventInstance disappearSoundInstance;
    public FMODUnity.EventReference appearSoundPlaceEventHere;
    private FMOD.Studio.EventInstance appearSoundInstance;
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
            disappearSoundInstance = FMODUnity.RuntimeManager.CreateInstance(disappearSoundPlaceEventHere);
            appearSoundInstance = FMODUnity.RuntimeManager.CreateInstance(disappearSoundPlaceEventHere);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(appearSoundInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(disappearSoundInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            disappearSoundInstance.release();
        }
    }
    public void PlayAppearingSound()
    {
        disappearSoundInstance.start();
        PlatformEngine.EnablePlatformAudio();
    }
    public void PlayDisappearingSound()
    {
        appearSoundInstance.start();
        PlatformEngine.DisablePlatformAudio();
    }
}
