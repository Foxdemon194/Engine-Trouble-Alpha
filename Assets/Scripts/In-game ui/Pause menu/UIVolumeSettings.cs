using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIVolumeSettings : MonoBehaviour
{
    public Slider audioSlider;
    public AudioMixer mixer;
    public AudioSource[] audioSource;
    public Text text;

    private void Start()
    {
        mixer.SetFloat("UI Volume", Mathf.Log10(PlayerPrefs.GetFloat("UI Volume", 1) * 20));

        audioSlider.value = PlayerPrefs.GetFloat("UI Volume");
        text.text = (audioSlider.value * 100).ToString("N0");
    }

    public void OnChangeSlider(float value)
    {
        text.text = (value * 100).ToString("N0");
        mixer.SetFloat("UI Volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("UI Volume", value);
        PlayerPrefs.Save();
    }
}
