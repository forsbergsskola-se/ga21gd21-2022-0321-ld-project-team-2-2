using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeScreen : MonoBehaviour
{
    #region Variables

    public KeyCode interact = KeyCode.E;
    
    [Header("Components")]
    [SerializeField] private PlayerMovement controller;
    [SerializeField] private Animator animator;
    [SerializeField] private OpenInventory _inventory;
    [SerializeField] private CarController _carController;
    [SerializeField] private Currency _currency;

    [Header("Cameras")] 
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject inventoryCamera;
    
    [Header("UI")] 
    [SerializeField] private GameObject ui;

    [SerializeField] private GameObject speed1;
    [SerializeField] private GameObject speed2;
    [SerializeField] private GameObject speed3;
    [SerializeField] private GameObject nitro;
    [SerializeField] private GameObject purchase;
    
    private bool one;
    private bool two;
    private bool three;
    private bool four;
    
    //Bought
    private bool boughtOne;
    private bool boughtTwo;
    private bool boughtThree;
    private bool boughtFour;

    private bool inMenu = false;

    #endregion
    
    void Update()
    {
        UIFollow();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(interact))
        {
            if (inMenu && Input.GetKeyDown(interact))
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
                Speed1();
            }
            inMenu = !inMenu;
        }
    }

    void UIFollow()
    {
        ui.transform.position = transform.position + new Vector3(5, 3, 1);
    }

    #region Buttons

    public void Speed1()
    {
        //Press button sound
        one = true;
        two = false;
        three = false;
        four = false;
        
        speed1.SetActive(true);
        speed2.SetActive(false);
        speed3.SetActive(false);
        nitro.SetActive(false);
        if (boughtOne)
        {
            purchase.SetActive(false);
        }
        else
        {
            purchase.SetActive(true);
        }
    }
    public void Speed2()
    {
        //Press button sound
        one = false;
        two = true;
        three = false;
        four = false;
        
        speed1.SetActive(false);
        speed2.SetActive(true);
        speed3.SetActive(false);
        nitro.SetActive(false);
        if (boughtTwo)
        {
            purchase.SetActive(false);
        }
        else
        {
            purchase.SetActive(true);
        }
    }
    public void Speed3()
    {
        //Press button sound
        one = false;
        two = false;
        three = true;
        four = false;
        
        speed1.SetActive(false);
        speed2.SetActive(false);
        speed3.SetActive(true);
        nitro.SetActive(false);
        if (boughtThree)
        {
            purchase.SetActive(false);
        }
        else
        {
            purchase.SetActive(true);
        }
    }
    public void Nitro()
    {
        //Press button sound
        one = false;
        two = false;
        three = false;
        four = true;
        
        speed1.SetActive(false);
        speed2.SetActive(false);
        speed3.SetActive(false);
        nitro.SetActive(true);
        if (boughtFour)
        {
            purchase.SetActive(false);
        }
        else
        {
            purchase.SetActive(true);
        }
    }


    #endregion
    
    public void Purchase()
    {
        if (one)
        {
            if (_currency.currencyCollected >= 100)
            {
                _carController.fwdSpeed += 50;
                _currency.currencyCollected -= 100;
                boughtOne = true;
                //Do good sound
            }
            else
            {
                //Do bad sound
            }
        }
        else if (two)
        {
            if (_currency.currencyCollected >= 250)
            {
                _carController.fwdSpeed += 50;
                _currency.currencyCollected -= 250;
                boughtTwo = true;
                //Do good sound
            }
            else
            {
                //Do bad sound
            }
        }
        else if (three)
        {
            if (_currency.currencyCollected >= 500)
            {
                _carController.fwdSpeed += 50;
                _currency.currencyCollected -= 500;
                boughtThree = true;
                //Do good sound
            }
            else
            {
                //Do bad sound
            }
        }
        else if (four)
        {
            if (_currency.currencyCollected >= 500)
            {
                _carController.nitroUnlock = true;
                _currency.currencyCollected -= 500;
                boughtFour = true;
                //Do good sound
            }
            else
            {
                //Do bad sound
            }
        }
    }
}
