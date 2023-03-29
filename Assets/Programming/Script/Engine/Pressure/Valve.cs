using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public AudioSource sound;
    private bool goSound = true;
    public float minValue = 0;            //Min tunring value
    public float maxvalue = 0;            //Max turning value
    public float depletionSpeed = 0.02f;  //Public float variable to set the speed of deplation of the pressure
    public Pressure pressure;             //Reference to the Pressure script 

    Quaternion originalPos;               //Qaternion varibale to hold the origianl position of the object
    public float speed = 1f;              //Public floar varibale to set the speed of movement

    public bool activateRust = false;     //Activate or deactivate Rust Funtionality
    public float timetoStop;              //Float to Count the time to Rust
    public float setTimeToStopHigh;       //Float to set the Max time to Rust
    public float setTimeToStopLow;        //Float to set the Min time to Rust
    public Material rust;
    public Material reg;
    HingeJoint hinge;                     //Reference to the HingeJoint component

    public GameObject tutorialDialogue;

    void Start()
    {
        originalPos = transform.rotation;                              //Set the Quternion originalPos to the Object original rotation
        hinge = GetComponent<HingeJoint>();                            //Initianlize the HingeJoint varibale
        reg = gameObject.GetComponent<Renderer>().material;
        timetoStop = Random.Range(setTimeToStopLow, setTimeToStopHigh);//Randomly set the time to Rust based on the Max and Min times
    }

    void Update()
    {
        //Constantly get the rotation on the Z axis
        var z = transform.localEulerAngles.y;
        
        //If the z rotation is between the Min and Max values ...
        if (z > minValue && z < maxvalue)
        {
            //.. do nothing
            sound.Stop();
            goSound = true;
        }
        else //if not ...
        {
            if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 7 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 6)
            {
                tutorialDialogue.GetComponent<BasicTutorialDialogue>().Continue();
            }
            pressure.sPressure -= depletionSpeed;  //Decrese the current pressure in Pressure script but the set amount per frame
            if (goSound == true)
            {
                sound.Play();
                goSound = false;
            }           
            Invoke("MoveBack", 2f);                //Invoke the MoveBack() function with 2 seconds delay
        }

        //If Rust functionality is active
        if (activateRust == true)
        {
            timetoStop -= Time.deltaTime; //Decrese the time to Rust based on standar time

            //If timetoStop below or equal to 0..
            if (timetoStop <= 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, Time.time * 2);
                JointLimits limits = hinge.limits;  //Create a JointLimits varibale
                limits.min = 0;                     //Set the min limit to 0
                limits.max = 0;                     //Set the max limit to 0
                hinge.limits = limits;              //Assign the limits to the HingeJoint
                gameObject.GetComponent<Renderer>().material = rust;
            }
            //Else if timetoStop above or equal to 0..
            else if (timetoStop > 0)
            {
                JointLimits limits = hinge.limits; //Create a JointLimits varibale
                limits.min = -179;                 //Set the min limit to 0
                limits.max = 179;                  //Set the max limit to 0
                hinge.limits = limits;             //Assign the limits to the HingeJoint
                gameObject.GetComponent<Renderer>().material = reg;
            }
        }      
    }

    //Move the nob to it's original position
    void MoveBack()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, Time.time * speed);
        //NOTE the speed has to be slow so it does not move back while the player is moving it
    }

    //On Collision Enter...
    void OnCollisionExit(Collision other)
    {
        //.. if the collision object has the "Oil" tag
        if (other.gameObject.tag == "Oil")
        {
            //Randomly reset the time to Rust based on the Max and Min times
            timetoStop = Random.Range(setTimeToStopLow, setTimeToStopHigh);
        }
    }
}
