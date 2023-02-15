using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public Light[] redlights;
    public Light[] lights;                //Reference to the Light arrey 
    public float lowIntensity = 0.2f;     //Public Float variable to set the low intensity of the lights
    public float normalIntensity = 0.6f; //Public Float variable to set the normal intensity of the lights

    private int time = 0;                 //Int variable to countdown time
    public int[] timeBreak;               //Public Int variable to store the break time frames
    private int random;                   //Int to select a random time frame

    public GameObject[] fuses;            //Public GameObject arrey to hold the Fuses
    public Collider[] fusesColliders;     //Public Collider arrey to hold the Fuses Colliders
    private int randomFuse;               //Int to select a random fuse

    public static bool brokenFuse = false;//Public bool variable know when a fuse is broken

    float timer = 0;
    bool goTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        //Set a random time frame to break
        random = Random.Range(0, timeBreak.Length);
        //Deactivate the colliders
        foreach (Collider obj in fusesColliders)
        {
            obj.enabled = false;
        }
        //Start the Timer 
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(brokenFuse == false)
        {
            //Activate the fuses
            foreach (GameObject obj in fuses)
            {
                obj.SetActive(true);
            }
            //Deactivate the colliders
            foreach (Collider obj in fusesColliders)
            {
                obj.enabled = false;
            }
        }

        if (goTimer == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                foreach (Light obj in redlights)
                {
                    obj.intensity = 0.2f;
                }
                goTimer = false;
                timer = 0f;
            }
        }
        
    }

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            time++; //Increase per second
            
            //If time increses to the selected timeBreak frame
            if(time == timeBreak[random])
            {
                randomFuse = Random.Range(0, fuses.Length); //Select a random fuse
                fuses[randomFuse].SetActive(false);         //Deactivate the selected fuse
                fusesColliders[randomFuse].enabled = true;  //Enabled the selcted fuse collider
                brokenFuse = true;                          //Set brokenFuse to true
                LowLights();                                //Call LowLights() function
            }
        }
    }

    private void LowLights()
    {
        //Set the intensity od every light to lowIntensity
        foreach (Light obj in lights)
        {
            obj.intensity = 0f;
        }

        goTimer = true;       
    }

    public void NormalLights()
    {
        //Set the intensity od every light to normalIntensity
        foreach (Light obj in lights)
        {
            obj.intensity = normalIntensity;
        }
        //Restet time and randomized time to break
        time = 0;
        random = Random.Range(0, timeBreak.Length);

        ////////////////////////////////////////////
        foreach (Light obj in redlights)
        {
            obj.intensity = 0f;
        }
    }
}
