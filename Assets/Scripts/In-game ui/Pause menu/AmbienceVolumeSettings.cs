using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AmbienceVolumeSettings : MonoBehaviour
{
    public Slider audioSlider;
    public AudioMixer mixer;
    public AudioSource[] audioSource;
    public Text text;

    private void Start()
    {
        mixer.SetFloat("Ambience Volume", Mathf.Log10(PlayerPrefs.GetFloat("Ambience Volume", 1) * 20));

        audioSlider.value = PlayerPrefs.GetFloat("Ambience Volume");
        text.text = (audioSlider.value * 100).ToString("N0");
    }

    public void OnChangeSlider(float value)
    {
        text.text = (value * 100).ToString("N0");
        mixer.SetFloat("Ambience Volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("Ambience Volume", value);
        PlayerPrefs.Save();
    }
}
