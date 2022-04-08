using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterIDTemplate : MonoBehaviour
{
    //Kopiera allt i class och Start men ändra myParam på alla ställen till vad du vill kalla din parameter:
    public FMODUnity.EventReference placeEventHere;
    private FMOD.Studio.EventInstance myInstance;
    FMOD.Studio.PARAMETER_ID myParam_ID; 


    // Start is called before the first frame update
    void Start()
    {
        myInstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        FMOD.Studio.EventDescription myParam_EventDescription;
        myInstance.getDescription(out myParam_EventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION myParam_ParameterDescription;
        myParam_EventDescription.getParameterDescriptionByName("ParameternameinFMOD", out myParam_ParameterDescription);
        myParam_ID = myParam_ParameterDescription.id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
