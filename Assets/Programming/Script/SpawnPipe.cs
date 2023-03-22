using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alejandro's script
public class SpawnPipe : MonoBehaviour
{
    public Transform t1;
    public Transform t2;
    public Transform t3;
    public GameObject prefab1;       //The pipe that will be spawned
    public GameObject prefab2;
    public GameObject prefab3;
    public float spawnDelay = 3;        //How long the script will wait before spawning another barrel
    float time1;
    float time2;
    float time3;

    void Update()
    {
        //Will spawn a pipe when it finds a broken pipe in the scene
        if (GameObject.FindGameObjectWithTag("ReplacePipe1") == null)
        {
            time1 += Time.deltaTime;

            if (time1 >= spawnDelay)
            {
                Instantiate(prefab1, t1.position, Quaternion.identity);
                time1 = 0;
            }
        }
        //Will spawn a pipe when it finds a broken pipe in the scene
        if (GameObject.FindGameObjectWithTag("ReplacePipe2") == null)
        {
            time2 += Time.deltaTime; 
            
            if (time2 >= spawnDelay)
            {
                Instantiate(prefab2, t2.position, Quaternion.identity);
                time2 = 0;
            }
        }
        //Will spawn a pipe when it finds a broken pipe in the scene
        if (GameObject.FindGameObjectWithTag("ReplacePipe3") == null)
        {
            time3 += Time.deltaTime;

            if (time3 >= spawnDelay)
            {
                Instantiate(prefab3, t3.position, Quaternion.identity);
                time3 = 0;
            }
        }
    }
}
