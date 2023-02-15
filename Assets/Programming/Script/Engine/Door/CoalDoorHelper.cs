using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalDoorHelper : MonoBehaviour
{
    public CoalDoor door;    //Reference to the CoalDoor script that this Object it is helping

    //On Trigger Exit Collision...
    private void OnTriggerExit(Collider other)
    {
        //If the GameObject on trigger collision has the Player tag...
        if (other.gameObject.tag == "Player")
        {
            //Set the goBackvariable to true
            door.goBack = true; 
        }
    }
}
