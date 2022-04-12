using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;
    [SerializeField] private GameObject platform3;
    [SerializeField] private GameObject platform4;
    [SerializeField] private int timer;
    
    void Start()
    {
        StartCoroutine(section1());
    }
    
    IEnumerator section1()
    {
        while (true)
        {
            platform1.SetActive(false);
            platform2.SetActive(true);
            platform3.SetActive(false);
            platform4.SetActive(true);
            yield return new WaitForSeconds(timer);
            platform1.SetActive(true);
            platform2.SetActive(false);
            platform3.SetActive(true);
            platform4.SetActive(false);
            yield return new WaitForSeconds(timer);
        }
    }
}
