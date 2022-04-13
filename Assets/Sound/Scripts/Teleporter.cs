using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //Jag behöver fixa en funktion för att sätta en temporär parameter så en one-shot kan komma utöver loop-eventet när spelaren teleporteras.

    public FMODUnity.EventReference placeTeleportHumEventHere;
    public FMODUnity.EventReference placeTeleportActionEventHere;
    private FMOD.Studio.EventInstance teleportHumInstance;
    private FMOD.Studio.EventInstance teleportActionInstance;
    public bool is3D = true;

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(teleportHumInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            teleportHumInstance = FMODUnity.RuntimeManager.CreateInstance(placeTeleportHumEventHere);
            teleportActionInstance = FMODUnity.RuntimeManager.CreateInstance(placeTeleportActionEventHere);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(teleportHumInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(teleportActionInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            teleportHumInstance.start();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            teleportHumInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            teleportHumInstance.release();
            teleportActionInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            teleportActionInstance.release();
        }
    }
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(teleportHumInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(teleportActionInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
    public void Action()
    {
        teleportActionInstance.start();
    }

}
