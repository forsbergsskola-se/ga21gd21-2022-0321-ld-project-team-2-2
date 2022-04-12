using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Height Check")] 
    public Transform player;
    public Transform car;
    public WindScript WindHeightController;

    private float height;
    public EnterExitVehicle _EnterExit;
    
    [Header("Scrap")]
    public FMODUnity.EventReference scrapPlaceEventHere;
    private FMOD.Studio.EventInstance scrapPickupInstance;
    private bool scrapIs3D = false;
    
    [Header("Footsteps")]
    public FMODUnity.EventReference footPlaceEventHere;
    private FMOD.Studio.EventInstance myInstance;
    private bool footIs3D = false;

    [Header("Music")]
    public FMODUnity.EventReference musicEvRef;
    private FMOD.Studio.EventInstance musicEvInst;
    bool stinger1Played = false;

    // Start is called before the first frame update
    void Start()
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(musicEvRef);
        //music
        musicEvInst.start();
        //Scrap Pickup
        scrapPickupInstance = FMODUnity.RuntimeManager.CreateInstance(scrapPlaceEventHere);
        if (scrapIs3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(scrapPickupInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        
        //Footsteps
        myInstance = FMODUnity.RuntimeManager.CreateInstance(footPlaceEventHere);
        if (footIs3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());

    }

    // Update is called once per frame
    void Update()
    {
        Wind();
        
        //Footsteps
        if(footIs3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    void Wind()
    {
        if (_EnterExit.inCar)
        {
            height = car.position.y;
            WindHeightController.HeightParam(height);
        }
        else
        {
            height = player.position.y;
            WindHeightController.HeightParam(height);
        }
    }
    public void PickUpSound()
    {
        scrapPickupInstance.start();
    }
    public void Move()
    {
        myInstance.start();
    }
    public void StopMoving()
    {
        myInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void FadeMusic()
    {
        musicEvInst.setParameterByName("InCar", 1f);
    }
    public void FadeInMusic()
    {
        musicEvInst.setParameterByName("InCar", 0);
    }
    public void MusicStinger1()
    {
        if (!stinger1Played)
        musicEvInst.setParameterByName("Stinger1", 1);
        stinger1Played = true;
    }
}
