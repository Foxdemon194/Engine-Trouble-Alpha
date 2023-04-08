using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnim : MonoBehaviour
{
    Animator anim;

    public bool valve;
    public bool toValve;
    public bool toValveAbove;
    public bool toCoal;
    public bool towardStairs;
    public bool leaveStorage;
    public bool arrowLeft;
    public bool arrowRightValve;
    public bool arrowRightValve2;
    public bool toWaterIn;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (valve)
        {
            anim.SetBool("valve", true);
        }

        if (toValve)
        {
            anim.SetBool("toValve", true);
        }

        if (toValveAbove)
        {
            anim.SetBool("toValveAbove", true);
        }

        if (toCoal)
        {
            anim.SetBool("toCoal", true);
        }

        if (towardStairs)
        {
            anim.SetBool("towardStairs", true);
        }

        if (toWaterIn)
        {
            anim.SetBool("toWaterIn", true);
        }

        if (leaveStorage)
        {
            anim.SetBool("leaveStorage", true);
        }

        if (arrowLeft)
        {
            anim.SetBool("arrow left", true);
        }

        if (arrowRightValve)
        {
            anim.SetBool("arrow right valve", true);
        }

        if (arrowRightValve2)
        {
            anim.SetBool("arrow right valve 2", true);
        }
    }
}
