using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGadge : MonoBehaviour
{
    public Transform gadge;   //Reference to the Gadge GameObject
    public Pressure pressure; //Reference to the Pressure script
    private float target;     //Float to set the position of the Gadge
    private const float levelToDegrees = 270f / 100f;

    void Update()
    {
        target = pressure.sPressure; //Constantly get the Coal Level 
        gadge.localRotation = Quaternion.Euler(0f, 0f, (float)target * -levelToDegrees); //Rotate the Gadge
    }
}
