using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausing : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            pauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
