using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class LDCharacterControlletHelper : MonoBehaviour
{
    private XROrigin m_XROrigin;
    private CharacterController m_CharacterController;
    private CharacterControllerDriver driver;
    private float minHeight = 1;
    private float maxHeight = 2;

    void Start()
    {
        m_XROrigin = GetComponent<XROrigin>();
        m_CharacterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
    }

    public void Update()
    {
        UpdateCharacterController();
    }

    protected virtual void UpdateCharacterController()
    {
        if (m_XROrigin == null || m_CharacterController == null)
            return;

        var height = Mathf.Clamp(m_XROrigin.CameraInOriginSpaceHeight, minHeight, maxHeight);

        Vector3 center = m_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + m_CharacterController.skinWidth;

        m_CharacterController.height = height;
        m_CharacterController.center = center;
    }
}
