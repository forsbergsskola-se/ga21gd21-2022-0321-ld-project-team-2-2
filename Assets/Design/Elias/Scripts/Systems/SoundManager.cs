using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Height Check")] 
    public Transform player;
    public Transform car;
    public WindScript WindHeightController;

    private float height;
    public EnterExitVehicle _EnterExit;
    
    [Header("Scrap")]
    public FMODUnity.EventReference scrapPlaceEventHere;
    private FMOD.Studio.EventInstance scrapPickupInstance;
    private bool scrapIs3D = false;
    
    [Header("Footsteps")]
    public FMODUnity.EventReference footPlaceEventHere;
    private FMOD.Studio.EventInstance myInstance;
    private bool footIs3D = false;

    [Header("Jump")]
    public FMODUnity.EventReference jumpPlaceEventHere;
    private FMOD.Studio.EventInstance jumpingInstance;
    public FMODUnity.EventReference landingPlaceEventHere;
    private FMOD.Studio.EventInstance landingInstance;

    [Header("Music")]
    public FMODUnity.EventReference musicEvRef;
    private FMOD.Studio.EventInstance musicEvInst;
    bool stinger1Played = false;
    bool stinger2Played = false;
    bool stinger3Played = false;
    bool stinger4Played = false;
    bool stinger5Played = false;

    [Header("Keycards")]
    public FMODUnity.EventReference keycardPickUpPlaceEventHere;
    public FMODUnity.EventReference keycardUsePlaceEventHere;
    private FMOD.Studio.EventInstance keycardPickUp;
    private FMOD.Studio.EventInstance keycardUse;

    [Header("Vehicle")]
    public FMODUnity.EventReference vehiclePlaceEventHere;
    public FMODUnity.EventReference enterVehiclePlaceEventHere;
    public FMODUnity.EventReference exitVehiclePlaceEventHere;
    private FMOD.Studio.EventInstance enterVehicle;
    private FMOD.Studio.EventInstance exitVehicle;
    private FMOD.Studio.EventInstance vehicleAccelerationInstance;
    FMOD.Studio.PARAMETER_ID rpmParam_ID;
    FMOD.Studio.PARAMETER_ID carGroundedParam_ID;

    [Header("Dialogue")]
    public FMODUnity.EventReference dialogue1PlaceEventHere;
    public FMODUnity.EventReference dialogue2PlaceEventHere;
    public FMODUnity.EventReference dialogue3PlaceEventHere;
    public FMODUnity.EventReference dialogue4PlaceEventHere;
    public FMODUnity.EventReference dialogue5PlaceEventHere;
    private FMOD.Studio.EventInstance dialogueInstance;

    bool dialogue1HasBeenPlayed = false;
    bool dialogue2HasBeenPlayed = false;
    bool dialogue3HasBeenPlayed = false;
    bool dialogue4HasBeenPlayed = false;
    bool dialogue5HasBeenPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(musicEvRef);
        //music
        musicEvInst.start();
        //Scrap Pickup
        scrapPickupInstance = FMODUnity.RuntimeManager.CreateInstance(scrapPlaceEventHere);
        if (scrapIs3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(scrapPickupInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        
        //Footsteps
        myInstance = FMODUnity.RuntimeManager.CreateInstance(footPlaceEventHere);
        if (footIs3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());

        //RPM and groundcheck Vehicle
        vehicleAccelerationInstance = FMODUnity.RuntimeManager.CreateInstance(vehiclePlaceEventHere);
        FMOD.Studio.EventDescription rpmParam_EventDescription;
        FMOD.Studio.EventDescription carGroundedParam_EventDescription;
        vehicleAccelerationInstance.getDescription(out rpmParam_EventDescription);
        vehicleAccelerationInstance.getDescription(out carGroundedParam_EventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION rpmParam_ParameterDescription;
        FMOD.Studio.PARAMETER_DESCRIPTION carGroundedParam_ParameterDescription;
        rpmParam_EventDescription.getParameterDescriptionByName("RPM", out rpmParam_ParameterDescription);
        carGroundedParam_EventDescription.getParameterDescriptionByName("CarGrounded", out carGroundedParam_ParameterDescription);
        rpmParam_ID = rpmParam_ParameterDescription.id;
        carGroundedParam_ID = carGroundedParam_ParameterDescription.id;

        //jumping sound
        jumpingInstance = FMODUnity.RuntimeManager.CreateInstance(jumpPlaceEventHere);
        landingInstance = FMODUnity.RuntimeManager.CreateInstance(landingPlaceEventHere);

        //entering or exiting cars
        enterVehicle = FMODUnity.RuntimeManager.CreateInstance(enterVehiclePlaceEventHere);
        exitVehicle = FMODUnity.RuntimeManager.CreateInstance(exitVehiclePlaceEventHere);
    }
    // Update is called once per frame
    void Update()
    {
        Wind();
        
        //Footsteps
        if(footIs3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
    void Wind()
    {
        if (_EnterExit.inCar)
        {
            height = car.position.y;
            WindHeightController.HeightParam(height);
        }
        else
        {
            height = player.position.y;
            WindHeightController.HeightParam(height);
        }
    }
    public void PickUpSound()
    {
        scrapPickupInstance.start();
    }
    public void Move()
    {
        myInstance.start();
    }
    public void PlayJumpSound()
    {
        jumpingInstance.start();
    }
    public void PlayLandingSound()
    {
        landingInstance.start();
    }

    public void StopMoving()
    {
        myInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void FadeMusic()
    {
        musicEvInst.setParameterByName("InCar", 1f);
    }
    public void FadeInMusic()
    {
        musicEvInst.setParameterByName("InCar", 0);
    }
    public void MusicStinger1()
    {
        if (!stinger1Played)
        {
            musicEvInst.setParameterByName("Stinger1", 1);
            stinger1Played = true;
        }
        
    }
    public void MusicStinger2()
    {
        if (!stinger2Played)
        {
            musicEvInst.setParameterByName("Stinger2", 1);
            stinger2Played = true;
        }
    }
    public void MusicStinger3()
    {
        if (!stinger3Played)
        {
            musicEvInst.setParameterByName("Stinger3", 1);
            stinger3Played = true;
        }
    }
    public void MusicStinger4()
    {
        if (!stinger4Played)
        {
            musicEvInst.setParameterByName("Stinger4", 1);
            stinger4Played = true;
        }
    }
    public void MusicStinger5()
    {
        if (!stinger5Played)
        {
            musicEvInst.setParameterByName("Stinger5", 1);
            stinger5Played = true;
        }
    }
    public void SolvedPuzzleStinger()
    {
        musicEvInst.setParameterByName("SolvedPuzzle", 1);
    }
    public void SetAmbienceZone(int zone)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InDesert", zone == 1 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InStartingArea", zone == 2 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InLake", zone == 3 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InMountains", zone == 4 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InValley", zone == 5 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InRuins", zone == 6 ? 1 : 0);
        Debug.Log("Entering zone " + zone);
    }
    public void SetVehicleRPM(float rpm)
    {
        vehicleAccelerationInstance.setParameterByID(rpmParam_ID, rpm);
    }
    public void SetVehicleGroundParameter(int vehicleIsGrounded)
    {
        vehicleAccelerationInstance.setParameterByID(carGroundedParam_ID, vehicleIsGrounded);
    }
    public void StartCarSound()
    {
        PlayEnterVehicleSound();
        vehicleAccelerationInstance.start();
    }
    public void StopCarSound()
    {
        vehicleAccelerationInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        PlayExitVehicleSound();
    }
    public void PlayDialogue(int dialogueNumber)
    {
        if (dialogueNumber == 1 && !dialogue1HasBeenPlayed)
        {
            dialogue1HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue1PlaceEventHere);
        }
        else if (dialogueNumber == 2 && !dialogue2HasBeenPlayed)
        {
            dialogue2HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue2PlaceEventHere);
        }
        else if (dialogueNumber == 3 && !dialogue3HasBeenPlayed)
        {
            dialogue3HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue3PlaceEventHere);
        }
        else if(dialogueNumber == 4 && !dialogue4HasBeenPlayed)
        {
            dialogue4HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue4PlaceEventHere);
        }
        else if (dialogueNumber == 5 && !dialogue5HasBeenPlayed)
        {
            dialogue5HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue5PlaceEventHere);
        }
        dialogueInstance.start();
        dialogueInstance.release();
    }
    public void PauseDialoguePlayback()
    {
        dialogueInstance.setPaused(true);
    }
    public void ResumeDialoguePlayback()
    {
        dialogueInstance.setPaused(false);
    }
    public void PlayEnterVehicleSound()
    {
        enterVehicle.start();
    }
    public void PlayExitVehicleSound()
    {
        exitVehicle.start();
    }
    public void PlayKeycardUseSound(bool doorUnlocked)
    {
        if (doorUnlocked) keycardUse.setParameterByName("Unlocked", 1);
        else keycardUse.setParameterByName("Unlocked", 0);
        keycardUse = FMODUnity.RuntimeManager.CreateInstance(keycardUsePlaceEventHere);
        keycardUse.start();
        keycardUse.release();
    }
    public void PlayKeycardPickUpSound()
    {
        keycardPickUp = FMODUnity.RuntimeManager.CreateInstance(keycardPickUpPlaceEventHere);
        keycardPickUp.start();
        keycardUse.release();
    }
}
