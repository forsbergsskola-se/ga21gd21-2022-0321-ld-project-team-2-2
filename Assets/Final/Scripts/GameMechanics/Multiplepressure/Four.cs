using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Four : MonoBehaviour
{
    public Manager Manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.four = true;
            //PlayAudio.PressurePlateDown();
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.four = false;
            //PlayAudio.PressurePlateUp();
        }
    }
}
