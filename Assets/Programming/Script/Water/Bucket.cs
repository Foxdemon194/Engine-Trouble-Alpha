using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bucket : MonoBehaviour
{
    public XRGrabInteractable button;
    public bool grabHandle = false;
    public bool grabBase = false;

    public ParticleSystem water;
    public bool filled = false;

    public Rigidbody baseBucket;
    public float speed = 1f;
    public Quaternion desirePos;
    private bool goBack = false;

    // Start is called before the first frame update
    void Start()
    {
        button.enabled = false;
        //desirePos = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabHandle == true)
        {
            button.enabled = true;
        }
        else
        {
            button.enabled = false;
        }

        if (goBack == true)
        {
            baseBucket.transform.rotation = Quaternion.Slerp(transform.rotation, desirePos, Time.time * speed);

            if (transform.rotation == desirePos)
                goBack = false;
        }

        if (filled == true)
        {
            if (!water.isPlaying)
            {
                water.Play();
            }
            if (grabBase == true)
            {
                baseBucket.constraints = RigidbodyConstraints.None;
            }
            else
            {
                baseBucket.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
        }
        else if (filled == false)
        {
            if (water.isPlaying)
            {
                water.Stop();
            }
            baseBucket.constraints = RigidbodyConstraints.None;
        }
    }

    public void GrabHandle()
    {
        grabHandle = !grabHandle;
    }

    public void GrabBase()
    {
        grabBase = !grabBase;
    }

    public void ReleaseRot()
    {
        if (filled == true)
            goBack = false;
    }

    public void FixRot()
    {
        if (filled == true)
            goBack = true;
    }
}
