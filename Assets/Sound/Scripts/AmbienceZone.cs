using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceZone : MonoBehaviour
{
    public SoundManager SoundBuddy;
    public EnterExitVehicle VehicleCheck;
    public DialogueManager DialogueVarManager;
    /*FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InDesert", zone == 1 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InStartingArea", zone == 2 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InLake", zone == 3 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InMountains", zone == 4 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InValley", zone == 5 ? 1 : 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InRuins", zone == 6 ? 1 : 0);*/
    [Header("Desert = 1, Starting Area = 2, Lake = 3, Mountains = 4, Valley = 5, Ruins = 6")]
    public int ambienceZone;
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
            SoundBuddy.SetAmbienceZone(ambienceZone);
            if (ambienceZone == 1 && DialogueVarManager.act1Finished == true)
            {
                SoundBuddy.PlayDialogue(6);
            }
            if (ambienceZone == 4 && DialogueVarManager.act1Finished == true)
            {
                SoundBuddy.PlayDialogue(7);
            }
        }
        
    }
}