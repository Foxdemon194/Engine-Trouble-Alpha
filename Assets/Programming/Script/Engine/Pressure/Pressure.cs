using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : MonoBehaviour
{
    public float sPressure = 0;                       //Pressure current amount
    public float pressureIncrease = 0.1f;             //Public float varible to set how fast sPressure variable increases
    public float normalPressureTimerSpeed = 0.06f;    //Public float varible to Set a normal presure increase
    public float highPressureTimerSpeed = 0.01f;      //Public float varible to Set a high presure increase
    public float mediumPressureTimerSpeed = 0.04f;    //Public float varible to Set a medium presure increase
    public float lowPressureTimerSpeed = 0.08f;       //Public float varible to Set a low presure increase (the lower the number the fastee it increases)

    private float coalLevel;                          //Reference float variable to know the current Coal Level in the EngineManager script
    private float waterLevel;                         //Reference float variable to know the current Water Level in the EngineManager script

    public float pressureTimerSpeed = 0.06f;          //Varibale that will set the speed of increase of the Pressure 

    //Breaken Pipe
    public float highPressureTime = 20;               //Public float varibale to set the amount of time pressure can be high before a pipe breaks
                                                      // (to desable this funtionality just increse the number super high)
    private float timeToBreak;                        //Count the time to break a Pipe
    public bool brokenPipe = false;                   //Bool varibale knw when a pipe is broken

    void Start()
    {
        timeToBreak = highPressureTime;         //Set the counter equal to the set time 
        StartCoroutine("StartPressureTimer");   //Start the IEnumerator that increses the pressure
    }

    //IEnumerator that increses the pressure
    IEnumerator StartPressureTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 * pressureTimerSpeed);
            sPressure += pressureIncrease;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Make sure the pressure does not go above 100
        if (sPressure >= 100)
            sPressure = 100;
        //Make sure the pressure does no go bellow 0
        if (sPressure <= 0)
            sPressure = 0;

        //Constantly get the Coal and Water levles from the EngineManger script in the Parent
        coalLevel = GetComponentInParent<EngineManager>().coalLevel;
        waterLevel = GetComponentInParent<EngineManager>().waterLevel;

        ///Coal Amount Control
        if (coalLevel >= 75 && coalLevel <= 100)
        {
            pressureTimerSpeed = highPressureTimerSpeed; //Pressure goes up
        }
        else if (coalLevel >= 60 && coalLevel < 75)
        {
            pressureTimerSpeed = mediumPressureTimerSpeed; //Pressure goes up
        }
        else if (coalLevel >= 30 && coalLevel < 60)
        {
            pressureTimerSpeed = normalPressureTimerSpeed; //Pressure stabalized
        }
        else if (coalLevel < 30 && coalLevel > 5)
        {
            pressureTimerSpeed = lowPressureTimerSpeed; //Presure goes up slower
        }

        ///Water Amount Control
        if (waterLevel < 30 && waterLevel > 5)
        {
            pressureTimerSpeed = mediumPressureTimerSpeed; //Presure goes up slower
        }
        else if (waterLevel >= 30 && waterLevel < 70)
        {
            pressureTimerSpeed = normalPressureTimerSpeed; //Pressure stabalized
        }
        else if (waterLevel >= 70)
        {
            pressureTimerSpeed = lowPressureTimerSpeed; //Presure goes up faster
        }


        if (coalLevel <= 5)
        {
            pressureTimerSpeed = 40; //Presure goes up extremely slow
        }
        if (waterLevel <= 5)
        {
            pressureTimerSpeed = 40; //Presure goes up extremely slow
        }
        /*//SteamLights
        if (sPressure < 25)
        {
            steamGreenLight.SetActive(false);
            steamRedLight.SetActive(true);
        }
        else if (sPressure >= 25 && sPressure <= 85)
        {
            steamGreenLight.SetActive(true);
            steamRedLight.SetActive(false);
        }
        else if (sPressure > 85)
        {
            steamGreenLight.SetActive(false);
            steamRedLight.SetActive(true);
        }*/

        //Pipe Breaking
        //If bfrokenPipe is true...
        if (brokenPipe == true)
        {
            sPressure -= 0.2f; // contanly decrese the pressure level
        }

        //If pressure exeeds 85... 
        if (sPressure > 85)
        {
            timeToBreak -= Time.deltaTime; //.. start decrese the time for the pipe to Break
        }

        //If highPressureTime is bellow or equal to 0...
        if (timeToBreak <= 0) 
        {
            timeToBreak = highPressureTime;  //Set the time to break back to the set time
            brokenPipe = true;      //Set broken pipe to true
        }
    }
}
