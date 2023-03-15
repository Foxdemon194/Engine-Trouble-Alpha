using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script?? I'm not exactly sure if this is mine but modified or someone else's script so...

public class FixedPipeHandler : MonoBehaviour
{
    //public GameObject[] steamParticles;
    public GameObject[] audio;
    public GameObject[] normalPipe;  //Reference arrey to the NormalPipes GameObjects
    public GameObject[] brokenPipe;  //Reference arrey to the BrokenPipes GameObjects
    public GameObject pype;
    public GameObject pype2;
    public GameObject pype3;
    public GameObject pype4;

    //public bool normalPipeActive;    //Bool varibale to know the state of the normal pipes
    public bool brokenPipeActive;    //Bool varibale to know the state of the broken pipes
    public bool checkOnce = true;

    public bool brokenStatus;        //Bool Variblae to know when a pipe is broken

    public bool normalPype;         //Bool for each pipe that chekcs if its fixed
    public bool normalPype2;
    public bool normalPype3;
    public bool normalPype4;


    //Random
    public int random;               //Int varibale to hold the random number of the pipe that breaks
    public int total;                //Int varibale to know the Length of the arreys

    // Start is called before the first frame update
   public void Start()
    {

        normalPype = true;          //sets the pipes to true since they don't start broken
        normalPype2 = true;
        normalPype3 = true;
        normalPype4 = true;

        brokenPipeActive = false;    //Set to false becouse there is no pipe broken
        //normalPipeActive = true;     //Set to true becouse there is no pipe broken
        total = brokenPipe.Length;   //Initialize with the Length of the arrey
    }

    // Update is called once per frame
    public void Update()
    {
        //Constantly get check the brokenPipe bool varibale in Pressure script in Parent
        brokenStatus = GetComponentInParent<Pressure>().brokenPipe;

        //If brokenStatus is true ...
        if (brokenStatus == true)
        {
            if (checkOnce == true)//Make sure it does the following code only once
            {
               // normalPype2 = false;
                //normalPype3 = false;
                //normalPype4 = false;/

                random = Random.Range(0, total);     //Set a random pipe to break
                brokenPipe[random].SetActive(true);  //Set the correct broken pipe GameObject as true
                audio[random].SetActive(true);
                brokenPipeActive = true;             //Set to true becouse there is a broken pipe
                normalPipe[random].SetActive(false); //Set the correct normal pipe GameObject as false
                //normalPipeActive = false;            //Set to false becouse there is a broken pipe
                checkOnce = false;//Make sure it does the following code only once

                //Specific pipes will break depending on what number random becomes
               if(random == 0)
                {
                    //first pipe breaks if its 0
                    normalPype = false;

                }
                if (random == 1)
                {
                    //second pipe breaks if its 1
                    normalPype2 = false;

                }
                if (random == 2)
                {
                    //third pipe breaks if its 2
                    normalPype3 = false;

                }
                if (random == 3)
                {
                    //fourth pipe breaks if its 3
                    normalPype4 = false;

                }
            }
        }

        //If the bool is false, then the pipe isn't active anymore and vice versa
        if (normalPype == false)
        {

            pype.SetActive(false);

        }
        if (normalPype == true)
        {

            pype.SetActive(true);

        }
        //If the bool is false, then the pipe isn't active anymore and vice versa
        if (normalPype2 == false)
        {

            pype2.SetActive(false);

        }
        if (normalPype2 == true)
        {

            pype2.SetActive(true);

        }
        //If the bool is false, then the pipe isn't active anymore and vice versa
        if (normalPype3 == false)
        {

            pype3.SetActive(false);

        }
        if (normalPype3 == true)
        {

            pype3.SetActive(true);

        }
        //If the bool is false, then the pipe isn't active anymore and vice versa
        if (normalPype4 == false)
        {

            pype4.SetActive(false);

        }
        if (normalPype4 == true)
        {

            pype4.SetActive(true);

        }
    }

    //On Collision Enter ...
    public void OnCollisionEnter(Collision other)
    {
        //.. if brokenPipeActive bool varibale is fasle and the object on collision has the "ReplacePipe" tag
        if (brokenPipeActive == false && other.gameObject.tag == "ReplacePipe")
        {
            normalPipe[random].SetActive(true);                  //Set the correct normal pipe Game Object as true
            audio[random].SetActive(false);
            GetComponentInParent<Pressure>().brokenPipe = false; //Set the brokenPipe bool varibale in Pressure script in Parent as false

            //Depending on what number random was, certain pipes will now be active again
            if (random == 0)
            {
                //first pipe fixes if its 0
                normalPype = true;

            }
            if (random == 1)
            {
                //second pipe fixes if its 1
                normalPype2 = true;

            }
            if (random == 2)
            {
                //third pipe fixes if its 2
                normalPype3 = true;

            }
            if (random == 3)
            {
                //fourth pipe fixes if its 3
                normalPype4 = true;

            }
        
        Destroy(other.gameObject);
            //Destroy the GameObject that was on collision
            /*foreach (GameObject obj in steamParticles)
            {
                obj.SetActive(false);
            }*/
            checkOnce = true;                         
        }
    }
}
