using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalBarrel : MonoBehaviour
{
    public AudioSource sound;

    private Rigidbody rb;                  //Reference to the Barrel Rigidbody
    private bool handle1Grab = false;      //Bool variables to know how many 
    private bool handle2Grab = false;      // hands are grabing the barrel

    private Rigidbody rbHummer;            //Reference to  the Hammer Rigidbody 
    public GameObject coalPile;            //Reference to the Prefab of the Coal
    private bool check = true;             

    public GameObject handle1;             //Reference to the GameObject where
    public GameObject handle2;             //  the barrel is been grabed

    Vector3 offsetPos;

    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        rb = GetComponent<Rigidbody>();   //Initialized the Barrel Rigibody variable
        rb.mass = 2000007;                //Set the mass so that is unmovable
    }

    // Update is called once per frame
    void Update()
    {
        //If both handles are been grabed...
        if (handle1Grab == true && handle2Grab == true)
            rb.mass = 7;  //set the mass so it can be moved
        else   //if not it is still unmovable
            rb.mass = 2000007;

    }

    void OnCollisionEnter(Collision other)
    {
        rbHummer = other.gameObject.GetComponent<Rigidbody>();  //Assign Hummer Rigidbody to the variable on collision

        //If the oject collising is the hummer and it velocity is higher the 3f
        if (other.gameObject.tag == "Hammer" && rbHummer.velocity.magnitude > 3f)
        {
            if (check == true) //Make use it does the following commands only once
            {
                Destroy(gameObject);  //Destroy the barrel Object

                //Instantiate the new Coal Pile
                Instantiate(coalPile, offsetPos, Quaternion.identity);

                check = false;  //Make use it does this only once
            }
        }
        else if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Player")
        {

        }
        else
        {
            sound.Play();
        }

    }

    //Change the bool varible to true if it is being grab
    public void Handle1()
    {
        handle1Grab = !handle1Grab;
    }
    public void Handle2()
    {
        handle2Grab = !handle2Grab;
    }
}
