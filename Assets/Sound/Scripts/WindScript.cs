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
        myInstance.setParameterByName("WindAmt", 0f);
        for (; ; )
        {
            float windRandom = Random.Range(0f, 100f);
            WaitForSecondsRealtime(30);
            myInstance.setParameterByName("WindAmt", windRandom);
        }
    }
    public void WaitForSecondsRealtime(int time)
    {
        WaitForSecondsRealtime(time);

    }
    private void Update()
    {
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(myInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
}
