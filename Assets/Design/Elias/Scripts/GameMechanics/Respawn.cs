using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public string TagFilter = "";
    [Header("Object to teleport")]
    public GameObject objToTp;
    [Header("Where to teleport")]
    public Transform tpLoc;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagFilter))
        {
            objToTp.transform.position = tpLoc.transform.position;
        }
    }
}
