using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerMover : MonoBehaviour
{
    [Header("Location Reference")] 
    public Transform player;
    public Transform car;
    private GameObject listener;

    public EnterExitVehicle _EnterExit;

    void Update()
    {
        if (_EnterExit.inCar)
        {
            listener.transform.position = car.transform.position;
        }
        else
        {
            listener.transform.position = player.transform.position;
        }
    }
}
