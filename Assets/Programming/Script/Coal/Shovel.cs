using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public AudioSource sound;
    public GameObject coal;   //Refrence to the Coal GameObject
    private bool hit = true;

    public float y;
    public float z;

    private void Update()
    {
        if (!hit)
        {
            if (transform.rotation.y >= y)
            {
                this.GetComponentInChildren<Rigidbody>().isKinematic = false;
                this.GetComponentInChildren<Transform>().parent = this.GetComponentInChildren<Transform>();
                hit = true;
            }
            if (transform.rotation.y <= -y)
            {
                this.GetComponentInChildren<Rigidbody>().isKinematic = false;
                this.GetComponentInChildren<Transform>().parent = this.GetComponentInChildren<Transform>();
                hit = true;
            }
            if (transform.rotation.z >= z)
            {
                this.GetComponentInChildren<Rigidbody>().isKinematic = false;
                this.GetComponentInChildren<Transform>().parent = this.GetComponentInChildren<Transform>();
                hit = true;
            }
            if (transform.rotation.z >= -z)
            {
                this.GetComponentInChildren<Rigidbody>().isKinematic = false;
                this.GetComponentInChildren<Transform>().parent = this.GetComponentInChildren<Transform>();
                hit = true;
            }
        }
    }

    //On Trigger Enter collision...   
    void OnTriggerEnter(Collider other)
    {
        //.. if the GameObject on trigger collision has the CoalPile tag... 
        if (other.gameObject.tag == "CoalPile")
        {
            if (hit == true) 
            {
                sound.Play();
                GameObject a = Instantiate(coal, this.transform.position, Quaternion.identity);
                a.transform.SetParent(this.transform);
                a.GetComponent<Rigidbody>().isKinematic = true;
                hit = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CoalPile")
        {
            Invoke("Allow", 0.7f);
        }
    }

    void Allow()
    {
        hit = true;
    }
}
