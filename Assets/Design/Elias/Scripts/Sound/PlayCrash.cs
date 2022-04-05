using UnityEngine;

public class PlayCrash : MonoBehaviour
{
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Vehicle/VehicleCollide");
    }
}
