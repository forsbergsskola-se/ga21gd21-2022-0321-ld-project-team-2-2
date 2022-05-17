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
    FMOD.Studio.EventInstance muteMusicSnapshot;
    bool musicOn = true;
    

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

    public FMODUnity.EventReference[] dialoguePlaceEventHere;
    public DialogueManager DialogueVarManager;
    private FMOD.Studio.EventInstance dialogueInstance;
    public List<int> thisDialogueHasBeenPlayed = new();

    /* public FMODUnity.EventReference dialogue1PlaceEventHere;
     public FMODUnity.EventReference dialogue2PlaceEventHere;
     public FMODUnity.EventReference dialogue3PlaceEventHere;
     public FMODUnity.EventReference dialogue4PlaceEventHere;
     public FMODUnity.EventReference dialogue5PlaceEventHere;
     public FMODUnity.EventReference dialogue6PlaceEventHere;
     public FMODUnity.EventReference dialogue7PlaceEventHere;
     public FMODUnity.EventReference dialogue8PlaceEventHere;
     public FMODUnity.EventReference dialogue9PlaceEventHere;
     public FMODUnity.EventReference dialogue10PlaceEventHere;
     public FMODUnity.EventReference dialogue11PlaceEventHere;
     public FMODUnity.EventReference dialogue12PlaceEventHere;
     public FMODUnity.EventReference dialogue13PlaceEventHere;
     public FMODUnity.EventReference dialogue14PlaceEventHere;
     public FMODUnity.EventReference dialogue15PlaceEventHere;

     bool dialogue1HasBeenPlayed = false;
     bool dialogue2HasBeenPlayed = false;
     bool dialogue3HasBeenPlayed = false;
     bool dialogue4HasBeenPlayed = false;
     bool dialogue5HasBeenPlayed = false;
     bool dialogue6HasBeenPlayed = false;
     bool dialogue7HasBeenPlayed = false;
     bool dialogue8HasBeenPlayed = false;
     bool dialogue9HasBeenPlayed = false;
     bool dialogue10HasBeenPlayed = false;
     bool dialogue11HasBeenPlayed = false;
     bool dialogue12HasBeenPlayed = false;
     bool dialogue13HasBeenPlayed = false;
     bool dialogue14HasBeenPlayed = false;
     bool dialogue15HasBeenPlayed = false;
     */

    [Header("Inventory sounds")]
    public FMODUnity.EventReference inventoryPlaceEventHere;
    public FMODUnity.EventReference clickPlaceEventHere;
    public FMODUnity.EventReference upgradePlaceEventHere;
    private FMOD.Studio.EventInstance inventoryInstance;
    private FMOD.Studio.EventInstance clickInstance;
    private FMOD.Studio.EventInstance upgradeInstance;

    

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

        StartCoroutine(Waiter(1));
    }
    // Update is called once per frame
    void Update()
    {
        Wind();
        
        //mute music
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            if (musicOn)
            {
                muteMusicSnapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/MuteMusic");
                muteMusicSnapshot.start();
                musicOn = false;
            }
            else if(!musicOn)
            {
                muteMusicSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                muteMusicSnapshot.release();
                musicOn = true;
            }
            
        }
        
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
        if (!thisDialogueHasBeenPlayed.Contains(dialogueNumber))
        {
            if (PlaybackState(dialogueInstance) == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            {
                dialogueInstance.release();
                thisDialogueHasBeenPlayed.Add(dialogueNumber);
                if (dialogueNumber == 4) DialogueVarManager.poddyFound = true;
                dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialoguePlaceEventHere[dialogueNumber - 1]);
                dialogueInstance.start();
                int actOneDialoguesPlayed = 0;
                for (int i = 1; i < 6; i++)
                {
                    if (thisDialogueHasBeenPlayed.Contains(i))
                    {
                        actOneDialoguesPlayed++;
                    }
                }
                if (actOneDialoguesPlayed == 5)
                {
                    DialogueVarManager.act1Finished = true;
                }
            }
            else
            {
                StartCoroutine(Waiter(dialogueNumber));
            }
        }
    }
    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }

    //test

    /*public void PlayDialogue(int dialogueNumber)
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
        else if (dialogueNumber == 6 && !dialogue6HasBeenPlayed)
        {
            dialogue6HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue6PlaceEventHere);
        }
        else if (dialogueNumber == 7 && !dialogue7HasBeenPlayed)
        {
            dialogue7HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue7PlaceEventHere);
        }
        else if (dialogueNumber == 8 && !dialogue8HasBeenPlayed)
        {
            dialogue8HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue8PlaceEventHere);
        }
        else if (dialogueNumber == 9 && !dialogue9HasBeenPlayed)
        {
            dialogue9HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue9PlaceEventHere);
        }
        else if (dialogueNumber == 10 && !dialogue10HasBeenPlayed)
        {
            dialogue10HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue10PlaceEventHere);
        }
        else if (dialogueNumber == 11 && !dialogue11HasBeenPlayed)
        {
            dialogue11HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue11PlaceEventHere);
        }
        else if (dialogueNumber == 12 && !dialogue12HasBeenPlayed)
        {
            dialogue12HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue12PlaceEventHere);
        }
        else if (dialogueNumber == 13 && !dialogue13HasBeenPlayed)
        {
            dialogue13HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue13PlaceEventHere);
        }
        else if (dialogueNumber == 14 && !dialogue14HasBeenPlayed)
        {
            dialogue14HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue14PlaceEventHere);
        }
        else if (dialogueNumber == 15 && !dialogue15HasBeenPlayed)
        {
            dialogue15HasBeenPlayed = true;
            dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(dialogue15PlaceEventHere);
        }

        dialogueInstance.start();
        dialogueInstance.release();
    }*/
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
    IEnumerator Waiter(int dialogueNum)
    {
        yield return new WaitForSeconds(1);
        PlayDialogue(dialogueNum);
    }
}
