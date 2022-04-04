using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScrap : MonoBehaviour
{
    public Currency _Currency;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _Currency.AddScrap();
            Destroy(gameObject);
        }
    }
}
