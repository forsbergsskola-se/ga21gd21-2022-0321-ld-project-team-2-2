using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    #region Variables

    public EnterExitVehicle _EnterExit;
    public SoundManager DialogueManager;
    private bool radioOn = true;//Might have to make public
    int RadioStation = 1;
    private FMOD.Studio.EventInstance instance;
    bool radioFirstTime = true;
    public int secondsBeforeRadioStartsFirstTime = 3;
    [SerializeField] private float radioWait = 3;

    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_EnterExit.inCar)
        {
            TurnOn();
        }
        if (_EnterExit.inCar && Input.GetKeyDown(KeyCode.V))
        {
            radioOn = !radioOn;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Radio/ChangeChannel");
        }

        if (_EnterExit.inCar == false)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RadioOnOff",0);
        }
    }

    void TurnOn()
    {
        if (radioFirstTime)
        {
            StartCoroutine(RadioFirstTime());
        }
        
        if (radioOn)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RadioOnOff", 1);
            ChangeStation();
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RadioOnOff",0);
        }
    }
    
    void ChangeStation()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)//FWD
        {
            RadioStation++;

            if (RadioStation == 4)
            {
                RadioStation = 1;
            }

            FMODUnity.RuntimeManager.PlayOneShot("event:/Radio/ChangeChannel");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SwitchChannel", RadioStation);
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)//BWD
        {
            Debug.Log("RadioStation+");
            RadioStation--;
            if (RadioStation == 0)
            {
                RadioStation = 3;
            }
            FMODUnity.RuntimeManager.PlayOneShot("event:/Radio/ChangeChannel");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SwitchChannel", RadioStation);
        }
    }

    IEnumerator RadioFirstTime()
    {
        DialogueManager.PlayDialogue(6);
        yield return new WaitForSeconds(radioWait);
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Radio/Radio");
        instance.start();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RadioOnOff", 0);
        radioFirstTime = false;
    }    
}
