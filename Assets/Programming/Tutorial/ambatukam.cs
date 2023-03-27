using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ambatukam : MonoBehaviour
{
    public AudioClip[] Clip;
    public AudioSource aud;
    float delay_time = 0f;
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
        aud.clip = n;
        aud.Play();
        delay_time = n.length + 1;//1 second is added to cater for the loading delay
    }
}