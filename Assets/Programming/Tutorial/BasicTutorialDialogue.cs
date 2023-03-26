using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

/// <summary>
/// script written by Andres Lopez
/// adjusted / implemented by Ralfo (Tony) Manzur
/// </summary>

public class BasicTutorialDialogue : MonoBehaviour
{
    public int interval = 0;
    public float nextTime = 10;
    public int dialogueNumber;
    //public int DN = 0;

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
    public AudioClip status1;
    public AudioClip status2;
    public AudioClip blank1;
    public AudioClip blank2;
    public AudioClip blank3;
    public AudioClip blank4;
    public AudioClip blank5;
    public AudioClip blank6;
    public AudioClip blank7;

    public bool cont;
    //public bool cont2;

    // Start is called before the first frame update
    void Start()
    {
        dialogueNumber = 0;
        cont = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cont == true)
        {
            if (Time.time >= nextTime)
            {
                dialogueNumber++;
                Diologue();
                nextTime += interval;
            }
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
            interval = 18;
            playerAudioS.clip = clip3;
            playerAudioS.Play();
            cont = false;
        }
        if (dialogueNumber == 4)
        {
            interval = 3;
            playerAudioS.clip = blank1;
            playerAudioS.Play();
        }
        if (dialogueNumber == 5)
        {
            interval = 5;
            playerAudioS.clip = clip4;
            playerAudioS.Play();
        }
        if (dialogueNumber == 6)
        {
            interval = 21;
            playerAudioS.clip = clip5;
            playerAudioS.Play();
            cont = false;
        }
        if (dialogueNumber == 7)
        {
            interval = 3;
            playerAudioS.clip = blank2;
            playerAudioS.Play();
        }
        if (dialogueNumber == 8)
        {
            interval = 3;
            playerAudioS.clip = clip6;
            playerAudioS.Play();
        }
        if (dialogueNumber == 9)
        {
            interval = 6;
            playerAudioS.clip = clip7;
            playerAudioS.Play();
        }
        if (dialogueNumber == 10)
        {
            interval = 11;
            playerAudioS.clip = clip8;
            playerAudioS.Play();
        }
        if (dialogueNumber == 11)
        {
            interval = 15;
            playerAudioS.clip = status1;
            playerAudioS.Play();
        }
        if (dialogueNumber == 12)
        {
            interval = 11;
            playerAudioS.clip = status2;
            playerAudioS.Play();
        }
        if (dialogueNumber == 13)
        {
            interval = 23;
            playerAudioS.clip = clip9;
            playerAudioS.Play();
            cont = false;
        }
        if (dialogueNumber == 14)
        {
            interval = 3;
            playerAudioS.clip = blank3;
            playerAudioS.Play();
        }
        if (dialogueNumber == 15)
        {
            interval = 14;
            playerAudioS.clip = clip10;
            playerAudioS.Play();
        }
        if (dialogueNumber == 16)
        {
            interval = 11;
            playerAudioS.clip = clip11;
            playerAudioS.Play();
        }
        if (dialogueNumber == 17)
        {
            interval = 13;
            playerAudioS.clip = clip12;
            playerAudioS.Play();
            cont = false;
        }
        if (dialogueNumber == 18)
        {
            interval = 3;
            playerAudioS.clip = blank4;
            playerAudioS.Play();
        }
        if (dialogueNumber == 19)
        {
            interval = 15;
            playerAudioS.clip = clip13;
            playerAudioS.Play();
        }
        if (dialogueNumber == 20)
        {
            interval = 9;
            playerAudioS.clip = clip14;
            playerAudioS.Play();
        }
        if (dialogueNumber == 21)
        {
            interval = 13;
            playerAudioS.clip = clip15;
            playerAudioS.Play();
            cont = false;
        }
        if (dialogueNumber == 22)
        {
            interval = 3;
            playerAudioS.clip = blank5;
            playerAudioS.Play();
        }
        if (dialogueNumber == 23)
        {
            interval = 15;
            playerAudioS.clip = clip16;
            playerAudioS.Play();
        }
        if (dialogueNumber == 24)
        {
            interval = 15;
            playerAudioS.clip = clip17;
            playerAudioS.Play();
        }
        if (dialogueNumber == 25)
        {
            interval = 16;
            playerAudioS.clip = clip18;
            playerAudioS.Play();
            cont = false;
        }
        if (dialogueNumber == 26)
        {
            interval = 3;
            playerAudioS.clip = blank6;
            playerAudioS.Play();
        }
        if (dialogueNumber == 27)
        {
            interval = 6;
            playerAudioS.clip = clip19;
            playerAudioS.Play();
            cont = false;
        }
        if (dialogueNumber == 28)
        {
            interval = 3;
            playerAudioS.clip = blank7;
            playerAudioS.Play();
        }
        if (dialogueNumber == 29)
        {
            interval = 12;
            playerAudioS.clip = clip20;
            playerAudioS.Play();
        }
        if (dialogueNumber == 30)
        {
            interval = 13;
            playerAudioS.clip = clip21;
            playerAudioS.Play();
        }
        if (dialogueNumber == 31)
        {
            interval = 15;
            playerAudioS.clip = clip22;
            playerAudioS.Play();
        }
    }
}