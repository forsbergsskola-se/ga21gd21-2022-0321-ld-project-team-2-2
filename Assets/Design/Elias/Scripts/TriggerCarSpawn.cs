using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCarSpawn : MonoBehaviour
{
    public Spawn Spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Spawn.Spawner();   
        }
    }
}
