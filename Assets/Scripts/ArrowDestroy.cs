using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    public GameObject arrow;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;
    public GameObject arrow5;
    public GameObject arrow6;   
    public GameObject arrow7;

    public BasicTutorialDialogue tut;

    private void Update()
    {
        if (tut.dialogueNumber == 21)
        {
            arrow1.SetActive(true);
        }
        if (tut.dialogueNumber == 32)
        {
            arrow3.SetActive(true);
        }
        if (tut.dialogueNumber == 16)
        {
            arrow.SetActive(true);
            arrow5.SetActive(true);
            arrow4.SetActive(true);
        }
        if (tut.dialogueNumber == 4)
        {
            arrow.SetActive(true);
            arrow6.SetActive(true);
        }
        if (tut.dialogueNumber == 30)
        {
            arrow7.SetActive(true);
        }
        if (tut.dialogueNumber == 7 || tut.dialogueNumber == 24)
        {
            arrow2.SetActive(true);
        }
    }

    public void HammrAr()
    {
        arrow.SetActive(false);
    }

    public void BucketAr()
    {
        arrow1.SetActive(false);
    }

    public void WrenAr()
    {
        arrow2.SetActive(false);
    }

    public void FExtAr()
    {
        arrow3.SetActive(false);
    }

    public void ShovAr()
    {
        arrow4.SetActive(false);
    }

    public void CBarAr()
    {
        arrow5.SetActive(false);
    }

    public void PipeAr()
    {
        arrow6.SetActive(false);
    }

    public void LeveAr()
    {
        arrow7.SetActive(false);
    }
}
