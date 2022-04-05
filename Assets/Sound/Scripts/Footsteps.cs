using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public FMODUnity.EventReference placeEventHere;
    private FMOD.Studio.EventInstance myInstance;
    public bool is3D = false;
    void Start()
    {
        myInstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    void Update()
    {
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
    public void Move()
    {
        myInstance.start();
    }
    public void StopMoving()
    {
        myInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
