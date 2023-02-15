using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggerCollider : MonoBehaviour
{
    public WaterValve valve;   //Reference to the WaterValve script

    //On Trigger Collidion Enter...
    private void OnTriggerEnter(Collider other)
    {
        //.. if the object colliding has the "Bucket" tag
        if (other.gameObject.tag == "Bucket")
        {
            valve.bucketInPlace = true; //Set the bucketInPlace variable in the WaterValve script to true
        }
    }
    //On Trigger Collidion Exit...
    private void OnTriggerExit(Collider other)
    {
        //.. if the object colliding has the "Bucket" tag
        if (other.gameObject.tag == "Bucket")
        {
            valve.bucketInPlace = false;  //Set the bucketInPlace variable in the WaterValve script to true
        }
    }
}
