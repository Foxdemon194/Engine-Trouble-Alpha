using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;

public class Progress : MonoBehaviour
{
    public GameObject headUI;
    public GameObject loseText;
    public GameObject winText;
    public Slider progress;
    public Pressure[] pressure;////////////////////////////////////////////
    
    public BreakGear gearController;

    public XRRayInteractor leftController;
    public XRRayInteractor rightController;

    public XRInteractorLineVisual leftControllerVisual;
    public XRInteractorLineVisual rightControllerVisual;

    private float averagePressure = 0; ////////////////////////////////////////
    float total = 0;///////////////////////////////////////////////////////

    public float speed = 0.007f; 
    public float normalSpeed = 0.005f;
    public float lowSpeed = 0.004f;
    public float higSpeed = 0.01f;

    public float loseTime = 60;
    private float countloseTime;

    //Pause 
    public GameObject wristUI;
    public bool activateUI = true;
    public float modifiedTime = 1f;


    public bool bostLever = false;

    // Start is called before the first frame update
    void Start()
    {
        countloseTime = loseTime;
        headUI.SetActive(false);
        loseText.SetActive(false);
        winText.SetActive(false);

        DisplayUI();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = modifiedTime;

        //Calculate the averagePressure of the Pressure Scripts
        total = 0;
        foreach (Pressure obj in pressure)
        {
            total += obj.sPressure;
        }
        averagePressure = total / pressure.Length;

        progress.value += speed;

        /* fix later
        if (gearController.broken == true)
        {
            speed = 0;
            countloseTime -= Time.deltaTime;
        }
        */
        if (averagePressure <= 10)
        {
            speed = 0;
            countloseTime -= Time.deltaTime;
        }
        else if (averagePressure > 10 && averagePressure <= 25)
        {
            speed = lowSpeed;
            countloseTime = loseTime;
        }
        else if (averagePressure > 25 && averagePressure < 85)
        {
            speed = normalSpeed;
            countloseTime = loseTime;
        }
        else if (averagePressure >= 85)
        {
            speed = higSpeed;
            countloseTime = loseTime;
        }

        if (countloseTime <= 0) 
        {
            headUI.SetActive(true);
            loseText.SetActive(true);
            modifiedTime = 0;
            leftController.maxRaycastDistance = 3f;
            leftControllerVisual.lineLength = 3f;
            rightController.maxRaycastDistance = 3f;
            rightControllerVisual.lineLength = 3f;
        }

        if (progress.value == 100)
        {
            headUI.SetActive(true);
            winText.SetActive(true);
            modifiedTime = 0;
            leftController.maxRaycastDistance = 3f;
            leftControllerVisual.lineLength = 3f;
            rightController.maxRaycastDistance = 3f;
            rightControllerVisual.lineLength = 3f;
        }
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
            leftController.maxRaycastDistance = 0.5f;
            leftControllerVisual.lineLength = 0f;
            rightController.maxRaycastDistance = 0.5f;
            rightControllerVisual.lineLength = 0f;
        }

        else if (!activateUI)
        {
            wristUI.SetActive(true);
            activateUI = true;
            modifiedTime = 0;
            leftController.maxRaycastDistance = 3f;
            leftControllerVisual.lineLength = 3f;
            rightController.maxRaycastDistance = 3f;
            rightControllerVisual.lineLength = 3f;
        }
    }

    public void BedRoom()
    {
        SceneManager.LoadScene("Bedroom");
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
