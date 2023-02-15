using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalDoorStckHelper : MonoBehaviour
{
    public CoalDoor door;         //Reference to the CoalDoor script that this Object it is helping
    public bool oiled = false;    //Bool varibale to set the joints as Oiled

    //On Trigger Exit Collision...
    void OnTriggerExit(Collider other)
    {
        //If the GameObject on trigger collision has the Oil tag...
        if (other.gameObject.tag == "Oil")
        {
            //Set the oiled bool variable true
            oiled = true;
        }
    }
}
