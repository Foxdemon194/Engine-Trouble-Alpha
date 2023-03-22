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

    //public bool normalPipeActive;    //Bool varibale to know the state of the normal pipes
    public bool brokenPipeActive;    //Bool varibale to know the state of the broken pipes
    public bool checkOnce = true;

    public bool brokenStatus;        //Bool Variblae to know when a pipe is broken

    public bool[] pipe;

    //Random
    public int random;               //Int varibale to hold the random number of the pipe that breaks
    public int total;                //Int varibale to know the Length of the arreys

    // Start is called before the first frame update
   public void Start()
    {
        for (int i = 0; i < pipe.Length; i++)
        {
            pipe[i] = true;
        }

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
                pipe[random] = false;
            }
        }

        if (!pipe[random])
        {
            normalPipe[random].SetActive(false);
        }

        if (pipe[random])
        {
            normalPipe[random].SetActive(true);
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

            pipe[random] = true;
        
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
