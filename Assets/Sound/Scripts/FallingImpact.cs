using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingImpact : MonoBehaviour
{
    public FMODUnity.EventReference impactPlaceEventHere;
    private FMOD.Studio.EventInstance impactInstance;
    private bool impactIs3D = false;
    public float velocityThresholdObject;
    public float velocityThresholdPlayer;
    private float thresholdVal;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            impactIs3D = false;
            thresholdVal = velocityThresholdPlayer;
        }
        else
        {
            impactIs3D = true;
            thresholdVal = velocityThresholdObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > thresholdVal)
        {
            Debug.Log("Play Impact Sound " + collision.relativeVelocity.magnitude);
            impactInstance = FMODUnity.RuntimeManager.CreateInstance(impactPlaceEventHere);
            impactInstance.setParameterByName("Velocity", collision.relativeVelocity.magnitude);
            if (impactIs3D) impactInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            impactInstance.start();
            impactInstance.release();
        }
    }
}
