using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitVehicle : MonoBehaviour
{
    [SerializeField] private GameObject human = null;
    [SerializeField] private GameObject car = null;
    [SerializeField] private CarController _carController = null;
    [SerializeField] private Animator carAnimator = null;
    [SerializeField] private Transform enterCar;
    public LayerMask vehicles;

    [Header("Cameras")] 
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject carCamera;

    [Header("Input")]
    [SerializeField] private KeyCode enterExitKey = KeyCode.E;
    
    [SerializeField] float closeDistance = 2f;

    private bool inCar = false;

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
            else if (CarNearby())
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

    private bool CarNearby()
    {
        Collider[] cols = Physics.OverlapSphere(human.transform.position, closeDistance);
        if (Physics.CheckSphere(human.transform.position, closeDistance, vehicles))
        {
            return true;
        }
        /*foreach (var entCar in cols)
        {
            if (entCar.CompareTag("Vehicle"))
            {
                return true;
            }
        }*/
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(human.transform.position, closeDistance);
    }
}
