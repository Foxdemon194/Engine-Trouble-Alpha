using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PunchCardDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "punchCard01(Clone)")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (other.gameObject.name == "punchCard02(Clone)")
        {
            SceneManager.LoadScene("Level1 Test");
        }
        else if (other.gameObject.name == "punchCard03(Clone)")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (other.gameObject.name == "punchCard04(Clone)")
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
