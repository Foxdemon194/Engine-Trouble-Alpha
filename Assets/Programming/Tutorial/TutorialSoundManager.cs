using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;


public class TutorialSoundManager : MonoBehaviour
{
    public static int step = 1;

    public AudioSource playerAudio;
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;
    public AudioClip step4;
    public AudioClip step5;
    public AudioClip step6;
    public AudioClip step7;
    public AudioClip step8;
    public AudioClip step9;
    public AudioClip step10;
    public AudioClip step11;
    public AudioClip step12;
    public AudioClip step13;
    public AudioClip step14;

    public GameObject collision1;
    public XRGrabInteractable hammerScript;

    bool trigger = false;

    public float timer = 0f;

    public void Update()
    {
        timer += Time.deltaTime;

        switch (step)
        {
            case 1:
                if(timer > 1)
                {
                    playStepSound();
                    if (timer > 17 && trigger == false)
                    {
                        collision1.SetActive(true);
                    }
                }
                break;

            case 2:
                //playStepSound();
                playerAudio.clip = step2;
                playerAudio.Play();
                break;

            case 3:
                playerAudio.clip = step3;
                playerAudio.Play();
                break;

            case 4:
                playerAudio.clip = step4;
                playerAudio.Play();
                break;

            case 5:
                playerAudio.clip = step5;
                playerAudio.Play();
                break;

            case 6:
                playerAudio.clip = step6;
                playerAudio.Play();
                break;

            case 7:
                playerAudio.clip = step7;
                playerAudio.Play();
                break;

            case 8:
                playerAudio.clip = step8;
                playerAudio.Play();
                break;

            case 9:
                playerAudio.clip = step9;
                playerAudio.Play();
                break;

            case 10:
                playerAudio.clip = step10;
                playerAudio.Play();
                break;

            case 11:
                playerAudio.clip = step11;
                playerAudio.Play();
                break;

            case 12:
                playerAudio.clip = step12;
                playerAudio.Play();
                break;

            case 13:
                playerAudio.clip = step13;
                playerAudio.Play();
                break;

            case 14:
                playerAudio.clip = step14;
                playerAudio.Play();
                break;
        }
    }

    public void playStepSound()
    {
        switch (step)
        {
            case 1:
                playerAudio.clip = step1;
                playerAudio.Play();
                break;

            case 2:
                playerAudio.clip = step2;
                playerAudio.Play();
                break;

            case 3:
                playerAudio.clip = step3;
                playerAudio.Play();
                break;

            case 4:
                playerAudio.clip = step4;
                playerAudio.Play();
                break;

            case 5:
                playerAudio.clip = step5;
                playerAudio.Play();
                break;

            case 6:
                playerAudio.clip = step6;
                playerAudio.Play();
                break;

            case 7:
                playerAudio.clip = step7;
                playerAudio.Play();
                break;

            case 8:
                playerAudio.clip = step8;
                playerAudio.Play();
                break;

            case 9:
                playerAudio.clip = step9;
                playerAudio.Play();
                break;

            case 10:
                playerAudio.clip = step10;
                playerAudio.Play();
                break;

            case 11:
                playerAudio.clip = step11;
                playerAudio.Play();
                break;

            case 12:
                playerAudio.clip = step12;
                playerAudio.Play();
                break;

            case 13:
                playerAudio.clip = step13;
                playerAudio.Play();
                break;

            case 14:
                playerAudio.clip = step14;
                playerAudio.Play();
                break;
        }
    }
}
