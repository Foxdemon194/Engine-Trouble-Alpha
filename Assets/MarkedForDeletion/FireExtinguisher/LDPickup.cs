using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LDPickup : MonoBehaviour
{
    public GameObject Water;
    public GameObject WaterHitbox;
    public GameObject[] Fuel; 

    public int extinguisherFuel = 9;
    public int destroyMeter = 8;
    public int diferenceFuelMeter = 1;
    int currentMeter;

    void Start()
    {
        currentMeter = Fuel.Length - 1;

        Water.SetActive(false);
        WaterHitbox.SetActive(false);
    }

    void Update()
    {
        if(extinguisherFuel == destroyMeter)
        {
            Fuel[currentMeter].gameObject.SetActive(false);
            destroyMeter = destroyMeter - 1;
            currentMeter--;
        }
    }

    public void ShootWater()
    {
        if (extinguisherFuel > 0)
        {
            Water.SetActive(true);
            WaterHitbox.SetActive(true);
            StartCoroutine("LoseFuel");
        }
    }

    public void StopWater()
    {
        Water.SetActive(false);
        WaterHitbox.SetActive(false);
        StopCoroutine("LoseFuel");
    }

    public IEnumerator LoseFuel()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            extinguisherFuel--;

            if (extinguisherFuel <= 0)
                StopWater();
        }
    }
}
