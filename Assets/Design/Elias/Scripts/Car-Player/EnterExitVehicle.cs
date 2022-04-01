using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitVehicle : MonoBehaviour
{
    [SerializeField] private GameObject human = null;
    [SerializeField] private CheckInRange _checkInRange;
    
    [Header("Car")]
    [SerializeField] private GameObject car = null;
    [SerializeField] private CarController _carController = null;
    [SerializeField] private Animator carAnimator = null;

    [Header("Cameras")] 
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject carCamera;

    [Header("Input")]
    [SerializeField] private KeyCode enterExitKey = KeyCode.E;

    public bool inCar = false;

    // Start is called before the first frame update
    void Start()
    {
        inCar = car.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(enterExitKey))
        {
            if (inCar)
            {
                GetOutOfCar();
            }
            else if (_checkInRange.inRange)
            {
                GetIntoCar();
            }
        }
    }

    void GetOutOfCar()
    {
        inCar = false;
        human.SetActive(true);
        human.transform.position = car.transform.position + car.transform.TransformDirection(new Vector3(-2, 0, 0));

        carAnimator.enabled = false;
        playerCamera.SetActive(true);
        carCamera.SetActive(false);
        
        _carController.enabled = false;
    }

    void GetIntoCar()
    {
        inCar = true;
        
        human.SetActive(false);

        carAnimator.enabled = true;
        playerCamera.SetActive(false);
        carCamera.SetActive(true);

        _carController.enabled = true;
    }
}
