using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGear : MonoBehaviour
{
    public float speed = 1f;  //Public float to hold the normal speed
    public float move;        //Public float to set the speed 

    // Start is called before the first frame update
    void Start()
    {
        move = speed;  //Set the speed to the normal speed
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, move);  //Rotate the object
    }
}
