using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalGadge : MonoBehaviour
{
    public Transform gadge;  //Reference to the Gadge GameObject
    public EngineManager coal; //Reference to the Pressure script
    private float target;    //Float to set the position of the Gadge
    private const float levelToDegrees = 270f / 100f;  

    void Update()
    {
        //target = GetComponentInParent<EngineManager>().coalLevel;  //Constantly get the Coal Level from the Parent
        target = coal.coalLevel;
        gadge.localRotation = Quaternion.Euler(0f, 0f, (float)target * -levelToDegrees); //Rotate the Gadge
    }
}
