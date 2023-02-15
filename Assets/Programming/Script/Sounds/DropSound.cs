using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSound : MonoBehaviour
{
    private float timer = 0;
    private bool count = true;

    private bool go = true;

    public GameObject soundPrefab;

    ContactPoint contact2;

    void Update()
    {
        if (count == true)
        {
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                count = false;
            }         
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (timer > 2f)
        {
            if (other.gameObject.tag != "Player" && other.gameObject.tag != "Untagged" && other.gameObject.tag != "CoalPile" && other.gameObject.tag != "Coal")
            {
                if (go == true)
                {
                    ContactPoint contact = other.contacts[0];
                    Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                    Vector3 pos = contact.point;
                    GameObject sound = Instantiate(soundPrefab, pos, rot) as GameObject;
                    Destroy(sound, 1f);
                    go = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        go = true;
    }
}
