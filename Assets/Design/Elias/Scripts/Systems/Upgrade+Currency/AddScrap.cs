using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScrap : MonoBehaviour
{
    private Currency _Currency;
    private GameObject gameManager;
    public ScrapPickUp scrapSound;

    private void Start()
    {
        #region Input

        gameManager = GameObject.Find("GameManager");
        _Currency = gameManager.GetComponent<Currency>();

        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scrapSound.PickUpSound();
            _Currency.AddScrap();
            Destroy(gameObject);
        }
    }
}
