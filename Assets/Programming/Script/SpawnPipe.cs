using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
public class SpawnPipe : MonoBehaviour
{
    public GameObject[] brokenPipes;
    public GameObject prefab;       //The pipe that will be spawned
    public bool isBroken;

    void Update()
    {
        //Will spawn a pipe when it finds a broken pipe in the scene
        for (int i = 0; i < brokenPipes.Length; i++)
        {
            if (brokenPipes[i].activeSelf && GameObject.FindGameObjectWithTag("ReplacePipe") == null)
            {
                Instantiate(prefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}
