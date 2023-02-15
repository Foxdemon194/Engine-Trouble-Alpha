using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSupply : MonoBehaviour
{
    public GameObject prefab;

    public void Create()
    {
        Instantiate(prefab, this.transform.position, Quaternion.identity);
    }
}
