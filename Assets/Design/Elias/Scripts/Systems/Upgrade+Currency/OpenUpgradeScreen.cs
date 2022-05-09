using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeScreen : MonoBehaviour
{
    public KeyCode interact = KeyCode.E;
    [SerializeField] private PlayerMovement controller;
    [SerializeField] private Animator animator;
    [SerializeField] private OpenInventory _inventory;

    [Header("Cameras")] 
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject inventoryCamera;
    
    [Header("UI")] 
    [SerializeField] private GameObject ui;

    [SerializeField] private GameObject speed1;
    [SerializeField] private GameObject speed2;
    [SerializeField] private GameObject speed3;
    [SerializeField] private GameObject nitro;
    
    
    private bool inMenu = false;
    
    void Update()
    {
        UIFollow();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(interact))
        {
            if (inMenu)
            {
                controller.enabled = true;
                playerCamera.SetActive(true);
                inventoryCamera.SetActive(false);
                _inventory.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                
                ui.SetActive(false);
            }
            else
            {
                controller.enabled = false;
                inventoryCamera.SetActive(true);
                playerCamera.SetActive(false);
                animator.SetBool("isWalking", false);
                _inventory.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                
                ui.SetActive(true);
            }
            inMenu = !inMenu;
        }
    }

    void UIFollow()
    {
        ui.transform.position = transform.position + new Vector3(5, 3, 1);
    }

    public void Speed1()
    {
        
    }
}
