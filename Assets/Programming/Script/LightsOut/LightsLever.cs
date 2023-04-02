using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsLever : MonoBehaviour
{
    public AudioSource breakerSound;
    Quaternion originalPos;   //Refrence to the Quaternion varible to store the Object original rotation
    public float timeElapsed;
    public float duration = 1f;

    public GameObject lights;  //Reference to the LightsOut script 

    bool goBack = false;      //Bool variable to know when go back to the original position

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.rotation;  //Set the Quternion originalPos to the Object original rotation
    }

    // Update is called once per frame
    void Update()
    {
        //If bool goBack is true...
        if (goBack == true)
        {
            //.. move the object back to it's original position
            if (timeElapsed < duration)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                transform.rotation = originalPos;
                timeElapsed = 0;
            }
        }

        //If the Objects Position is equal to the Original position...
        if (originalPos == transform.rotation)
            goBack = false;  //.. set goBack to false
    }

    //Stop the Object from moving back
    public void Stop()
    {
        goBack = false;
    }

    //Move the object back to it's original position
    public void MoveBack()
    {
        goBack = true; //Set goBack to true

        //Constantly get the X rotation of the object
        var x = transform.localEulerAngles.x;

        //If X rotation is higer then 70... 
        if (x >= 40)
        {
            //... if brokenFuse bool variable in LightsOut script is false..
            if (lights.GetComponent<LightsOut>().brokenFuse == false)
            {
                lights.GetComponent<LightsOut>().NormalLights(); //.. call NormalLights() function in LightsOut script
                breakerSound.Play();
            }
        }
    }
}
