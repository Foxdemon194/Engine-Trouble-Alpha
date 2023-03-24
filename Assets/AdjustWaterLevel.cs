using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustWaterLevel : MonoBehaviour
{
    public Transform waterPNGPos;
    public Transform MaxHeight;
    public Transform MinHeight;

    public bool IsFull;
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(IsFull)
        {
            waterPNGPos.localPosition = MaxHeight.localPosition;
        }
        else if (!IsFull)
        {
            waterPNGPos.localPosition = MinHeight.localPosition;
        }
    }
}
