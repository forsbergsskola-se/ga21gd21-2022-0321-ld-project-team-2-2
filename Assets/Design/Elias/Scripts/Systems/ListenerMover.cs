using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerMover : MonoBehaviour
{
    [Header("Location Reference")] 
    public Transform player;
    public Transform car;
    public GameObject listener;

    public GameObject playCam;
    public GameObject carCam;
    
    public EnterExitVehicle _EnterExit;

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 pointC;
    private float a = 0.5f;

    void Update()
    {
        if (_EnterExit.inCar)
        {
            pointA = car.position;
            pointB = carCam.transform.position;
            
            listener.transform.position = Vector3.Lerp(pointA, pointB, a);
        }
        else
        {
            pointA = player.position;
            pointB = playCam.transform.position;

            listener.transform.position = Vector3.Lerp(pointA, pointB, a);
        }
    }
}
