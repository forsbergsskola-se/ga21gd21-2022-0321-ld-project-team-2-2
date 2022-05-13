using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool one;
    public bool two;
    public bool three;
    public bool four;
    
    [SerializeField] private GameObject oneOn;
    [SerializeField] private GameObject twoOn;
    [SerializeField] private GameObject threeOn;
    [SerializeField] private GameObject fourOn;
    [SerializeField] private GameObject oneOff;
    [SerializeField] private GameObject twoOff;
    [SerializeField] private GameObject threeOff;
    [SerializeField] private GameObject fourOff;
    void Update()
    {
        CheckLight();
        if (one && two && three && four)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = -50;
            gameObject.transform.position = newPosition;
            Destroy(gameObject);
        }
    }

    void CheckLight()
    {
        if (one)
        {
            oneOn.SetActive(true);
            oneOff.SetActive(false);
        }
        else
        {
            oneOff.SetActive(true);
            oneOn.SetActive(false);
        }
        if (two)
        {
            twoOn.SetActive(true);
            twoOff.SetActive(false);
        }
        else
        {
            twoOff.SetActive(true);
            twoOn.SetActive(false);
        }
        if (three)
        {
            threeOn.SetActive(true);
            threeOff.SetActive(false);
        }
        else
        {
            threeOff.SetActive(true);
            threeOn.SetActive(false);
        }
        if (four)
        {
            fourOn.SetActive(true);
            fourOff.SetActive(false);
        }
        else
        {
            fourOff.SetActive(true);
            fourOn.SetActive(false);
        }
    }
}
