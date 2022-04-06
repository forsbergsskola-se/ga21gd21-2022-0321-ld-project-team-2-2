using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //Jag beh�ver fixa en funktion f�r att s�tta en tempor�r parameter s� en one-shot kan komma ut�ver loop-eventet n�r spelaren teleporteras.

    public FMODUnity.EventReference placeEventHere;
    private FMOD.Studio.EventInstance myInstance;
    public bool is3D = true;

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        myInstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        myInstance.start();
    }
    private void OnTriggerExit(Collider other)
    {
        myInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        myInstance.release();
    }
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
    public void Action()
    {
        myInstance.setParameterByName("TeleportAction", 1f);
    }

}
