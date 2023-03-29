using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBarrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other);
    }
}
