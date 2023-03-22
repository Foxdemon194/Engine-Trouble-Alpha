using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGadge : MonoBehaviour
{
    public Transform gadge;  //Reference to the Gadge GameObject
    public EngineManager water;
    private float target;    //Float to set the position of the Gadge
    private const float levelToDegrees = 270f / 100f;

    void Update()
    {
        target = water.waterLevel;  //Constantly get the Water Level from the Parent
        gadge.localRotation = Quaternion.Euler(0f, 0f, (float)target * -levelToDegrees); //Rotate the Gadge
    }
}
