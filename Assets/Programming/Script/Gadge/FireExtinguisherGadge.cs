using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherGadge : MonoBehaviour
{
    public Transform gadge;  //Reference to the Gadge GameObject
    private float target;    //Float to set the position of the Gadge
    private float levelToDegrees;// = 270f / 9f;

    void Start()
    {
        levelToDegrees = 270f / GetComponentInParent<Pickup>().extinguisherFuel;
    }

    void Update()
    {
        target = GetComponentInParent<Pickup>().extinguisherFuel;  //Constantly get the Water Level from the Parent
        gadge.localRotation = Quaternion.Euler(0f, 0f, (float)target * -levelToDegrees); //Rotate the Gadge
    }
}
