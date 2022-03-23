using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        CheckPlayerDamage();
    }

    void CheckPlayerDamage()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
