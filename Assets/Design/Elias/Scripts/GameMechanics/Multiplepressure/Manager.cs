using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool one;
    public bool two;
    public bool three;
    public bool four;
    
    void Update()
    {
        if (one && two && three && four)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = -50;
            gameObject.transform.position = newPosition;
        }
    }
}
