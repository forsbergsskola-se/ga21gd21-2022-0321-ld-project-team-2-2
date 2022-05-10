using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScrap : MonoBehaviour
{
    private Currency _Currency;
    private GameObject gameManager;
    public SoundManager Manager;
    public int itemCurrency = 5;

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
            Manager.PickUpSound();
            _Currency.currencyCollected += itemCurrency;
            _Currency.AddScrap();
            Destroy(gameObject);
        }
    }
}
