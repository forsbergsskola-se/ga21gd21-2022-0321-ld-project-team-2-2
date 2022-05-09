using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStingerTrigger : MonoBehaviour
{
    public SoundManager MusicTriggers;
    public EnterExitVehicle VehicleCheck;
    public int musicalStinger = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Vehicle" && VehicleCheck.inCar))
        {
            MusicTriggers.MusicStinger(musicalStinger);
        }
    }

}
