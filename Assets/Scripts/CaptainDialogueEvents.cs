using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainDialogueEvents : MonoBehaviour
{
    public AudioClip fire;
    public AudioClip[] funStuff;
    public AudioClip[] win;
    int rand;
    public AudioClip lose;
    public AudioClip half;
    public bool halfWay;
    public bool won;
    public bool lost;

    public BasicTutorialDialogue tutorial;
    public Progress prog;

    float duration = 0;
    float t = 0;
    bool playing;
    bool played;

    public int randClip;
    public float randTimeMin;
    public float randTimeMax;
    public float randTime = 0;
    public float rT;

    public bool level2;
    public bool clip1;
    public bool clip2;
    public AudioClip gears;
    public AudioClip oil;

    public bool level3;
    public bool clip3;
    public AudioClip light;
    public AudioClip[] lights;
    public LightsOut shutOff;
    int randLight;

    bool stop;
    bool stop2;

    private void Start()
    {
        RandTime();
        RandomWin();
        RandomLights();
    }

    private void Update()
    {
        if (prog.progressValue >= prog.progress.maxValue / 2 && !stop)
        {
            halfWay = true;
            stop = true;
        }

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

                if (won)
                {
                    won = false;
                    t = 0;
                    duration = 3;
                    tutorial.speaker1.clip = win[rand];
                    tutorial.speaker2.clip = win[rand];
                    tutorial.speaker3.clip = win[rand];
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                    this.enabled = false;
                }

                if (lost)
                {
                    lost = false;
                    t = 0;
                    duration = 5.5f;
                    tutorial.speaker1.clip = lose;
                    tutorial.speaker2.clip = lose;
                    tutorial.speaker3.clip = lose;
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                    this.enabled = false;
                }

                if (halfWay)
                {
                    halfWay = false;
                    t = 0;
                    duration = 5.5f;
                    tutorial.speaker1.clip = half;
                    tutorial.speaker2.clip = half;
                    tutorial.speaker3.clip = half;
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                }

                if (level2)
                {
                    tutorial.Unlock2();

                    if (clip1)
                    {
                        clip1 = false;
                        played = true;
                        t = 0;
                        duration = 8f;
                        tutorial.speaker1.clip = gears;
                        tutorial.speaker2.clip = gears;
                        tutorial.speaker3.clip = gears;
                        tutorial.speaker1.Play();
                        tutorial.speaker2.Play();
                        tutorial.speaker3.Play();
                    }
                    else if (clip2)
                    {
                        clip2 = false;
                        played = true;
                        t = 0;
                        duration = 5.5f;
                        tutorial.speaker1.clip = oil;
                        tutorial.speaker2.clip = oil;
                        tutorial.speaker3.clip = oil;
                        tutorial.speaker1.Play();
                        tutorial.speaker2.Play();
                        tutorial.speaker3.Play();
                        RandTime();
                        tutorial.done = true;
                    }

                    if (!clip1 && !clip2)
                    {
                        level2 = false;
                    }
                }

                if (level3)
                {
                    tutorial.Unlock2();

                    if (clip3)
                    {
                        clip3 = false;
                        played = true;
                        t = 0;
                        duration = 11f;
                        tutorial.speaker1.clip = light;
                        tutorial.speaker2.clip = light;
                        tutorial.speaker3.clip = light;
                        tutorial.speaker1.Play();
                        tutorial.speaker2.Play();
                        tutorial.speaker3.Play();
                    }

                    if (!clip3)
                    {
                        level3 = false;
                    }
                }

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

                if (shutOff.brokenFuse == true && !stop2)
                {
                    played = true;
                    stop2 = true;
                    t = 0;
                    duration = 6.5f;
                    tutorial.speaker1.clip = lights[randLight];
                    tutorial.speaker2.clip = lights[randLight];
                    tutorial.speaker3.clip = lights[randLight];
                    tutorial.speaker1.Play();
                    tutorial.speaker2.Play();
                    tutorial.speaker3.Play();
                    RandTime();
                    RandomLights();
                }
                else if (shutOff.brokenFuse == false)
                {
                    played = false;
                    stop2 = false;
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
                        randTime = 0;
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
                        randTime = 0;
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
                        randTime = 0;
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

    void RandomWin()
    {
        rand = Random.Range(0, win.Length);
    }

    void RandomLights()
    {
        randLight = Random.Range(0,lights.Length);
    }
}
