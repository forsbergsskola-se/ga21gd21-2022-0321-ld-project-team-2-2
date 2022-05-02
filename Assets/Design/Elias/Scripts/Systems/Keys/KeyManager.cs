using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int keys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey()
    {
        keys++;
    }

    public void OpenDoor()
    {
        if (keys == 5)
        {
            //open door/play animation
        }
        else
        {
            //Play clip of poddy saying no bueno
        }
    }
}
