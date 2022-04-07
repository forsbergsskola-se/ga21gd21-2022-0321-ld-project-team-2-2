using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPickUp : MonoBehaviour
{
    public FMODUnity.EventReference placeEventHere;
    private FMOD.Studio.EventInstance scrapPickupInstance;
    public bool is3D = false;
    // Start is called before the first frame update
    void Start()
    {
        scrapPickupInstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(scrapPickupInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    public void PickUpSound()
    {
        scrapPickupInstance.start();
    }
}
