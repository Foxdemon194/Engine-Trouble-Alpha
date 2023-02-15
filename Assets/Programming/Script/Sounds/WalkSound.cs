using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    CharacterController controller;

    public AudioSource footSteps;
    public AudioClip woodSteps;
    public AudioClip metalSteps;

    private float overallSpeed;
    public float maxRayDistance = 1f;
    public Transform rayOrigen;
    RaycastHit hit;

    public enum state { walking, running, steady }
    public state currentstate = state.steady;

    public bool wood = false;
    bool check = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        // The overall speed
        overallSpeed = controller.velocity.magnitude;

        overallSpeed = Mathf.Round(overallSpeed * 10.0f) * 0.1f;
    }

    private void Update()
    {
        Ray ray = new Ray(rayOrigen.position, Vector3.down);

        Debug.DrawLine(rayOrigen.position, rayOrigen.position + Vector3.down * maxRayDistance, Color.red);
        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            if (hit.collider.tag == "Floor")
            {
                footSteps.clip = woodSteps;
                if (check == true)
                {
                    footSteps.Play();
                    check = false;
                }
            }
            else if (hit.collider.tag == "Metal" || hit.collider.tag == "MetalFloor")
            {
                footSteps.clip = metalSteps;
                if (check == false)
                {
                    footSteps.Play();
                    check = true;
                }
            }
        }

        if (overallSpeed > 1.5f && currentstate != state.running)
        {
            currentstate = state.running;
            footSteps.Play();
            footSteps.pitch = 2f;
        }
        else if (overallSpeed > 0f && overallSpeed <= 1.5f && currentstate != state.walking)
        {
            currentstate = state.walking;
            footSteps.Play();
            footSteps.pitch = 1f;
        }
        else if (overallSpeed == 0 && currentstate != state.steady)
        {
            footSteps.Stop();
            currentstate = state.steady;
        }
    }
}
