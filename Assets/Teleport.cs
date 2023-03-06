using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("AAAAAAA");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("AAAAAAA");
            SceneManager.LoadScene("Level1");
        }
            
    }

}
