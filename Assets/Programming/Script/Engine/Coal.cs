using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
//Place this script where ever the coal is going to be shovelled in the engine. Needs to be a trigger collider

public class Coal : MonoBehaviour
{
    private float fuelAmount;    //Float variable to the Coal Level in EngineManager
    private float fuelIncrease;  //Float variable to the increase the Coal Level in EngineManager

    //Constantly takes the values from their respective counterparts and gives them to the new variables
    void Update()
    {
        fuelAmount = GetComponentInParent<EngineManager>().coalLevel;
        fuelIncrease = GetComponentInParent<EngineManager>().coalIncrease;
    }

    //On Collision Enter...
    void OnCollisionEnter(Collision other)
    {
        //If the object in collision has the "Coal" tag..
        if (other.gameObject.tag == "Coal")     
        {
            Destroy(other.gameObject);  //Destroy the object on collision
            fuelAmount = fuelAmount + fuelIncrease;   //Increse the Coal Level in EngineManger by the set variable
            GetComponentInParent<EngineManager>().coalLevel = fuelAmount;
        }
    }
}
