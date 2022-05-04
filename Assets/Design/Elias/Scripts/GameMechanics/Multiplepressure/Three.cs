using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three : MonoBehaviour
{
    public Manager Manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.three = true;
            //PlayAudio.PressurePlateDown();
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.three = false;
            //PlayAudio.PressurePlateUp();
        }
    }
}
