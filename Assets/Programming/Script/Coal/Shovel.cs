using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public AudioSource sound;
    public GameObject coal;   //Refrence to the Coal GameObject
    private bool hit = true;

    //On Trigger Enter collision...   
    void OnTriggerEnter(Collider other)
    {
        //.. if the GameObject on trigger collision has the CoalPile tag... 
        if (other.gameObject.tag == "CoalPile")
        {
            if (hit == true) 
            {
                sound.Play();
                GameObject a = Instantiate(coal, this.transform.position, Quaternion.identity);
                hit = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CoalPile")
        {
            Invoke("Allow", 0.7f);
        }
    }

    void Allow()
    {
        hit = true;
    }
}
