using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCarSpawn : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Doneeeee");
            car.SetActive(true);   
        }
    }
}
