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
    public DisappearSound PlayAudio;
    
    void Start()
    {
        StartCoroutine(section1());
    }
    
    IEnumerator section1()
    {
        while (true)
        {
            platform1.SetActive(false);
            PlayAudio.PlayDisappearingSound();
            platform2.SetActive(true);
            PlayAudio.PlayAppearingSound();
            platform3.SetActive(false);
            PlayAudio.PlayDisappearingSound();
            platform4.SetActive(true);
            PlayAudio.PlayAppearingSound();
            yield return new WaitForSeconds(timer);
            platform1.SetActive(true);
            PlayAudio.PlayAppearingSound();
            platform2.SetActive(false);
            PlayAudio.PlayDisappearingSound();
            platform3.SetActive(true);
            PlayAudio.PlayAppearingSound();
            platform4.SetActive(false);
            yield return new WaitForSeconds(timer);
        }
    }
}
