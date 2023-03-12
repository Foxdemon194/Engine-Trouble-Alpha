using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
public class SpawnGear : MonoBehaviour
{
    public GameObject[] prefab;       //The gear that will be spawned
    int rand;                         //A random number

    void Update()
    {
        //Will spawn a pipe when it finds a broken gear in the scene
        //It will spawn one of the many gear models we have
        if (GameObject.FindGameObjectWithTag("BrokenGear"))
        {
            rand = Random.Range(0, prefab.Length);
            Instantiate(prefab[rand], this.transform.position, Quaternion.identity);
        }
    }
}
