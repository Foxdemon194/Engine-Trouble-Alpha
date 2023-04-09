using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    public GameObject arrow;

    public void GetRidOfThisDumbThing()
    {
        arrow.SetActive(false);
    }
}
