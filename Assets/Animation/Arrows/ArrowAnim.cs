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
    public bool wrench;
    public bool hammer;
    public bool fireEx;
    public bool pipe;
    public bool barrel;
    public bool shovel;
    public bool lever;
    public bool bucket;
    public bool pipe1;
    public bool pipe2;
    public bool pipe3;
    public bool pipe4;

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

        if (bucket)
        {
            anim.SetBool("bucket", true);
        }

        if (wrench)
        {
            anim.SetBool("wrench", true);
        }

        if (lever)
        {
            anim.SetBool("lever", true);
        }

        if (barrel)
        {
            anim.SetBool("barrel", true);
        }

        if (pipe)
        {
            anim.SetBool("pipe", true);
        }

        if (fireEx)
        {
            anim.SetBool("fireEx", true);
        }

        if (hammer)
        {
            anim.SetBool("hammer", true);
        }

        if (shovel)
        {
            anim.SetBool("shovel", true);
        }

        if (pipe1)
        {
            anim.SetBool("pipe 1", true);
        }

        if (pipe2)
        {
            anim.SetBool("pipe 2", true);
        }

        if (pipe3)
        {
            anim.SetBool("pipe 3", true);
        }

        if (pipe4)
        {
            anim.SetBool("pipe 4", true);
        }
    }
}
