using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Location Reference")] 
    public Transform player;
    public Transform car;

    public EnterExitVehicle _EnterExit;

    private float height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Wind();
    }

    void Wind()
    {
        if (_EnterExit.inCar)
        {
            height = car.position.y;
        }
        else
        {
            height = player.position.y;
        }
    }
}
