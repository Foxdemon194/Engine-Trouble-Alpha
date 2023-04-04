using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

/// <summary>
/// script written by Andres Lopez
/// adjusted / implemented by Ralfo (Tony) Manzur
/// with help from Joshua Rosa and Pedro Terra
/// </summary>

public class BasicTutorialDialogue : MonoBehaviour
{
    public int interval = 0;
    public float nextTime = 10;
    public int dialogueNumber;
    //public int DN = 0;

    public GameObject boiler1;

    public AudioSource speaker1;
    public AudioSource speaker2;
    public AudioSource speaker3;
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

    public GameObject[] colliderGroups;
    public GameObject[] triggerGroups;

    public float Timer = 0.0f;

    public bool cont;

    public bool continousPlay;
    //public bool cont2;

    // Start is called before the first frame update
    void Start()
    {
        dialogueNumber = 0;
        cont = true;
        continousPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (cont == true)
        {
            if (Time.time >= nextTime)
            {
                dialogueNumber++;
                Diologue();
                nextTime += interval;
            }
        }*/

        if (cont == true)
        {
            if (Timer <= interval)
            {
                Timer += Time.deltaTime;
            }
            else
            {
                dialogueNumber++;
                cont = false;
                if (continousPlay == true)
                {
                    Diologue();
                }
            }
        }
    }

    public void Diologue()
    {
        Timer = 0.0f;
        cont = true;
        //Change all dialogue numbers up by one for each trigger event, like with wrench (3 to 5)
        if (dialogueNumber == 1)
        {
            NextBox();
            Timer = 0.0f;
            interval = 16;
            speaker1.clip = clip1;
            speaker1.Play();
            speaker2.clip = clip1;
            speaker2.Play();
            speaker3.clip = clip1;
            speaker3.Play();
            continousPlay = false;
            //welcome to first day
        }
        if (dialogueNumber == 2)
        {
            interval = 12;
            speaker1.clip = clip2;
            speaker1.Play();
            speaker2.clip = clip2;
            speaker2.Play();
            speaker3.clip = clip2;
            speaker3.Play();
            //this is storage room
        }
        if (dialogueNumber == 3)
        {
            NextBox();
            interval = 18;
            speaker1.clip = clip3;
            speaker1.Play();
            speaker2.clip = clip3;
            speaker2.Play();
            speaker3.clip = clip3;
            speaker3.Play();
            continousPlay = false;
            boiler1.GetComponentInChildren<Pressure>().sPressure = 100;
            //check when barrel breaks or pipes
        }
        if (dialogueNumber == 5)
        {
            interval = 5;
            speaker1.clip = clip4;
            speaker1.Play();
            speaker2.clip = clip4;
            speaker2.Play();
            speaker3.clip = clip4;
            speaker3.Play();
            //good job
        }
        if (dialogueNumber == 6)
        {
            NextBox();
            interval = 21;
            speaker1.clip = clip5;
            speaker1.Play();
            speaker2.clip = clip5;
            speaker2.Play();
            speaker3.clip = clip5;
            speaker3.Play();
            continousPlay = false;
            //wrench and valves
        }
        if (dialogueNumber == 8)
        { 
            interval = 3;
            speaker1.clip = clip6;
            speaker1.Play();
            speaker2.clip = clip6;
            speaker2.Play();
            speaker3.clip = clip6;
            speaker3.Play();
            //knew you could do it
        }
        if (dialogueNumber == 9)
        {
            NextBox();
            interval = 6;
            speaker1.clip = clip7;
            speaker1.Play();
            speaker2.clip = clip7;
            speaker2.Play();
            speaker3.clip = clip7;
            speaker3.Play();
            //mentions oil
        }
        if (dialogueNumber == 10)
        {
            NextBox();
            interval = 11;
            speaker1.clip = clip8;
            speaker1.Play();
            speaker2.clip = clip8;
            speaker2.Play();
            speaker3.clip = clip8;
            speaker3.Play();
            //this is the boiler room
        }
        if (dialogueNumber == 11)
        {
            NextBox();
            interval = 15;
            speaker1.clip = status1;
            speaker1.Play();
            speaker2.clip = status1;
            speaker2.Play();
            speaker3.clip = status1;
            speaker3.Play();
            //status board stuff
        }
        if (dialogueNumber == 12)
        {
            NextBox();
            interval = 11;
            speaker1.clip = status2;
            speaker1.Play();
            speaker2.clip = status2;
            speaker2.Play();
            speaker3.clip = status2;
            speaker3.Play();
            //status board stuff, but about the color i guess
        }
        if (dialogueNumber == 13)
        {
            NextBox();
            interval = 23;
            speaker1.clip = clip9;
            speaker1.Play();
            speaker2.clip = clip9;
            speaker2.Play();
            speaker3.clip = clip9;
            speaker3.Play();
            continousPlay = false;
            //adding coal to boiler
        }
        if (dialogueNumber == 15)
        {
            interval = 14;
            speaker1.clip = clip10;
            speaker1.Play();
            speaker2.clip = clip10;
            speaker2.Play();
            speaker3.clip = clip10;
            speaker3.Play();
            //leaving the shovel in the room
        }
        if (dialogueNumber == 16)
        {
            NextBox();
            interval = 11;
            speaker1.clip = clip11;
            speaker1.Play();
            speaker2.clip = clip11;
            speaker2.Play();
            speaker3.clip = clip11;
            speaker3.Play();
            //go upstairs for water input
        }
        if (dialogueNumber == 17)
        {
            NextBox();
            interval = 13;
            speaker1.clip = clip12;
            speaker1.Play();
            speaker2.clip = clip12;
            speaker2.Play();
            speaker3.clip = clip12;
            speaker3.Play();
            continousPlay = false;
            //Water input
        }
        if (dialogueNumber == 19)
        {
            interval = 15;
            speaker1.clip = clip13;
            speaker1.Play();
            speaker2.clip = clip13;
            speaker2.Play();
            speaker3.clip = clip13;
            speaker3.Play();
            //cooling engine with water and heating with coal
        }
        if (dialogueNumber == 20)
        {
            NextBox();
            interval = 9;
            speaker1.clip = clip14;
            speaker1.Play();
            speaker2.clip = clip14;
            speaker2.Play();
            speaker3.clip = clip14;
            speaker3.Play();
            //go downstairs with wrench
        }
        if (dialogueNumber == 21)
        {
            NextBox();
            interval = 13;
            speaker1.clip = clip15;
            speaker1.Play();
            speaker2.clip = clip15;
            speaker2.Play();
            speaker3.clip = clip15;
            speaker3.Play();
            continousPlay = false;
            //Wrench and valves again
        }
        if (dialogueNumber == 23)
        {
            interval = 15;
            speaker1.clip = clip16;
            speaker1.Play();
            speaker2.clip = clip16;
            speaker2.Play();
            speaker3.clip = clip16;
            speaker3.Play();
            //nicely done
        }
        if (dialogueNumber == 24)
        {
            NextBox();
            interval = 15;
            speaker1.clip = clip17;
            speaker1.Play();
            speaker2.clip = clip17;
            speaker2.Play();
            speaker3.clip = clip17;
            speaker3.Play();
            //speed and time
        }
        if (dialogueNumber == 25)
        {
            NextBox();
            interval = 16;
            speaker1.clip = clip18;
            speaker1.Play();
            speaker2.clip = clip18;
            speaker2.Play();
            speaker3.clip = clip18;
            speaker3.Play();
            continousPlay = false;
            //Boost lever
        }
        if (dialogueNumber == 27)
        {
            interval = 6;
            speaker1.clip = clip19;
            speaker1.Play();
            speaker2.clip = clip19;
            speaker2.Play();
            speaker3.clip = clip19;
            speaker3.Play();
            continousPlay = false;
            //fire
        }
        if (dialogueNumber == 29)
        {
            interval = 12;
            speaker1.clip = clip20;
            speaker1.Play();
            speaker2.clip = clip20;
            speaker2.Play();
            speaker3.clip = clip20;
            speaker3.Play();
            //job well done and explaining the lever
        }
        if (dialogueNumber == 30)
        {
            NextBox();
            interval = 13;
            speaker1.clip = clip21;
            speaker1.Play();
            speaker2.clip = clip21;
            speaker2.Play();
            speaker3.clip = clip21;
            speaker3.Play();
            //fire extinguisher is limited
        }
        if (dialogueNumber == 31)
        {
            NextBox();
            interval = 15;
            speaker1.clip = clip22;
            speaker1.Play();
            speaker2.clip = clip22;
            speaker2.Play();
            speaker3.clip = clip22;
            speaker3.Play();
            //eventful first day huh
        }
    }

    public void Continue()
    {
        continousPlay = true;
        cont = true;
    }

    public void NextBox()
    {
        for (int i = 0; i < colliderGroups.Length; i++)
        {
            colliderGroups[i].SetActive(false);
        }

        for (int i = 0; i <triggerGroups.Length; i++)
        {
            triggerGroups[i].SetActive(false);
        }

        colliderGroups[dialogueNumber - 1].SetActive(true);
        triggerGroups[dialogueNumber - 1].SetActive(true);
    }
}