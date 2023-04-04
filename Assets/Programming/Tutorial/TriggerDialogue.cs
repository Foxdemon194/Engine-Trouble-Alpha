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
            }
            if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 11 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 10)
            {
                tutorialDialogue.Continue();
            }
            if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 13 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 12)
            {
                tutorialDialogue.Continue();
            }
            if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 20 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 19)
            {
                tutorialDialogue.Continue();
            }
            if (tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber <= 25 && tutorialDialogue.GetComponent<BasicTutorialDialogue>().dialogueNumber > 24)
            {
                tutorialDialogue.Continue();
            }
        }
    }
}
