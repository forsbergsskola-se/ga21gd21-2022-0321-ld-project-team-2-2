using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public FMODUnity.EventReference placeEventHere;
    private FMOD.Studio.EventInstance windInstance;
    public bool is3D = true;
    public int minDuration;
    public int maxDuration;
    private int weatherDuration;
    FMOD.Studio.PARAMETER_ID heightParam_ID;

    // Start is called before the first frame update
    void Start()
    {
        windInstance = FMODUnity.RuntimeManager.CreateInstance(placeEventHere);
        FMOD.Studio.EventDescription heightParam_EventDescription;
        windInstance.getDescription(out heightParam_EventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION heightParam_ParameterDescription;
        heightParam_EventDescription.getParameterDescriptionByName("Height", out heightParam_ParameterDescription);
        heightParam_ID = heightParam_ParameterDescription.id;


        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(windInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        windInstance.start();
        windInstance.setParameterByName("WindAmt", 0);
        weatherDuration = Random.Range(minDuration, maxDuration);
        StartCoroutine(Waiter(weatherDuration));

        IEnumerator Waiter(int seconds)
        {
            int windRandom = Random.Range(0, 100);
            yield return new WaitForSeconds(seconds);
            Debug.Log(windRandom);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("WindAmt", windRandom);
            weatherDuration = Random.Range(minDuration, maxDuration);
            StartCoroutine(Waiter(weatherDuration));
        }
    }
    private void Update()
    {
        if (is3D) FMODUnity.RuntimeManager.AttachInstanceToGameObject(windInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    public void HeightParam(float height)
    {
        windInstance.setParameterByID(heightParam_ID, height);
    }

}
