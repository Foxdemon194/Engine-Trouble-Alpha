using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterValve : MonoBehaviour
{
    public AudioSource fillSound;
    Quaternion originalPos;             //Refrence to the Quaternion varible to store the Object original rotation
    public float speed = 1f;            //Public float to ste the speed at which the object Moves

    public ParticleSystem water;        //Public Reference to the water PartycleSystem
    public ParticleSystem waterWhite;   //Public Reference to the water PartycleSystem

    public float minValue = 0;          //Min tunring value
    public float maxvalue = 0;          //Max tunring value

    private bool letPlay;               //Bool to Play the Particle Systems 
    public bool bucketInPlace = false;  //Bool to know when the Bucket is beneath the valve

    public Bucket bucket;               //Reference to the Bucket script
    private bool fill = false;          //Bool to know when the Bucket is full
    private bool startTimeToFill = false; //Bool to start the timer to fill the bucket
    float time = 0;                       //Count the time fill

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.rotation;  //Set the Quternion originalPos to the Object original rotation
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly get the X rotation of the object
        var x = transform.localEulerAngles.x;

        //If startTimeToFill is true..
        if (startTimeToFill == true)
        {
            time += 0.05f; //Increase time varibale by 0.05 per frame
            //Once time is above or equal to 2..
            if (time >= 1f)
            {
                fill = true;  //Set fill to true
                startTimeToFill = false; //Set startTimeToFill to false
                time = 0;  //Reset the time variable
            }
        }

        //If the bucketInPlace variable is true..
        if (bucketInPlace)
        {
            //If the x rotation is between the Min and Max values ...
            if (x > minValue && x < maxvalue)
            {
                letPlay = false; //Set letPlay variable to false
            }
            //If not...
            else
            {
                letPlay = true; //Set letPlay variable to true
                startTimeToFill = true; //Set startTimeToFill to true
            }
        }
        //If not..
        else
        {
            letPlay = false; //Set letPlay variable to false
        }

        //If letPlay varibale is true...
        if (letPlay)
        {
            if (!water.isPlaying) //..if the Partycle Syatem is not in Play
            {
                water.Play(); //Play the Partycle System
                waterWhite.Play(); //Play the Partycle System
                fillSound.Play();
            }
        }
        //If letPlay variable is false..
        else
        {
            if (water.isPlaying)  // ..if the Partycle Syatem is in Play
            {
                water.Stop(); //Stop the Partycle System
                waterWhite.Stop(); //Stop the Partycle System
                fillSound.Stop();
            }
        }

        //If fill variable is true..
        if (fill == true)
        {
            bucket.filled = true;  //Set the filled variable in Bucket script to true
            bucket.FixRot(); //////////////////////////////////////////////////////////////////////
            fill = false; //Set the fill to false
        }
    }

    //Move the object back to it's original position
    public void MoveBack()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, Time.time * speed);
    }
}
