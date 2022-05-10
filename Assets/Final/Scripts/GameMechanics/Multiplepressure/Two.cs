using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{
    public Manager Manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.two = true;
            //PlayAudio.PressurePlateDown();
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.two = false;
            //PlayAudio.PressurePlateUp();
        }
    }
}
