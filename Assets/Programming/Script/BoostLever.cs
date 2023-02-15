using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostLever : MonoBehaviour
{
    public Progress progress;
    public Pressure[] pressure;
    public EngineManager[] coal;
    public EngineManager[] water;
    public BreakGear gear;

    public float minimunCoalAmountToUse = 30f;
    public float minimunWaterAmountToUse = 30f;
    public float minimunSteamAmountToUse = 30f;
    public float maximinSteamAmountToUse = 80f;

    public float decreaseSpeedCoal;
    public float decreaseSpeedWater;
    public float increaseSpeedSteam;
    public float increaseSpeedProgress;

    private bool goBack;
    Quaternion originalPos;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        var z = transform.localEulerAngles.z;

        if(CheckCoalLevel() && CheckWaterLevel() && CheckPressureLevel())
        {
            if (z >= 15)
            {
                foreach (EngineManager obj in coal)
                {
                    obj.coalLevel -= decreaseSpeedCoal;
                }
                foreach (EngineManager obj in water)
                {
                    obj.waterLevel -= decreaseSpeedWater;
                }

                foreach (Pressure obj in pressure)
                {
                    obj.sPressure += increaseSpeedSteam;
                }

                progress.speed = increaseSpeedProgress;
            }
        }
   
        if (goBack == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, Time.time * speed);
        }

        if (originalPos == transform.rotation)
            goBack = false;
    }

    private bool CheckCoalLevel()
    {
        foreach (EngineManager obj in coal)
        {
            if (obj.coalLevel >= minimunCoalAmountToUse)
            {
                return true;
            }
            else
            {
                break;
            }
        }

        return false;
    }

    private bool CheckWaterLevel()
    {
        foreach (EngineManager obj in water)
        {
            if (obj.waterLevel >= minimunWaterAmountToUse)
            {
                return true;
            }
            else
            {
                break;
            }
        }

        return false;
    }

    private bool CheckPressureLevel()
    {
        foreach (Pressure obj in pressure)
        {
            if (obj.sPressure >= minimunSteamAmountToUse && obj.sPressure <= maximinSteamAmountToUse)
            {
                return true;
            }
            else
            {
                break;
            }
        }

        return false;
    }

    private bool CheckGear()
    {
        if (gear.broken == true)
            return false;

        else
            return true;
    }

    public void Stop()
    {
        goBack = false;
    }

    public void MoveBack()
    {
        goBack = true;
    }
}
