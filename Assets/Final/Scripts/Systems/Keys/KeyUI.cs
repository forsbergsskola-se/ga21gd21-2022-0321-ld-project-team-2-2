using System;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    [SerializeField] private bool keyValley;
    [SerializeField] private bool keyMountain;
    [SerializeField] private bool keyRuins;
    [SerializeField] private bool keyCrevice;
    [SerializeField] private bool keyToe;

    [SerializeField] private GameObject textOne;
    [SerializeField] private GameObject textOneDone;
    [SerializeField] private GameObject textTwo;
    [SerializeField] private GameObject textTwoDone;
    [SerializeField] private GameObject textThree;
    [SerializeField] private GameObject textThreeDone;
    [SerializeField] private GameObject textFour;
    [SerializeField] private GameObject textFourDone;
    [SerializeField] private GameObject textFive;
    [SerializeField] private GameObject textFiveDone;

    private void OnTriggerEnter(Collider other)
    {
        if (keyValley)
        {
            textOne.SetActive(false);
            textOneDone.SetActive(true);
        }
        else if (keyMountain)
        {
            textTwo.SetActive(false);
            textTwoDone.SetActive(true);
        }
        else if (keyRuins)
        {
            textThree.SetActive(false);
            textThreeDone.SetActive(true);
        }
        else if (keyCrevice)
        {
            textFour.SetActive(false);
            textFourDone.SetActive(true);
        }
        else if (keyToe)
        {
            textFive.SetActive(false);
            textFiveDone.SetActive(true);
        }
    }
}
