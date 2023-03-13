using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpeaker : MonoBehaviour
{
    public List<AudioSource> speakers = new List<AudioSource>();
    public List<AudioClip> TutorialPack1 = new List<AudioClip>();
    public List<AudioClip> TutorialPack2 = new List<AudioClip>();
    public List<AudioClip> StatusBoard = new List<AudioClip>();

    public void playTutorialPack1(int clip)
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

    public void playTutorialPack2(int clip)
    {
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
            speaker.clip = StatusBoard[clip];
        }
        foreach (AudioSource speaker in speakers)
        {
            speaker.Play();
        }
    }
}
