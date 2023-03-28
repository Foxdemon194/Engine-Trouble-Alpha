using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;  //Library for the XR scripts

public class CoalDoor : MonoBehaviour
{
    public AudioSource sound;
    float timer = -0.1f;
    public AudioClip openDoor;
    public AudioClip closeDoor;
    private bool goSound = false;

    Quaternion currentPos;
    Quaternion originalPos;                    //Refrence to the Quaternion varible to store the Object original rotation
    public float speed = 0.01f;                //Public float to ste the speed at which the object Moves

    public bool goBack = false;                //Bool variable to know when go back to the original position

    public bool activateRust = false;          //Activate the Rust functionality(only on the Editor)
    public float timetoStop;                   //Float to Count the time to Rust
    public float setTimeToStopHigh;            //Float to set the Max time to Rust
    public float setTimeToStopLow;             //Float to set the Min time to Rust
    public GameObject rust;                    //Reference to the RustedDoor GameObject(for now)
    public XRGrabInteractable handle;          //Reference to the XRGrabInteractable sript 
    public bool stuck = false;                 //Bool to set the Rust 
    public bool check = false;
    public CoalDoorStckHelper doorCollider1;   //Reference to the CoalDoorStckHelper scipt to put oil on the hanldes
    public CoalDoorStckHelper doorCollider2;   //Reference to the CoalDoorStckHelper scipt to put oil on the hanldes

    void Start()
    {
        currentPos.y = transform.rotation.y;
        originalPos = transform.rotation;                                   //Set the Quternion originalPos to the Object original rotation
        rust.SetActive(false);                                              //Set the RustedDoor GameObject false
        timetoStop = Random.Range(setTimeToStopLow, setTimeToStopHigh);     //Randomly set the time to Rust based on the Max and Min times
        doorCollider1.enabled = false;                                      //Desable the CoalDoorStckHelper script
        doorCollider2.enabled = false;                                      //Desable the CoalDoorStckHelper script
    } 

    void Update()
    {
        //If bool goBack is true...
        if (goBack == true)
        {
            Move();  //... call Move() funtion
        }

        //If the Objects Position is equal to the Original position...
        if (originalPos == transform.rotation)
        {
            Stop(); //... set bool goBack to false
            if (goSound == true)
            {
                sound.clip = closeDoor;
                sound.Play();
                goSound = false;
            }
            
        }
        else 
        {
            goSound = true;
        }

        if (currentPos != transform.rotation)
        {            
            if (timer == 0)
            {
                sound.clip = openDoor;
                sound.Play();
            }
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                currentPos = transform.rotation;
                timer = 0;
            }
        }


        //If Rust functionality is activated
        if (activateRust == true)
        {
            timetoStop -= Time.deltaTime;  //Decrese the time to Rust based on standar time
            //If timetoStop is less or equal to 0...
            if (timetoStop <= 0)
            {
                goBack = true; //... close the door and keep it close
                handle.enabled = false;  //Desable the XRGrabInteractable script
                rust.SetActive(true);    //Set RustedDoor GameObject to true
                stuck = true;            //Set the bool stuck to true
                if (check == true)//Make sure it does the following code onlt once
                {
                    check = false;//Make sure it does the following code onlt once
                    doorCollider1.enabled = true;  //Enable the CoalDoorStckHelper script
                    doorCollider1.oiled = false;   //Set the oiled bool varible in CoalDoorStckHelper script to false
                    doorCollider2.enabled = true;  //Enable the CoalDoorStckHelper script
                    doorCollider2.oiled = false;   //Set the oiled bool varible in CoalDoorStckHelper script to false
                }
            }

            //If stuck bool varibale is true...
            if (stuck == true)
            {
                //.. if the oiled bool varibale in one of the handles CoalDoorStckHelper script is true...
                if (doorCollider1.oiled == true)
                {
                    doorCollider1.enabled = false; //Desable the CoalDoorStckHelper script
                }

                //.. if the oiled bool varibale in the other handle CoalDoorStckHelper script is true...
                if (doorCollider2.oiled == true)
                {
                    doorCollider2.enabled = false; //Desable the CoalDoorStckHelper script
                }

                //.. If bothe oiles bool varibles in the two CoalDoorStckHelper scripts are true...
                if (doorCollider1.oiled == true && doorCollider2.oiled == true)
                {
                    stuck = false;   //Stuck bool varibale is set to false
                    timetoStop = Random.Range(setTimeToStopLow, setTimeToStopHigh);  //Randomly set the time to Rust based on the Max and Min times
                    check = true;   
                    rust.SetActive(false);   //Set the RustedDoor GameObject false
                    handle.enabled = true;   //Enable the XRGrabInteractable script
                }
            }
        }
    }

    //Move the object back to it's original position
    void Move()
    {
        //If goBack is true...
        if(goBack == true)
        {
            //.. move the object back to it's original position
            transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, Time.time * speed);
        }
        //If goBack is false...
        else if (goBack == false)
        {
            //Do nothing
        }
    }

    //Stop the Object from moving back
    public void Stop()
    {
        //Set goBack to false
        goBack = false; 
    }
}