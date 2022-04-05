using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Object to teleport")]
    public GameObject objToTp;
    [Header("Where to teleport")]
    public Transform tpLoc;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objToTp.transform.position = tpLoc.transform.position;
        }
    }
}
