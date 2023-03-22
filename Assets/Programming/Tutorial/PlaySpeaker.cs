using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpeaker : MonoBehaviour
{
    public List<AudioSource> speakers = new List<AudioSource>();
    public List<AudioClip> TutorialLines = new List<AudioClip>();
    public List<AudioClip> RandomDialogue = new List<AudioClip>();
    public List<AudioClip> StatusBoardLines = new List<AudioClip>();
    public List<AudioClip> Warnings = new List<AudioClip>();

    public void playTutorialLine(int clip)
    {
        foreach (AudioSource speaker in speakers)        //Loading all the clips seperately to playing so they start at the same time
        {
            speaker.clip = TutorialPack1[clip];
        }
        foreach (AudioSource speaker in speakers)
        {
            speaker.Play();
        }
    }

    public void playRandomDialogue()
    {
        int clip = (int)UnityEngine.Random.Range(0, sounds.RandomDialogue.Count+1) //Randomly selects one of the random dialogues. casting float to int truncates decimal so the +1 is needed to access the final clip.
        foreach (AudioSource speaker in speakers)
        {
            speaker.clip = TutorialPack2[clip];
        }
        foreach (AudioSource speaker in speakers)
        {
            speaker.Play();
        }
    }

    public void playStatusBoard(int clip)
    {
        foreach (AudioSource speaker in speakers)
        {
            speaker.clip = StatusBoardLines[clip];
        }
        foreach (AudioSource speaker in speakers)
        {
            speaker.Play();
        }
    }

    public void playWarning(int clip)
    {
        foreach (AudioSource speaker in speakers)
        {
            speaker.clip = StatusBoardLines[clip];
        }
        foreach (AudioSource speaker in speakers)
        {
            speaker.Play();
        }
    }
}
