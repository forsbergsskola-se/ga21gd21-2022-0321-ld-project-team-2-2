using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator door;
    public PressurePlateAudio PlayAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            door.SetBool("openDoor", true);
            PlayAudio.PressurePlateDown();           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            door.SetBool("openDoor", false);
            PlayAudio.PressurePlateUp();            
        }
    }

}
