using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalDiminush : MonoBehaviour
{
    public GameObject nextCoalPile;  //Reference to the Coal Pile GameObject
    private bool hit = true;         

    //On Trigger Exit collision
    void OnTriggerExit(Collider other)
    {
        //If the gameObject with the shovel tag exits the trigger collidion...
        if(other.gameObject.tag == "Shovel")
        {
            if(hit == true)  //Make sure it does the followinf commands only once
            {
                hit = false;  //Make sure it does the followinf commands only once
                Invoke("DestroyO", 0.5f); //.. invokes the DestroyO function with a delay of 0.5 seconds
            }
        }
    }

    void DestroyO()
    {
        Destroy(gameObject); //Destroy this GameObject
        //Instantiate the next coal pile
        Instantiate(nextCoalPile, this.transform.position, Quaternion.identity);
    }
}
