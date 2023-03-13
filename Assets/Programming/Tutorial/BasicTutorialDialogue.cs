using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BasicTutorialDialogue : MonoBehaviour
{
    int interval = 0;
    float nextTime = 10;
    int dialogueNumber;

    public AudioSource playerAudioS;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public AudioClip clip8;
    public AudioClip clip9;
    public AudioClip clip10;
    public AudioClip clip11;
    public AudioClip clip12;
    public AudioClip clip13;
    public AudioClip clip14;
    public AudioClip clip15;
    public AudioClip clip16;
    public AudioClip clip17;
    public AudioClip clip18;
    public AudioClip clip19;
    public AudioClip clip20;
    public AudioClip clip21;
    public AudioClip clip22;

    // Start is called before the first frame update
    void Start()
    {
        dialogueNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            dialogueNumber++;
            Diologue();
            nextTime += interval;
        }
    }

    public void Diologue()
    {
        if (dialogueNumber == 1)
        {
            interval = 16;
            playerAudioS.clip = clip1;
            playerAudioS.Play();
        }
        if (dialogueNumber == 2)
        {
            interval = 12;
            playerAudioS.clip = clip2;
            playerAudioS.Play();
        }
        if (dialogueNumber == 3)
        {
            interval = 22;
            playerAudioS.clip = clip3;
            playerAudioS.Play();
        }
        if (dialogueNumber == 4)
        {
            interval = 5;
            playerAudioS.clip = clip4;
            playerAudioS.Play();
        }
        if (dialogueNumber == 5)
        {
            interval = 25;
            playerAudioS.clip = clip5;
            playerAudioS.Play();
        }
        if (dialogueNumber == 6)
        {
            interval = 3;
            playerAudioS.clip = clip6;
            playerAudioS.Play();
        }
        if (dialogueNumber == 7)
        {
            interval = 6;
            playerAudioS.clip = clip7;
            playerAudioS.Play();
        }
        if (dialogueNumber == 8)
        {
            interval = 10;
            playerAudioS.clip = clip8;
            playerAudioS.Play();
        }
        if (dialogueNumber == 9)
        {
            interval = 27;
            playerAudioS.clip = clip9;
            playerAudioS.Play();
        }
        if (dialogueNumber == 10)
        {
            interval = 14;
            playerAudioS.clip = clip10;
            playerAudioS.Play();
        }
        if (dialogueNumber == 11)
        {
            interval = 16;
            playerAudioS.clip = clip11;
            playerAudioS.Play();
        }
        if (dialogueNumber == 12)
        {
            interval = 18;
            playerAudioS.clip = clip12;
            playerAudioS.Play();
        }
        if (dialogueNumber == 13)
        {
            interval = 14;
            playerAudioS.clip = clip13;
            playerAudioS.Play();
        }
        if (dialogueNumber == 14)
        {
            interval = 13;
            playerAudioS.clip = clip14;
            playerAudioS.Play();
        }
        if (dialogueNumber == 15)
        {
            interval = 17;
            playerAudioS.clip = clip15;
            playerAudioS.Play();
        }
        if (dialogueNumber == 16)
        {
            interval = 15;
            playerAudioS.clip = clip16;
            playerAudioS.Play();
        }
        if (dialogueNumber == 17)
        {
            interval = 15;
            playerAudioS.clip = clip17;
            playerAudioS.Play();
        }
        if (dialogueNumber == 18)
        {
            interval = 20;
            playerAudioS.clip = clip18;
            playerAudioS.Play();
        }
        if (dialogueNumber == 19)
        {
            interval = 10;
            playerAudioS.clip = clip19;
            playerAudioS.Play();
        }
        if (dialogueNumber == 20)
        {
            interval = 13;
            playerAudioS.clip = clip20;
            playerAudioS.Play();
        }
        if (dialogueNumber == 21)
        {
            interval = 13;
            playerAudioS.clip = clip21;
            playerAudioS.Play();
        }
        if (dialogueNumber == 22)
        {
            interval = 15;
            playerAudioS.clip = clip22;
            playerAudioS.Play();
        }
    }
}