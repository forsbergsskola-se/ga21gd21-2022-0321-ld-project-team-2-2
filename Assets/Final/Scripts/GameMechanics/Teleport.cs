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
    public SoundManager TeleportPlayerSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagFilter))
        {
            objToTp.transform.position = tpLoc.transform.position;
            if (TagFilter == "Player") TeleportPlayerSound.PlayTeleportedPlayerSound();
            else TeleportSound.Action();
        }
    }
}
