using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadManager : MonoBehaviour
{
    public bool one;
    public bool two;
    public bool three;

    public GameObject key;
    public GameObject teleport;

    // Update is called once per frame
    void Update()
    {
        if (one && two && three)
        {
            key.SetActive(true);
            teleport.SetActive(true);
        }
    }
}
