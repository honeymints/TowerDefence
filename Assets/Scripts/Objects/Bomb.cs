using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Castle"))
        {
            Invoke(nameof(Disable), 3f);
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
