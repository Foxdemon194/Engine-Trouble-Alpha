using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainDialogueEvents : MonoBehaviour
{
    public AudioClip fire;
    public AudioClip[] funStuff;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip half;

    public BasicTutorialDialogue tutorial;
    public Progress prog;

    float duration = 0;
    float t = 0;
    bool playing;
    bool played;

    int randClip;
    public float randTimeMin;
    public float randTimeMax;
    float randTime = 0;
    float rT;

    private void Start()
    {
        RandTime();
    }

    private void Update()
    {
        if (t <= duration)
        {
            playing = true;
            t += Time.deltaTime;
        }
        else
        {
            playing = false;
        }

        if (tutorial.done)
        {
            if (!playing)
            {
                randTime += Time.deltaTime;

                if (GameObject.FindGameObjectWithTag("Fire") == true && !played)
                {
                    played = true;
                    t = 0;
                    duration = 5.1f;
                    tutorial.speaker1.clip = fire;
                    tutorial.speaker2.clip = fire;
                    tutorial.speaker3.clip = fire;
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                    RandTime();
                }
                else if (GameObject.FindGameObjectWithTag("Fire") == false)
                {
                    played = false;
                }

                if (prog.progress.value == prog.progress.maxValue / 2)
                {
                    t = 0;
                    duration = 5.5f;
                    tutorial.speaker1.clip = half;
                    tutorial.speaker2.clip = half;
                    tutorial.speaker3.clip = half;
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                    RandTime();
                }

                if (prog.wining)
                {
                    t = 0;
                    duration = 3;
                    tutorial.speaker1.clip = win;
                    tutorial.speaker2.clip = win;
                    tutorial.speaker3.clip = win;
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                }

                if (prog.losing)
                {
                    t = 0;
                    duration = 5.5f;
                    tutorial.speaker1.clip = lose;
                    tutorial.speaker2.clip = lose;
                    tutorial.speaker3.clip = lose;
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                }

                if (randTime >= rT)
                {
                    if (randClip == 0)
                    {
                        t = 0;
                        duration = 10;
                        tutorial.speaker1.clip = funStuff[randClip];
                        tutorial.speaker2.clip = funStuff[randClip];
                        tutorial.speaker3.clip = funStuff[randClip];
                        tutorial.speaker1.Play();
                        tutorial.speaker2.Play();
                        tutorial.speaker3.Play();
                        RandTime();
                    }

                    if (randClip == 1)
                    {
                        t = 0;
                        duration = 8.3f;
                        tutorial.speaker1.clip = funStuff[randClip];
                        tutorial.speaker2.clip = funStuff[randClip];
                        tutorial.speaker3.clip = funStuff[randClip];
                        tutorial.speaker1.Play();
                        tutorial.speaker2.Play();
                        tutorial.speaker3.Play();
                        RandTime();
                    }

                    if (randClip == 3)
                    {
                        t = 0;
                        duration = 11.3f;
                        tutorial.speaker1.clip = funStuff[randClip];
                        tutorial.speaker2.clip = funStuff[randClip];
                        tutorial.speaker3.clip = funStuff[randClip];
                        tutorial.speaker1.Play();
                        tutorial.speaker2.Play();
                        tutorial.speaker3.Play();
                        RandTime();
                    }
                }
            }
        }
    }

    void RandTime()
    {
        rT = Random.Range(randTimeMin, randTimeMax);
        randClip = Random.Range(0, funStuff.Length);
    }
}
