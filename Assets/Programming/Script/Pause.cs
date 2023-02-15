using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject wristUI;
    public bool activateUI = true;

    public float modifiedTime = 1f;

    void Start()
    {
        DisplayUI();
    }

    void Update()
    {
        Time.timeScale = modifiedTime;
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayUI();
    }

    public void DisplayUI()
    {
        if (activateUI)
        {
            wristUI.SetActive(false);
            activateUI = false;
            modifiedTime = 1f;
        }

        else if (!activateUI)
        {
            wristUI.SetActive(true);
            activateUI = true;
            modifiedTime = 0f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
