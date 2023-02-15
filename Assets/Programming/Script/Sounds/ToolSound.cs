using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSound : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip barrelBreak;
    public AudioClip pipeGearBreak;
    public AudioClip metalHit;

    private Rigidbody rbHummer;

    public bool Hammer = false;

    void Start()
    {
        rbHummer = GetComponent<Rigidbody>();
    }
 
    void OnCollisionEnter(Collision other)
    {
        if (Hammer == true)
        {
            if (other.gameObject.tag == "Barrel" && rbHummer.velocity.magnitude > 3f)
            {
                sound.clip = barrelBreak;
                sound.volume = 0.9f;
                sound.Play();
            }
            else if (other.gameObject.tag == "BrokenPipe" && rbHummer.velocity.magnitude > 3f)
            {
                sound.clip = pipeGearBreak;
                sound.volume = 0.6f;
                sound.Play();
            }
            else if (other.gameObject.tag == "Metal")
            {
                sound.clip = metalHit;
                sound.volume = 0.3f;
                sound.Play();
            }
        }

        else if (Hammer == false)
        {
            if (other.gameObject.tag == "Metal")
            {
                sound.Play();
            }
        }
    }
}
