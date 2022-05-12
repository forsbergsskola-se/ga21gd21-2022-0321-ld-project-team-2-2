using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadOne : MonoBehaviour
{
    public PadManager Manager;
    public PressurePlateAudio PlayAudio;

    [SerializeField] private bool ett;
    [SerializeField] private bool tva;
    [SerializeField] private bool tre;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (ett)
            {
                Manager.one = true;
                PlayAudio.PressurePlateDown();  
            }
            else if (tva)
            {
                Manager.two = true;
                PlayAudio.PressurePlateDown(); 
            }
            else if (tre)
            {
                Manager.three = true;
                PlayAudio.PressurePlateDown(); 
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (ett)
            {
                Manager.one = false;
                PlayAudio.PressurePlateUp(); 
            }
            else if (tva)
            {
                Manager.two = false;
                PlayAudio.PressurePlateUp();
            }
            else if (tre)
            {
                Manager.three = false;
                PlayAudio.PressurePlateUp();
            }
        }
    }
}
