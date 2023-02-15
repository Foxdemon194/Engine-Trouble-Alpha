using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideStepUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            //TutorialSoundManager.step++;
            Destroy(gameObject);
        }
    }
}
