using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class newTutorialDialogue : MonoBehaviour
{
    public AudioClip[] Clip;
    public AudioSource aud;
    float delay_time = 0f;

    public int deez = 0;

    public bool cont;
    async void Start()
    {
        foreach (AudioClip n in Clip)
        {
            await Task.Delay((int)delay_time * 1000); //Task.Delay input is in milliseconds
            playaudio(n);
        }
    }

    void playaudio(AudioClip n)
    {
        cont = true;
        aud.clip = n;
        aud.Play();
        deez++;
        delay_time = n.length + 1;//1 second is added to cater for the loading delay
    }

    void Update()
    {
        if (deez == 3)
        {
            Debug.Log("poawqeiruf[0infwra");
            cont = false;
            aud.Pause();
        }
        /*if (cont == false)
        {
            aud.Play();
        }*/
        /*else
        {
            cont = true;
            delay_time = 1;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Hammer")
        {
            aud.Play();
        }
    }
}