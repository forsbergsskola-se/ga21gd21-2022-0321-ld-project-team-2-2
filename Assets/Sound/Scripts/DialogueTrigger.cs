using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public SoundManager DialogueManager;
    public int dialogueEvent;
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
       if (other.tag == "Player")
       {
            DialogueManager.PlayDialogue(dialogueEvent);
       }
       else if (other.tag == "Vehicle")
        {
            DialogueManager.PlayDialogue(dialogueEvent);
        }

    }
}
