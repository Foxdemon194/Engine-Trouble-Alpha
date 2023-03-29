using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
//Place this script where ever the water is going to be poured in the engine. Needs to be a trigger collider

public class Water : MonoBehaviour
{
    private float fuelAmount;    //Float variable to the Water Level in EngineManager
    private float fuelIncrease;  //Float variable to the increase the Water Level in EngineManager

    public GameObject tutorialDialogue;

    //Constantly takes the values from their respective counterparts and gives them to the new variables
    void Update()
    {
        fuelAmount = GetComponentInParent<EngineManager>().waterLevel;
        fuelIncrease = GetComponentInParent<EngineManager>().waterIncrease;
    }

    //On Trigger Collision Enter...
    void OnTriggerEnter(Collider other)
    {
        //If the object in collision has the "Water" tag..
        if (other.gameObject.tag == "Water")
        {
            //Increse the Water Level in EngineManger by the set variable
            fuelAmount += fuelIncrease;
            GetComponentInParent<EngineManager>().waterLevel = fuelAmount;

            if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 18 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 17)
            {
                tutorialDialogue.GetComponent<BasicTutorialDialogue>().Continue();
            }
        }
    }
}
