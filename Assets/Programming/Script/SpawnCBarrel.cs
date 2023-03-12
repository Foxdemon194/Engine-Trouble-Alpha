using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
public class SpawnCBarrel : MonoBehaviour
{
    public GameObject prefab;       //The coal barrel that will be spawned

    void Update()
    {
        //Will spawn a coal barrel if the one in the scene is destroyed
        if (GameObject.FindGameObjectWithTag("Barrel") == null)
        {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
        }
    }
}
