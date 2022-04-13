using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    public string TagFilter = "";
    [Header("Object to teleport")]
    public GameObject objToTp;
    [Header("Where to teleport")]
    public Transform tpLoc;
    public Teleporter TeleportSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagFilter))
        {
            TeleportSound.Action();
            objToTp.transform.position = tpLoc.transform.position;
        }
    }
}
