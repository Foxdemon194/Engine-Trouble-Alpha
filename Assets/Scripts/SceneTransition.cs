using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level4");
    }
    public void LoadLevel5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level5");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSettingsScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SettingsScene");
    }

    public void LoadLoadFileSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadFileSelectScene");
    }


    /*  Unpause Method
        public void Continue()
        {
            Time.timeScale = 1f;
            instructionsPanel.SetActive(false);
            gameIsPaused = false;
        }
    */

    public void QuitGame()
    {
        Application.Quit();
    }
}
