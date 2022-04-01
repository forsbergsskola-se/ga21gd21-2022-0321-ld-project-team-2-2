using UnityEngine;

public class CheckInRange : MonoBehaviour
{
    public bool inRange;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
}