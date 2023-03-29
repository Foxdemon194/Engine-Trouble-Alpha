using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateUILines : MonoBehaviour
{
    public Pause Pause;
    public XRInteractorLineVisual LineVisual;
    public XRInteractorLineVisual RightHandVisual;
    void Start()
    {
        LineVisual.isActiveAndEnabled.Equals(false);
        RightHandVisual.isActiveAndEnabled.Equals(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.activateUI)
        {
            LineVisual.isActiveAndEnabled.Equals(true);
            RightHandVisual.isActiveAndEnabled.Equals(true);
        }
        else
        {
            LineVisual.isActiveAndEnabled.Equals(false);
            RightHandVisual.isActiveAndEnabled.Equals(false);
        }
    }
}
