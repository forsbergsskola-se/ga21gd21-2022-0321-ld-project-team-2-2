using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public KeyCode inventoryKey = KeyCode.Tab;
    [SerializeField] private PlayerMovement controller;

    [Header("Cameras")] 
    public GameObject playerCamera;
    public GameObject inventoryCamera;

    [Header("UI")] 
    public GameObject ui;
    
    [Header("Lerp")]
    public Transform player;

    [Header("Inventory sounds")]
    public FMODUnity.EventReference openInventoryPlaceEventHere;
    public FMODUnity.EventReference closeInventoryPlaceEventHere;
    public FMODUnity.EventReference clickPlaceEventHere;
    private FMOD.Studio.EventInstance openInventoryInstance;
    private FMOD.Studio.EventInstance closeInventoryInstance;
    private FMOD.Studio.EventInstance clickInstance;

    private Vector3 pointA;
    private Vector3 pointB;
    private float a = 0.5f;
    
    private bool inInventory = false;


    // Update is called once per frame
    private void Start()
    {
        openInventoryInstance = FMODUnity.RuntimeManager.CreateInstance(openInventoryPlaceEventHere);
        closeInventoryInstance = FMODUnity.RuntimeManager.CreateInstance(closeInventoryPlaceEventHere);
        clickInstance = FMODUnity.RuntimeManager.CreateInstance(clickPlaceEventHere);
    }
    void Update()
    {
        UIFollow();
        if (Input.GetKeyDown(inventoryKey))
        {
            if (inInventory)
            {
                closeInventoryInstance.start();
                controller.enabled = true;
                playerCamera.SetActive(true);
                inventoryCamera.SetActive(false);
                
                ui.SetActive(false);
            }
            else
            {
                openInventoryInstance.start();
                controller.enabled = false;
                inventoryCamera.SetActive(true);
                playerCamera.SetActive(false);
                //Enable mouse
                
                ui.SetActive(true);
            }
            inInventory = !inInventory;
        }
    }

    void UIFollow()
    {
        pointA = player.position;
        pointB = player.position + player.transform.TransformDirection(new Vector3(4.5f, 1, 4.5f));

        ui.transform.position = Vector3.Lerp(pointA, pointB, a);
        
        ui.transform.LookAt(inventoryCamera.transform);
        ui.transform.Rotate(0, 180, 0);
    }
}
