using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public string TagFilter = "";
    public Animator door;
    public PressurePlateAudio PlayAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagFilter))
        {
            PlayAudio.PressurePlateDownAudio();
            door.SetBool("openDoor", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagFilter))
        {
            PlayAudio.PressurePlateUpAudio();
            door.SetBool("openDoor", false);
        }
    }

}
