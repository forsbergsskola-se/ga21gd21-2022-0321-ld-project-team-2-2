using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    #region Variables

    public EnterExitVehicle _EnterExit;
    private bool radioOn;//Might have to make public
    private float radioStation = 1f;

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
            ChangeStation();
            //Start music
        }
    }

    void TurnOff()
    {
        if (radioOn == false)
        {
            //Stop music
        }
    }

    void ChangeStation()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)//FWD
        {
            radioStation++;
            if (radioStation == 4f)
            {
                radioStation = 1f;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)//BWD
        {
            radioStation--;
            if (radioStation == 0f)
            {
                radioStation = 3f;
            }
        }
    }
}
