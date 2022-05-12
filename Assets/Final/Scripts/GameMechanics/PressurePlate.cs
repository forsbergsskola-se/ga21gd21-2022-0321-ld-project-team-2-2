using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    public PressurePlateAudio PlayAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            door.SetActive(false);
            PlayAudio.PressurePlateDown();           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            door.SetActive(true);
            PlayAudio.PressurePlateUp();            
        }
    }
}
