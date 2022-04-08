using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    /*
     In the script that controls the player, you could add the following to have a layer that follows PlayerHealth:

    public MusicController mc; -< dra in scriptet här :) SÅ kan man referera till olika scripts 

    int playerHealth = 100;

    public void damagePlayer(int _amt)
    {
    playerHealth -= _amt;
    Debug.Log("Player Health: " + playerHealth)
    
    Another script with DamageController
    */
    public FMODUnity.EventReference musicEvRef;
    private FMOD.Studio.EventInstance musicEvInst;
    void Start()
    {
        musicEvInst = FMODUnity.RuntimeManager.CreateInstance(musicEvRef);
        musicEvInst.start();
    }

    public void ChangeMusicHealthParam(int _val)
    {

    }

    void Update()
    {
        
    }
}
