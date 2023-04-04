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

    public float decreaseSpeedCoal = 75;
    public float decreaseSpeedWater = 75;
    public float increaseSpeedSteam = 50;
    public float increaseSpeedProgress = 0.05f;

    public bool goBack;
    Quaternion originalPos;
    public float timeElapsed;
    public float duration = 1f;

    public HingeJoint hinge;

    public GameObject tutorialDialogue;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.rotation;
        UnGrabLimits();
    }

    // Update is called once per frame
    void Update()
    {
        var z = transform.localEulerAngles.z;

        if(CheckCoalLevel() && CheckWaterLevel() && CheckPressureLevel() && CheckGear())
        {
            if (z >= 15)
            {
                if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 32 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 31)
                {
                    tutorialDialogue.GetComponent<BasicTutorialDialogue>().Continue();
                }

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
                progress.bostLever = true;
            }
        }
   
        if (goBack == true)
        {
            if (timeElapsed < duration)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                transform.rotation = originalPos;
                timeElapsed = 0;
            }
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

    public bool CheckGear()
    {
        for (int i = 0; i < gear.broken.Length; i++)
        {
            if (gear.broken[i])
            {
                return false;
            }
        }

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

    public void GrabLimits()
    {
        JointLimits limits = hinge.limits;
        limits.max = 30;
        limits.min = -30;
        hinge.limits = limits;
    }

    public void UnGrabLimits()
    {
        JointLimits limits = hinge.limits;
        limits.max = 0;
        limits.min = 0;
        hinge.limits = limits;
    }
}
