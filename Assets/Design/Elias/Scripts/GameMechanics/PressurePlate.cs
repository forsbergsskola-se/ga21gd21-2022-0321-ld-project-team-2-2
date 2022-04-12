using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            //Play animation
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            //Stop animation
        }
    }
}
