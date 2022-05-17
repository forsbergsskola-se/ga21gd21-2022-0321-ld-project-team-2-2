using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherGameObject : MonoBehaviour
{
    public SelfDestruct Destroyer;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")Destroyer.SelfDestructCommand();
    }
}
