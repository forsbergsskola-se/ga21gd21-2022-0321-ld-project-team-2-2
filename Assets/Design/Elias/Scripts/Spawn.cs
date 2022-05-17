using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject toSpawn;

    public void Spawner()
    {
        toSpawn.SetActive(true);
    }
}
