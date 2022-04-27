using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeScreen : MonoBehaviour
{
    public KeyCode interact = KeyCode.E;
    [SerializeField] private PlayerMovement controller;

    [Header("Cameras")] 
    public GameObject playerCamera;
    public GameObject inventoryCamera;
    
    [Header("UI")] 
    public GameObject ui;
    
    private bool inMenu = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIFollow();
        if (Input.GetKeyDown(interact))
        {
            if (inMenu)
            {
                controller.enabled = true;
                playerCamera.SetActive(true);
                inventoryCamera.SetActive(false);
                
                ui.SetActive(false);
            }
            else
            {
                controller.enabled = false;
                inventoryCamera.SetActive(true);
                playerCamera.SetActive(false);
                //Enable mouse
                
                ui.SetActive(true);
            }
            inMenu = !inMenu;
        }
    }

    void UIFollow()
    {      
        ui.transform.position = new Vector3(1, 2);
    }
}
