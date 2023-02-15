using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private bool hit = true;
    public AudioSource sound;

    //On Trigger Exit collision..
    void OnTriggerExit(Collider other)
    {
        //If the gameObject with the shovel tag exits the trigger collidion...
        if (other.gameObject.tag == "Shovel")
        {
            if (hit == true)  //Make sure it does the followinf commands only once
            {
                if (gameObject.tag == "Coal")
                {
                    sound.Play();
                    Invoke("DestroyO", 1f);
                }
                else
                {
                    Invoke("DestroyO", 0.2f); //..invokes the DestroyO function with a delay of 0.2 seconds
                }
                 
                hit = false;  //Make sure it does the followinf commands only once
            }
        }
    }

    void DestroyO()
    {      
        Destroy(gameObject);  //Destroy this Game Object
    }
}
