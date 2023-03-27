using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Toggle subtitleToggle;
    //public Text subtitleText;
    public GameObject pauseCanvas;

    public InputActionProperty showButton;
    public Transform head;
    public float menuDistance = 2;

    private void Start()
    {
        var _toggleSub = PlayerPrefs.GetInt("toggles",0) == 1; //load sub toggle setting
        if (_toggleSub)
        {
            subtitleToggle.isOn = true;
        }
        else if (!_toggleSub)
        {
            subtitleToggle.isOn = false;
        }

    }
     void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else 
                Time.timeScale = 0;
            if (AudioListener.pause == true)
                AudioListener.pause = false;
            else
                AudioListener.pause = true;


            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            pauseCanvas.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * menuDistance;
            pauseCanvas.transform.rotation = head.transform.rotation;
        }

        if (subtitleToggle.isOn)
        {
            //subtitleText.enabled = true;
        }
        else if (!subtitleToggle.isOn)
        {
            //subtitleText.enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        //Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Bedroom");
    }

    public void QuitToDesktop()
    {
        //SceneManager.LoadScene();
    }

    public void SubtitleToggle(bool toggle)
    {

        subtitleToggle.isOn = toggle;
        PlayerPrefs.SetInt("toggles", (toggle ? 1 : 0));
        PlayerPrefs.Save(); //save sub toggle setting
    }
}
