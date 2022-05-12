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
    public DisappearSound PlayAudio1;
    public DisappearSound PlayAudio2;
    public DisappearSound PlayAudio3;
    public DisappearSound PlayAudio4;

    void Start()
    {
        StartCoroutine(section1());
    }
    
    IEnumerator section1()
    {
        while (true)
        {
            platform1.SetActive(false);
            PlayAudio1.PlayDisappearingSound();
            platform2.SetActive(true);
            PlayAudio2.PlayAppearingSound();
            platform3.SetActive(false);
            PlayAudio3.PlayDisappearingSound();
            platform4.SetActive(true);
            PlayAudio4.PlayAppearingSound();
            yield return new WaitForSeconds(timer);
            platform1.SetActive(true);
            PlayAudio1.PlayAppearingSound();
            platform2.SetActive(false);
            PlayAudio2.PlayDisappearingSound();
            platform3.SetActive(true);
            PlayAudio3.PlayAppearingSound();
            platform4.SetActive(false);
            PlayAudio4.PlayDisappearingSound();
            yield return new WaitForSeconds(timer);
        }
    }
}
