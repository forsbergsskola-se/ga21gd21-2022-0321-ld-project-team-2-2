using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public Animator door;
    public SoundManager SoundManager;

    public GameObject playerCam;
    public GameObject doorCam;

    public CinemachineVirtualCamera CinemachineVirtualCamera;
    
    public int keys;

    private void Start()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (keys == 5)
            {
                SoundManager.PlayKeycardUseSound(doorUnlocked: true);
                SoundManager.PlayBigDoorSound();
                StartCoroutine(OpenDoor());
            }
            else
            {
                SoundManager.PlayKeycardUseSound(doorUnlocked: false);
                SoundManager.PlayDialogue(9);
            }
        }
    }

    IEnumerator OpenDoor()
    {
        
        doorCam.SetActive(true);
        playerCam.SetActive(false);
        
        yield return new WaitForSeconds(2);
        door.SetBool("isOpen", true);
 
        ShakeCamera(intensity:2);

        yield return new WaitForSeconds(3);
        ShakeCamera(intensity:0);
        doorCam.SetActive(false);
        playerCam.SetActive(true);
    }

    public void ShakeCamera(float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
    public void AddKey()
    {
        keys++;
        SoundManager.SolvedPuzzleStinger();
        if (keys == 5) SoundManager.PlayDialogue(8);
    }
}
