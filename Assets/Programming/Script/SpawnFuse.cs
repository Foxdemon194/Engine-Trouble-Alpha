using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFuse : MonoBehaviour
{
    public GameObject replacement;
    public float spawnDelay = 3;        //How long the script will wait before spawning another barrel
    float t;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Fuse") == null)
        {
            t += Time.deltaTime;

            if (t > spawnDelay)
            {
                Instantiate(replacement, transform.position, Quaternion.identity);
                t = 0;
            }
        }
    }
}
