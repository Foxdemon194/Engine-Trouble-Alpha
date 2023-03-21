using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public AudioSource sound;
    public GameObject Water;
    public GameObject WaterHitbox;
    public ParticleSystem waterParticles;
    //public GameObject[] Fuel; 

    public float extinguisherFuel = 9;
    /*int destroyMeter = 0;
    int timePerSquere = 0;
    int currentMeter;*/

    void Start()
    {
        /*currentMeter = Fuel.Length - 1;
        timePerSquere = extinguisherFuel / currentMeter;
        destroyMeter = extinguisherFuel - timePerSquere;*/

        Water.SetActive(false);
        WaterHitbox.SetActive(false);
    }

    void Update()
    {
        /*if(extinguisherFuel == destroyMeter)
        {
            destroyMeter = extinguisherFuel - timePerSquere;
            Fuel[currentMeter].gameObject.SetActive(false);
            currentMeter--;
        }*/

        if (extinguisherFuel <= 0)
            StopWater();
    }

    public void ShootWater()
    {
        if (extinguisherFuel > 0)
        {
            Water.SetActive(true);
            WaterHitbox.SetActive(true);
            waterParticles.Play();
            sound.Play();
            //extinguisherFuel -= Time.deltaTime;
            StartCoroutine("LoseFuel");
        }
    }

    public void StopWater()
    {
        Water.SetActive(false);
        WaterHitbox.SetActive(false);
        waterParticles.Stop();
        sound.Stop();
        StopCoroutine("LoseFuel");
    }

    public IEnumerator LoseFuel()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            extinguisherFuel -= 0.1f;
            //extinguisherFuel -= Time.deltaTime;

            if (extinguisherFuel <= 0)
                StopWater();
        }
    }
}
