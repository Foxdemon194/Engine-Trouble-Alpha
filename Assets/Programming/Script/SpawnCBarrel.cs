using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
public class SpawnCBarrel : MonoBehaviour
{
    public GameObject prefab;       //The coal barrel that will be spawned
    public float spawnDelay = 3;        //How long the script will wait before spawning another barrel
    float t;

    void Update()
    {
        //Will spawn a coal barrel if the one in the scene is destroyed
        if (GameObject.FindGameObjectWithTag("Barrel") == null)
        {
            t += Time.deltaTime;

            if (t >= spawnDelay)
            {
                Instantiate(prefab, this.transform.position, Quaternion.identity);
                t = 0;
            }
        }
    }
}
