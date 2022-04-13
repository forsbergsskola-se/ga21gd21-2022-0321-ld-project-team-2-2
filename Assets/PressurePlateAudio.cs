using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateAudio : MonoBehaviour
{
    public FMODUnity.EventReference pressurePlateDownEvRef;
    private FMOD.Studio.EventInstance pressurePlateDownEvInst;
    public FMODUnity.EventReference pressurePlateUpEvRef;
    private FMOD.Studio.EventInstance pressurePlateUpEvInst;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(pressurePlateDownEvInst, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(pressurePlateUpEvInst, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    public void PressurePlateDown()
    {
        pressurePlateDownEvInst.start();
    }
    public void PressurePlateUp()
    {
        pressurePlateUpEvInst.start();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pressurePlateDownEvInst = FMODUnity.RuntimeManager.CreateInstance(pressurePlateDownEvRef);
            pressurePlateUpEvInst = FMODUnity.RuntimeManager.CreateInstance(pressurePlateUpEvRef);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(pressurePlateDownEvInst, GetComponent<Transform>(), GetComponent<Rigidbody>());
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(pressurePlateUpEvInst, GetComponent<Transform>(), GetComponent<Rigidbody>());
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressurePlateDownEvInst.release();
            pressurePlateUpEvInst.release();
        }
    }


}
