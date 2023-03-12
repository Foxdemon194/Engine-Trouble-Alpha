using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
//Place on objects with the light component

public class FlickeringLight : MonoBehaviour
{
    public Light lit;               //The light component
    public float currentBrightness; //The current brightness of the light
    public float maxBrightness;     //The max brightness that the light can get to. After the light flickers, it will go back to this value
    public float minBrightness;     //The minimum brightness the light can get to
    public float lightTimer;        //A timer that constantly increases
    public float flickerFrequency;  //When the timer ^^^ matches this value, it does something and resets
    public float flickerSpeed;      //How fast the light flickers; Smaller value, faster flicker
    public float flickerSpeedMin;   //Set it to at most 0.5 or a bit lower
    public float flickerSpeedMax;   //Set it to at least 0.08 or a bit higher
    public int rand;                //A random value from 0 to 100
    public int minRand;             //When rand ^^^ reaches or passes this value, it does something
    public int repeat;              //How many times the light will go on and off

    float t;
    float i;

    void Update()
    {
        //Starts the timer
        lightTimer += Time.deltaTime;

        //Makes the intensity of the Light component match the currentBrightness's value
        lit.intensity = currentBrightness;

        //When the timer equals the flickerFrequency, it calls the RandomNumber function and resets the timer
        if (lightTimer >= flickerFrequency)
        {
            RandomNumber();
            lightTimer = 0;
        }

        //When i equals to repeat, the IEnumerator is stopped and i is reset
        if (i >= repeat)
        {
            StopCoroutine("Flicker");
            i = 0;
            t = 0;
        }
    }

    void RandomNumber()
    {
        //Generates a number from 0 to 100
        rand = Random.Range(0, 100);

        //If the random number is at least the minRand value...
        if (rand >= minRand)
        {
            //Then it sets the speed of the flickering light and starts the IEnumerator
            flickerSpeed = Random.Range(flickerSpeedMax, flickerSpeedMin);
            StartCoroutine("Flicker");
        }
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            //The timer is constantly set to 0 to prevent overlap
            lightTimer = 0;
            yield return new WaitForSeconds(t);

            //Makes the currentBrightness match the minBrightness in t/Flickerspeed amount of time, then increaases i by 1
            if (currentBrightness > minBrightness && currentBrightness > minBrightness + 0.1)
            {
                currentBrightness = Mathf.Lerp(currentBrightness, minBrightness, t / flickerSpeed);
                t += Time.deltaTime;
            }
            else
            {
                i++;
                currentBrightness = minBrightness;
            }

            //When the light drops to the lowest brightness, it shoots back to the max brightness and sets a random flicker speed again
            if (currentBrightness == minBrightness)
            {
                currentBrightness = maxBrightness;
                flickerSpeed = Random.Range(flickerSpeedMax, flickerSpeedMin);
            }
        }
    }
}
