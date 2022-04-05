using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public FMODUnity.EventReference placeEventHere;
    private FMOD.Studio.EventInstance myInstance;
    public bool is3D = true;
    // Start is called before the first frame update
    void Start()
    {
        myInstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        myInstance.start();
        myInstance.setParameterByName("WindAmt", 0);
        StartCoroutine(Waiter());

        IEnumerator Waiter()
        {
            for (; ; )
            {
            int windRandom = Random.Range(0, 100);
            yield return new WaitForSeconds(20);
            Debug.Log(windRandom);
            myInstance.setParameterByName("WindAmt", windRandom);
            }
        }
    }
    
    private void Update()
    {
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
}
