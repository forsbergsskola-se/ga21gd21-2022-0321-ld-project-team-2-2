using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public SoundManager DialoguePlayer;
    public DialogueManager DialogueVarManager;
    public int dialogueEvent;
    public EnterExitVehicle VehicleCheck;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            if (dialogueEvent >= 2 && dialogueEvent <= 4) DialoguePlayer.PlayDialogue(dialogueEvent);
            else if (dialogueEvent == 5 && DialogueVarManager.poddyFound) DialoguePlayer.PlayDialogue(dialogueEvent);
            else if ((dialogueEvent == 8) || (dialogueEvent == 9) && DialogueVarManager.act1Finished) DialoguePlayer.PlayDialogue(dialogueEvent);
        }
    }
}
