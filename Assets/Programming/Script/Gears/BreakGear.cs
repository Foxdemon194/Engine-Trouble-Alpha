using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGear : MonoBehaviour
{
    public AudioSource[] sound;
    public AudioClip breakSound;
    //public Progress progress;       //Reference to Progress script
    public bool[] broken;     //Bool variable to know when it breaks
    public GameObject[] brokenGear;   //Reference to the brokenGear GameObject
    public GameObject[] normalGear;   //Reference to the normalGear GameObject
    public RotateGear[] gears;      //Reference arrey to the RotateGear script
    public bool setToFix = false;   //Bool variable to know when it can be fixed
    public float timetoBreak;       //Float to Count the time to Rust
    public float setTimeToBreakHigh;//Float to set the Max time to Rust
    public float setTimeToBreakLow; //Float to set the Min time to Rust

    Rigidbody rb;                   //Reference to the Hummer Rigidbody

    int rand;
    bool check = true;

    void Start()
    {
        //Randomly set the time to Rust based on the Max and Min times
        timetoBreak = Random.Range(setTimeToBreakLow, setTimeToBreakHigh);
    }

    void Update()
    {
        timetoBreak -= Time.deltaTime; //Decrese the time to Rust based on standar time

        if (timetoBreak <= 0)
        {
            if (check)
            {
                rand = Random.Range(0, broken.Length);
                broken[rand] = true; //Set broken variable to true
                check = false;
                timetoBreak = 0;
            }

            timetoBreak = 0;
        }

        //If broken variable is true
        if (broken[rand] == true)
        {
            sound[rand].volume = 0.1f;

            //Go into the arrey of RotateGear[] one by one...
            foreach (RotateGear obj in gears)
            {
                obj.move = 0; //change the speed of rotation to 0 
            }
            //progress.speed = 0; //Set the speed in the Progress script to 0
            
            for (int i = 0; i < gears.Length; i++)
            {
                gears[i].gameObject.GetComponent<AudioSource>().Stop();
            }

            normalGear[rand].SetActive(false); //Set normalgear GameObject as false
            brokenGear[rand].SetActive(true);
        }
        else
        {
            sound[rand].volume = 0.5f;
        }
    }

    //On Collision Enter..
    void OnCollisionEnter(Collision other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>(); //Get the Rigidbody of the object on collision
        //If the object on collision has the "Hammer" tag AND the velocity of the rigidbody is hiher the 3f...
        if (other.gameObject.tag == "Hammer" && rb.velocity.magnitude > 3f)
        {
            //If broken variable is true...
            if (broken[rand] == true)
            {
                broken[rand] = false;
                brokenGear[rand].SetActive(false);  //Set the brokenGear GameObject as false
                sound[rand].PlayOneShot(breakSound, 1f); //////////////////////////////////////////////////////////////////////////////////////
                setToFix = true;              //Set the setToFix as true
            }
        }

        //If the object on collision has the "ReplacementGear" tag
        if (other.gameObject.tag == "ReplacementGear")
        {
            //If setToFix varibale is true..
            if (setToFix == true)
            {
                for (int i = 0; i < gears.Length; i++)
                {
                    gears[i].gameObject.GetComponent<AudioSource>().Play();
                }
                brokenGear[rand].SetActive(false); //Set brokenGear GameObject as true
                normalGear[rand].SetActive(true); //Set normalGear GameObject as true
                broken[rand] = false;             //Set the broken varibale as false
                setToFix = false;           //Set the setToFix varibale as false
                //Go into the arrey of RotateGear[] one by one...
                foreach (RotateGear obj in gears)
                {
                    obj.move = obj.speed;  //change the speed of rotation to the set speed in RotateGear script 
                }
                check = true;
                //Randomly set the time to Rust based on the Max and Min times
                timetoBreak = Random.Range(setTimeToBreakLow, setTimeToBreakHigh);
                Destroy(other.gameObject); //Destory the obejct that is colliding
            }
        }
    }
}