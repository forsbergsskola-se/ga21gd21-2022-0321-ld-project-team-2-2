using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public AudioObjectLoader AudioObjectLoader;
    public void SelfDestructCommand()
    {
        AudioObjectLoader.StopPlaying();
        Destroy(gameObject);
    }
}
