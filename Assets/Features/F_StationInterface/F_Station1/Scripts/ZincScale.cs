using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZincScale : MonoBehaviour
{
    public int scale;
    public int currentCottonCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            currentCottonCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && currentCottonCount > 0)
        {
            currentCottonCount--;
        }
    }
}
