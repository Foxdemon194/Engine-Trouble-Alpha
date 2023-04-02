using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Alejandro's script
public class EngineManager : MonoBehaviour
{
    public AudioSource fireSound;
    public GameObject coalInput;             //The part of the engine the coal has to enter before being used
    public float coalLevel = 100;            //The variable that determines how much coal is left in the engine
    public float coalDrainAmount = 10;       //The variable that controls how much of the coal will be drained after the time passes
    public float coalIncrease = 20;          //Controls how much coal will be added into the engine when put in
    public float coalTimerSpeed = 0.01f;     //How fast the COAL timers in the ENGINE will pass; Lower numbers makes timer faster

    public GameObject waterInput;            //The part of the engine the water has to enter before being used
    public float waterLevel = 100;           //The variable that determines how much water is left in the engine
    public float waterDrainAmount = 10;      //The variable that controls how much of the water will be drained after the time passes
    public float waterIncrease = 20;         //Controls how much water will be added into the engine when put in
    public float waterTimerSpeed = 0.01f;    //How fast the WATER timers in the ENGINE will pass; Lower numbers makes timer faster

    public bool activeEngine = true;         //Checks if the engine is currently running. A running engine must have coal AND water 

    /*public GameObject waterGreenLight;
    public GameObject waterRedLight;*/

    public GameObject Fire;                  //Reference to the Fire GameObject
    public Vector3 firePos;                  //Vector3 variable to set the position of the fire

    void Start()
    {
        StartCoroutine("StartCoalTimer");   //Start the Coal decrese Timer
        StartCoroutine("StartWaterTimer");  //Start the Water decrese Timer
    }

    void Update()
    {
        //Make sure the Water does not go above 100
        if (waterLevel >= 100)
            waterLevel = 100;
        //Make sure the Water does not go below 0
        if (waterLevel <= 0)
            waterLevel = 0;
        //Make sure the Coal does not go below 0
        if (coalLevel <= 0)
            coalLevel = 0;

        /*// Coal Lights
        if (coalLevel < 25)
        {
            coalGreenLight.SetActive(false);
            coalRedLight.SetActive(true);
        }
        else if (coalLevel >= 25 && coalLevel <= 75)
        {
            coalGreenLight.SetActive(true);
            coalRedLight.SetActive(false);
        }
        else if (coalLevel > 75)
        {
            coalGreenLight.SetActive(false);
            coalRedLight.SetActive(true);
        }*/

        ///Coal Amount Control
        if (coalLevel > 96)
        {
            SpawnFire();
            FirePresent();
            coalLevel = 95;
        }
        if (coalLevel >= 75)
        {
            waterTimerSpeed = 0.005f; //Water reduce faster
            fireSound.volume = 0.7f;
        }
        if (coalLevel > 60 && coalLevel < 75)
        {
            waterTimerSpeed = 0.007f; //Water reduce faster
            fireSound.volume = 0.4f;
        }
        if (coalLevel > 30 && coalLevel < 60)
        {
            waterTimerSpeed = 0.01f; //Water goes down slower
            fireSound.volume = 0.3f;
        }
        if (coalLevel < 30)
        {
            waterTimerSpeed = 0.017f;  //Water srabalized
            fireSound.volume = 0.2f;
        }
        if (coalLevel < 5)
        {
            fireSound.volume = 0f;
        }

        /*//Water Lights
        if (waterLevel < 35)
        {
            waterGreenLight.SetActive(false);
            waterRedLight.SetActive(true);
        }
        else if (waterLevel >= 35 )
        {
            waterGreenLight.SetActive(true);
            waterRedLight.SetActive(false);
        }*/

        ///Water Amount Control
        if(waterLevel > 80)
        {
            coalTimerSpeed = 0.02f; //Coal reduce slower
        }
        if(waterLevel > 30 && waterLevel <= 80)
        {
            coalTimerSpeed = 0.01f; //Coal reduce normal
        }
        if (waterLevel < 30)
        {
            coalTimerSpeed = 0.005f; //Coal reduce faster
        }
    }

    //Timers in the script
    IEnumerator StartCoalTimer()
    {
        while (true)
        {
            //Decrese Coal by the set amount as fast as coalTimerSpeed is Set
            yield return new WaitForSeconds(1 * coalTimerSpeed);
            coalLevel -= coalDrainAmount;
        }
    }
    IEnumerator StartWaterTimer()
    {
        while (true)
        {
            //Decrese Water by the set amount as fast as coalTimerSpeed is Set
            yield return new WaitForSeconds(1 * waterTimerSpeed);
            waterLevel -= waterDrainAmount;
        }
    }

    public void Sound()
    {
        fireSound.volume = 0.5f;
        fireSound.pitch = 1f;       
        fireSound.maxDistance = 2f;
        fireSound.minDistance = 1f;
    }
    public void FirePresent()
    {
        fireSound.volume = 1f;
        fireSound.pitch = 3f;
        fireSound.maxDistance = 10f;
        fireSound.minDistance = 7f;
    }

    public void SpawnFire()
    {
        var fire = Instantiate(Fire, firePos, transform.rotation * Quaternion.Euler(-90f, 0f, 0f)); //Create Fire
        fire.transform.parent = gameObject.transform;
    }
}
