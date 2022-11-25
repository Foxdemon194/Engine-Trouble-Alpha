using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

// type the code in comments to play a sound
//AudioManager.Play(sounds name here);

public class AudioManager : MonoBehaviour
{
    static Dictionary<string, Sound> sounds;
    public List<Sound> soundsList;
    public GameObject dontKillMeBro;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(dontKillMeBro);
            return;
        }

        DontDestroyOnLoad(dontKillMeBro);
        sounds = new();
        foreach (Sound s in soundsList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if (sounds.ContainsKey(s.name))
            {
                print("name " + s.name + " taken");
                continue;
            }

            sounds.Add(s.name, s);
        }
    }

    private void Start()
    {
        Play("MainSong");
    }

    public static void Play(string name)
    {
        sounds[name].source.Play();
    }

    public void ClickMe()
    {
        AudioManager.Play("UISound2");
    }


}
