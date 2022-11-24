using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ZincScale : MonoBehaviour
{
    public int scale;
    public int currentCottonCount;

    private void Awake()
    {
        scale = UnityEngine.Random.Range(1, 2);

        if (scale == 2)
        {
            this.gameObject.transform.localScale = new Vector3(1.5f, 5, 1.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && other.gameObject.TryGetComponent(out Identifier identifier))
        {
            other.gameObject.tag = "Untagged";
            if (identifier.materials == MATERIALS.COTTON)
            {
                currentCottonCount++;
            }
            if (identifier.materials == MATERIALS.TUNGSTEIN)
            {
                //explosion
            }
            if (identifier.materials == MATERIALS.TITANUM)
            {
                //fire
            }
        }
    }
}
