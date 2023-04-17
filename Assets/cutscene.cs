using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class cutscene : MonoBehaviour
{
    public Animator animator;
    Scene currentScene;
    public AudioSource TitleScreenAmbience;
    public InputActionProperty showButton;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (currentScene.name == "Cutscene") //to disable repeating transition in the main game
        {
            if (showButton.action.WasPressedThisFrame())
            {
                FadeToLevel(1);

            }
        }
    }
    public void FadeToLevel(int levelIndex)
    {
        StartCoroutine(lowerAmbience());
        animator.SetTrigger("FadeOut");

    }
    IEnumerator lowerAmbience()
    {
        while (TitleScreenAmbience.volume > 0)
        {
            TitleScreenAmbience.volume -= 0.15f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Bedroom");
    }
}