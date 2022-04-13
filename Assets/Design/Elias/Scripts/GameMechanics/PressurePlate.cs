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
            PlayAudio.PressurePlateDown();
            door.SetBool("openDoor", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            PlayAudio.PressurePlateUp();
            door.SetBool("openDoor", false);
        }
    }

}
