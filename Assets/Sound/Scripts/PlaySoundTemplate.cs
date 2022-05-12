using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTemplate : MonoBehaviour
{
    public FMODUnity.EventReference placeEventHere;
    private FMOD.Studio.EventInstance myInstance;
    public bool is3D = false;
    // Start is called before the first frame update
    void Start()
    {
        myInstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {
        /*To play event once and then scrap it:
        if (enter what triggers the event) myInstance.start();

        To stop the event:
        if (enter what triggers the event stop) myInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        Release the event:
        if (enter what releases the event) myIstance.release();

        Create temporary instances on the fly:
        if (enter what triggers the event) 
        {
        FMOD.Studio.EventInstance.tempIns = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        tempInst.start();
        tempInst.release

        Changing parameters:
        if (enter what triggers the param change) myInstance.setParameterByName("ParameterName", 40f);
        
        }
        */

    }
}
