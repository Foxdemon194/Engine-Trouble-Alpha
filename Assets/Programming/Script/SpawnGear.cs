using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
public class SpawnGear : MonoBehaviour
{
    public GameObject prefab;       //The gear that will be spawned
    public float delay = 3f;          //How long it takes for a gear to spawn when one breaks
    float t;

    void Update()
    {
        //Will spawn a pipe when it finds a broken gear in the scene
        //It will spawn one of the many gear models we have
        if (GameObject.FindGameObjectWithTag("BrokenGear") && GameObject.FindGameObjectWithTag("ReplacementGear") == null)
        {
            t += Time.deltaTime;
            
            if (t >= delay)
            {
                Instantiate(prefab, this.transform.position, Quaternion.identity);
                t = 0;
            }
        }
    }
}
