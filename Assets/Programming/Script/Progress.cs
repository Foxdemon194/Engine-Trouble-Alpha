using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;

public class Progress : MonoBehaviour
{
    //public GameObject headUI;
    //public GameObject loseText;
    //public GameObject winText;
    public Slider progress;
    public Pressure[] pressure;////////////////////////////////////////////
    public EngineManager[] engines;
    
    public BreakGear gearController;

    private float averagePressure = 0; ////////////////////////////////////////
    float total = 0;///////////////////////////////////////////////////////

    public float speed = 0.007f; 
    public float normalSpeed = 0.005f;
    public float lowSpeed = 0.004f;
    public float higSpeed = 0.01f;


    public float timer = 600; //ten minutes
    public bool losing;
    public bool wining;
    //Pause 
    //public GameObject wristUI;
    //public bool activateUI = true;
    //public float modifiedTime = 1f;


    public bool bostLever = false;
    public bool tut;

    public TextMeshPro distance;
    public TextMeshPro distanceTravelled;
    public TextMeshPro distanceRemaining;
    public TextMeshPro timeRemaining;

    public Light[] checkLight;
    public Light[] gearLight;
    public GameObject[] bulbs;
    public GameObject[] gearsBulb;
    public Material red;
    public Material green;

    // Start is called before the first frame update
    void Start()
    {
        //headUI.SetActive(false);
        //loseText.SetActive(false);
        //winText.SetActive(false);

        //DisplayUI();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = modifiedTime;
        for (int i = 0; i < pressure.Length; i++)
        {
            if (pressure[i].sPressure >= 75 || pressure[i].sPressure <= 25 || engines[i].coalLevel >= 75 || engines[i].coalLevel <= 25 || engines[i].waterLevel >= 75 || engines[i].waterLevel <= 25)
            {
                checkLight[i].intensity = 1;
                checkLight[i].color = Color.red;
                bulbs[i].GetComponent<Renderer>().material = red;
            }
            else
            {
                checkLight[i].intensity = 1;
                checkLight[i].color = Color.green;
                bulbs[i].GetComponent<Renderer>().material = green;
            }
        }

        for (int i = 0; i < gearController.broken.Length; i++)
        {
            if (gearController.broken[i])
            {
                gearLight[i].intensity = 1;
                gearLight[i].color = Color.red;
                gearsBulb[i].GetComponent<Renderer>().material = red;
            }
            else
            {
                gearLight[i].intensity = 1;
                gearLight[i].color = Color.red;
                gearsBulb[i].GetComponent<Renderer>().material = green;
            }
        }

        timer -= Time.deltaTime;

        distance.text = (progress.maxValue + "KM");
        distanceTravelled.text = (Mathf.Round(progress.value * 100) / 100 + "KM");
        distanceRemaining.text = (((Mathf.Round(progress.maxValue * 100) / 100) - Mathf.Round(progress.value * 100) / 100) + "KM");
        timeRemaining.text = (Mathf.Round(timer * 100) / 100) + "";

        //Calculate the averagePressure of the Pressure Scripts
        total = 0;

        foreach (Pressure obj in pressure)
        {
            total += obj.sPressure;
        }

        averagePressure = total / pressure.Length;

        progress.value += speed;

        if (losing)
        {
            speed = 0;
        }
        
        if (averagePressure <= 10 || !CheckGear())
        {
            losing = true;
        }
        else if (averagePressure > 10 && averagePressure <= 25)
        {
            speed = lowSpeed;
        }
        else if (averagePressure > 25 && averagePressure < 85)
        {
            speed = normalSpeed;
        }
        else if (averagePressure >= 85)
        {
            speed = higSpeed;
        }

        //lose screen
        if (timer <= 0 && progress.value != progress.maxValue) 
        {
            //headUI.SetActive(true);
            //loseText.SetActive(true);
            //modifiedTime = 0;
            //leftController.maxRaycastDistance = 3f;
            //leftControllerVisual.lineLength = 3f;
            //rightController.maxRaycastDistance = 3f;
            //rightControllerVisual.lineLength = 3f;

            //result screen here (lose)
            losing = true;
        }

        //win screen
        if (progress.value == progress.maxValue)
        {
            //headUI.SetActive(true);
            //winText.SetActive(true);
            //modifiedTime = 0;
            //leftController.maxRaycastDistance = 3f;
            //leftControllerVisual.lineLength = 3f;
            //rightController.maxRaycastDistance = 3f;
            //rightControllerVisual.lineLength = 3f;

            //result screen here (win)
            wining = true;
        }

        if (bostLever)
        {
            if (tut)
            {
                engines[0].SpawnFire();
                bostLever = false;
            }
            else
            {
                int rand = Random.Range(0, engines.Length);
                engines[rand].SpawnFire();
                bostLever = false;
            }
        }
    }

    public bool CheckGear()
    {
        for (int i = 0; i < gearController.broken.Length; i++)
        {
            if (gearController.broken[i])
            {
                return false;
            }
        }

        return true;
    }

    /*
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
    */
}
