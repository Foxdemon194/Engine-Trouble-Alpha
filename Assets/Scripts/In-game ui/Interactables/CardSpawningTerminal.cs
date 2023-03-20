using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardSpawningTerminal : MonoBehaviour
{
    public GameObject objPrefab;
    public Transform spawnPoint;

    public void SpawnObject()
    {
        Instantiate(objPrefab, spawnPoint.position, Quaternion.identity);
    }
}
