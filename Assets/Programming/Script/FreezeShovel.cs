using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeShovel : MonoBehaviour
{
    Rigidbody rb;
    private bool grab1 = false;
    private bool grab2 = false;

    public float speed = 1f;
    private Quaternion desirePos;
    public Quaternion desirePosGrab1;
    public Quaternion desirePosGrab2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (grab1 == false && grab2 == false)
        {
            rb.constraints = RigidbodyConstraints.None;           
        }
        else if (grab1 == true && grab2 == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, desirePos, Time.time * speed);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else if (grab1 == false && grab2 == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, desirePos, Time.time * speed);
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else if (grab1 == true && grab2 == true)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }

    public void Grab1()
    {
        grab1 = !grab1;
        if(grab1 == true)
        {
            desirePos = desirePosGrab1;
        }
    }

    public void Grab2()
    {
        grab2 = !grab2;
        if(grab2 == true)
        {
            desirePos = desirePosGrab2;
        }
    }
}
