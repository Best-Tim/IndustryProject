using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonPrefabController : MonoBehaviour
{
    public int numberOfCottons;
    public List<GameObject> cottons;

    private void Awake()
    {
        numberOfCottons = 0;
        foreach (Transform t in gameObject.transform)
        {
            if (t.gameObject.name == "Cotton")
            {
                numberOfCottons++;
                cottons.Add(t.gameObject);
            }
        }
    }
}
