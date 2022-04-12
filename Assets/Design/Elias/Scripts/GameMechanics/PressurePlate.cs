using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public string TagFilter = "";
    public Animator door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagFilter))
        {
            door.SetBool("openDoor", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagFilter))
        {
            door.SetBool("openDoor", false);
        }
    }
}
