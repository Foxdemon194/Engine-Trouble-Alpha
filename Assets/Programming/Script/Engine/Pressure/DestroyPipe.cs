using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPipe : MonoBehaviour
{
    public AudioSource sound;
    //public GameObject steamParticles;

    public GameObject pipe;    //Obejct to hide on collision
    public GameObject holder;  //Change variable in Parent

    Rigidbody rb;              //Variable for hammer Rigidgody

    int tutorial = 0;
    public GameObject tutorialDialogue;

    void OnCollisionEnter(Collision other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>();  //Assign Rigidbody to variable on collision

        //If the oject collising is the hummer and it velocity is higher the 2f
        if (other.gameObject.tag == "Hammer" && rb.velocity.magnitude > 2f)
        {
            pipe.SetActive(false);   //Set the broken pipe Object as false
            //steamParticles.SetActive(true);
            //Set the brokenPipeActive bool varibale in FixedPipeHandler script as false
            holder.GetComponent<FixedPipeHandler>().brokenPipeActive = false;

            if (tutorial <= 0)
            {
                tutorialDialogue.GetComponent<BasicTutorialDialogue>().Pipe();
                tutorial++;
            }
        }
        else if(other.gameObject.tag == "Wall" && other.gameObject.tag == "Player")
        {

        }
        else
        {
            sound.Play();
        }
    }
}
