using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObjectLoader : MonoBehaviour
{
    public EnterExitVehicle VehicleCheck;
    public FMODUnity.EventReference audioObjectPlaceEventHere;
    private FMOD.Studio.EventInstance audioObjectInstance;
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
            audioObjectInstance = FMODUnity.RuntimeManager.CreateInstance(audioObjectPlaceEventHere);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(audioObjectInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            audioObjectInstance.start();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            audioObjectInstance.release();
        }
    }
}
