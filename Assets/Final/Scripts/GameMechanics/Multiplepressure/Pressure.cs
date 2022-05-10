using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : MonoBehaviour
{
    public Manager Manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.one = true;
            //PlayAudio.PressurePlateDown();
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Manager.one = false;
            //PlayAudio.PressurePlateUp();
        }
    }
}
