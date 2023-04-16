using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomDialogue : MonoBehaviour
{
    public static int clipNum;
    public AudioClip[] intro;
    public AudioSource speaker;
    float delay = 5;
    float time;
    bool play;

    private void Start()
    {
        play = true;
    }

    private void Update()
    {
        if (clipNum >= intro.Length)
        {
            clipNum = intro.Length;
        }

        StartClip();
    }

    void StartClip()
    {
        if (play)
        {
            time += Time.deltaTime;

            if (time >= delay)
            {
                play = false;
                speaker.clip = intro[clipNum];
                speaker.Play();
            }
        }
    }
}
