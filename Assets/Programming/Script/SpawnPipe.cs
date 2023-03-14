using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
public class SpawnPipe : MonoBehaviour
{
    public GameObject prefab;       //The pipe that will be spawned

    void Update()
    {
        //Will spawn a pipe when it finds a broken pipe in the scene
        if (GameObject.FindGameObjectWithTag("BrokenPipe") && GameObject.FindGameObjectWithTag("ReplacePipe") == null)
        {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
        }
    }
}
