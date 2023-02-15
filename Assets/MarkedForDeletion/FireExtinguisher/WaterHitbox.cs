using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHitbox : MonoBehaviour
{
    int timeFire = 2;
    int time = 0;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            StartCoroutine("LoseFuel");
            if (time == timeFire)
            {
                Debug.Log(other.gameObject);
                Destroy(other.gameObject);
                StopCoroutine("LoseFuel");
                time = 0;
            }
        }
    }

    public IEnumerator LoseFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}