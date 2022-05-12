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

    [Header("Player Impact")]
    public FMODUnity.EventReference playerImpactPlaceEventHere;
    private FMOD.Studio.EventInstance playerImpactInstance;

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
    private FMOD.Studio.EventInstance vehicleAccelerationInstance;
    FMOD.Studio.PARAMETER_ID rpmParam_ID;
    FMOD.Studio.PARAMETER_ID carGroundedParam_ID;

    [Header("Teleport")]
    public FMODUnity.EventReference teleportedPlayerSoundPlaceEventHere;
    private FMOD.Studio.EventInstance teleportedPlayerSoundInstance;

    [Header("Dialogue")]
    public FMODUnity.EventReference dialogue1PlaceEventHere;
    public FMODUnity.EventReference dialogue2PlaceEventHere;
    public FMODUnity.EventReference dialogue3PlaceEventHere;
    public FMODUnity.EventReference dialogue4PlaceEventHere;
    public FMODUnity.EventReference dialogue5PlaceEventHere;
    private FMOD.Studio.EventInstance dialogueInstance;

    [Header("Inventory sounds")]
    public FMODUnity.EventReference inventoryPlaceEventHere;
    public FMODUnity.EventReference clickPlaceEventHere;
    public FMODUnity.EventReference upgradePlaceEventHere;
    private FMOD.Studio.EventInstance inventoryInstance;
    private FMOD.Studio.EventInstance clickInstance;
    private FMOD.Studio.EventInstance upgradeInstance;

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

        //jumping sound
        jumpingInstance = FMODUnity.RuntimeManager.CreateInstance(jumpPlaceEventHere);

        //entering or exiting cars

        //Inventory
        clickInstance = FMODUnity.RuntimeManager.CreateInstance(clickPlaceEventHere);
        keycardPickUp = FMODUnity.RuntimeManager.CreateInstance(keycardPickUpPlaceEventHere);
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
    public void StopMoving()
    {
        myInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void SetPlayerStateToInCar()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InCar", 1f);
    }
    public void SetPlayerStateToOutsideCar()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InCar", 0);
    }
    public void MusicStinger(int stinger)
    {
        if (stinger == 1 && !stinger1Played)
        {
            musicEvInst.setParameterByName("Stinger1", 1);
            stinger1Played = true;
        }
        else if(stinger == 2 && !stinger2Played)
        {
            musicEvInst.setParameterByName("Stinger2", 1);
            stinger2Played = true;
        }
        else if (stinger == 3 && !stinger3Played)
        {
            musicEvInst.setParameterByName("Stinger3", 1);
            stinger3Played = true;
        }
        else if (stinger == 4 && !stinger4Played)
        {
            musicEvInst.setParameterByName("Stinger4", 1);
            stinger4Played = true;
        }
        else if (stinger == 5 && !stinger5Played)
        {
            musicEvInst.setParameterByName("Stinger2", 1);
            stinger2Played = true;
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
        vehicleAccelerationInstance.start();
    }

    public void StopCarSound()
    {
        vehicleAccelerationInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
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
        keycardPickUp.release();
    }
    public void PlayOpenInventorySound()
    {
        inventoryInstance = FMODUnity.RuntimeManager.CreateInstance(inventoryPlaceEventHere);
        inventoryInstance.start();
    }
    public void PlayCloseInventorySound()
    {
        inventoryInstance.setParameterByName("InventoryOpen", 0);
        inventoryInstance.release();
    }
    public void PlayTeleportedPlayerSound()
    {
        teleportedPlayerSoundInstance = FMODUnity.RuntimeManager.CreateInstance(teleportedPlayerSoundPlaceEventHere);
        teleportedPlayerSoundInstance.start();
        teleportedPlayerSoundInstance.release();
    }
    public void PlayUpgradeSound(bool sufficientFunds)
    {
        upgradeInstance = FMODUnity.RuntimeManager.CreateInstance(upgradePlaceEventHere);
        if (sufficientFunds) upgradeInstance.setParameterByName("Success", 1);
        else upgradeInstance.setParameterByName("Success", 0);
        upgradeInstance.start();
        upgradeInstance.release();
    }
    public void PlayUIClickSound()
    {
        clickInstance = FMODUnity.RuntimeManager.CreateInstance(clickPlaceEventHere);
        clickInstance.start();
        clickInstance.release();
    }
    //Landing from a higher altitude:
    public void PlayerImpact(float velocity)
    {
        playerImpactInstance = FMODUnity.RuntimeManager.CreateInstance(playerImpactPlaceEventHere);
        playerImpactInstance.setParameterByName("Velocity", velocity);
        playerImpactInstance.release();
    }
}
