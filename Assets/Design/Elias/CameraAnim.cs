using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    public Animator door;

    public Animator camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            door.SetBool("isOpen", true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            camera.SetBool("move", true);
        }
    }
}
