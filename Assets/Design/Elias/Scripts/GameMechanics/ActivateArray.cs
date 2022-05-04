using UnityEngine;

public class ActivateArray : MonoBehaviour
{
    [SerializeField] 
    public MovingPlatform[] Platforms;

    public PressurePlateAudio PlayAudio;

    private void Start()
    {
        //Platforms = gameObject.GetComponentsInChildren<MovingPlatform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Player"))
        {
            foreach (var t in Platforms)
            {
                t.enabled = true;
            }

            //PlayAudio.PressurePlateDown();
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Player"))
        {
            foreach (var t in Platforms)
            {
                t.enabled = false;
            }

            //PlayAudio.PressurePlateUp();
        }
    }
}
