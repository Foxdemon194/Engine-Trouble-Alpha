using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public BasicTutorialDialogue tutorialDialogue;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 2 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 1)
            {
                tutorialDialogue.Continue();
                tutorialDialogue.NextBox();
            }
        }
    }
}
