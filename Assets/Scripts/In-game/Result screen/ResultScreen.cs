using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ResultScreen : MonoBehaviour
{
    //canvas:
    public Canvas resultCanvas;
    public float duration = 0.4f;
    private CanvasGroup canvGroup;
    //slider:
    public Slider progressSlider;
    public float progress = 0;              //change. Round to a 100
    public GameObject sliderPanel;
    private CanvasGroup _sliderPanel;
    public AudioSource sliderStartSfx;
    public AudioSource sliderEndSfx;
    // time text:
    public Text timeText;
    public float delay = 0.1f;
    public float timeInSeconds;           //change
    private string timeFullText;
    private AudioSource timeTxtAudio;
    //level text:
    public Text levelText;
    public int level;                   //change
    private string levelFullText;
    private AudioSource levelTxtAudio;
    //stamp:
    public Animator failedStampImage;
    public Animator successStampImage;
    private AudioSource stampSfx;
    //paper animation:
    public GameObject resultScreen;
    private Animator _resultScreenAnim;
    //continue buttons:
    public GameObject restartButton;
    public GameObject toMenuButton;
    //ambience:
    public AudioSource ambienceAudio;


    public InputActionProperty showButton;
    public Transform head;
    public float menuDistance = 2;

    private void Start()
    {
        canvGroup = resultCanvas.GetComponent<CanvasGroup>();
        _sliderPanel = sliderPanel.GetComponent<CanvasGroup>();

        timeTxtAudio = timeText.gameObject.GetComponent<AudioSource>();
        levelTxtAudio = levelText.gameObject.GetComponent<AudioSource>();
        stampSfx = failedStampImage.gameObject.GetComponent<AudioSource>();
        _resultScreenAnim = resultScreen.GetComponent<Animator>();
    }
    private void Update()
    {
        if (showButton.action.WasPressedThisFrame())                                 //CHANGE THE CONDITION
        {

            ambienceAudio.volume /= 2;
            _resultScreenAnim.SetTrigger("ShowPaper");
            StartCoroutine(CanvasFading(canvGroup, canvGroup.alpha, 1));
        }


        transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * menuDistance;
        transform.rotation = head.transform.rotation;
    }


    IEnumerator CanvasFading(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
        StartCoroutine(SliderFading(_sliderPanel, _sliderPanel.alpha, 1));
        StartCoroutine(FillSlider());
    }
    IEnumerator SliderFading(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
    }
    IEnumerator FillSlider()
    {
        yield return new WaitForSeconds(1f);
        sliderStartSfx.Play();
        while (progressSlider.value < progress)
        {
            
            progressSlider.value += 0.5f;
            yield return new WaitForSeconds(0.01f);
        }
        sliderEndSfx.Play();
        sliderStartSfx.Stop();
        StartCoroutine(ShowTimeText());
    }
    IEnumerator ShowTimeText()
    {
        yield return new WaitForSeconds(1f);
        timeTxtAudio.Play();
        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);
        timeFullText = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds) + " ";
        for (int i = 0; i < timeFullText.Length; i++)
        {
            timeText.text = timeFullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        timeTxtAudio.Stop();
        StartCoroutine(ShowLevelText());
    }
    IEnumerator ShowLevelText()
    {
        yield return new WaitForSeconds(0.5f);
        levelTxtAudio.Play();
        levelFullText = "Level: " + level.ToString() + " ";
        for(int i = 0; i < levelFullText.Length; i++)
        {
            levelText.text = levelFullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        levelTxtAudio.Stop();
        StartCoroutine(Stamp());
    }
    IEnumerator Stamp()
    {
        yield return new WaitForSeconds(0.5f);
        if (progress < 100)
        {
            failedStampImage.SetTrigger("FailTrigger");
        }
        else if (progress >= 100) 
        {
            successStampImage.SetTrigger("SuccessTrigger");
        }
        stampSfx.time = 0.15f;
        stampSfx.Play();
        StartCoroutine(ShowButtons());
    }
    IEnumerator ShowButtons()
    {
        yield return new WaitForSeconds(1.5f);
        restartButton.SetActive(true);
        toMenuButton.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitToMenuButton()
    {
        SceneManager.LoadScene("Bedroom");
    }
}
