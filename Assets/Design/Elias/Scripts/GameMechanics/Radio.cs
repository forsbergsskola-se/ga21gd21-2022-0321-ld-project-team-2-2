using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

    #region Variables

    public EnterExitVehicle _EnterExit;
    private bool radioOn;//Might have to make public
    int RadioStation = 1;
    private FMOD.Studio.EventInstance instance;

    #endregion

   
    instance = FMODUnity.RuntimeManager.CreateInstance("event:/Radio");

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_EnterExit.inCar)
        {
            TurnOn();
            TurnOff();

        }
        if (_EnterExit.inCar && Input.GetKeyDown(KeyCode.V))
        {
            radioOn = !radioOn;
        }
    }

    void TurnOn()
    {
        if (radioOn)
        {
            instance.start();
            ChangeStation();//Start music

        }
    }

    void TurnOff()
    {
        if (radioOn == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/ChangeChannel");
            //Stop music
        }
    }

    void ChangeStation()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)//FWD
        {

            RadioStation++;
            FMODUnity.RuntimeManager.PlayOneShot("event:/ChangeChannel");

            if (RadioStation == 4)
            {
                RadioStation = 1;

            }
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)//BWD
        {
            RadioStation--;
            FMODUnity.RuntimeManager.PlayOneShot("event:/ChangeChannel");

            if (RadioStation == 0)
            {

                RadioStation = 3;
            }
        }
    }
}
