using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableMediator : MonoBehaviour
{
    public GameObject zincCl;
    public bool isStiring;

    private void Awake()
    {
        isStiring = false;
    }

    private void Start()
    {
        zincCl = FindObjectOfType<ZincScale>().gameObject;
    }

    private void Update()
    {
        if (zincCl != null)
        {
            if (isStiring)
            {
                zincCl.GetComponent<ZincScale>().isStiring = true;
            }
            else if (!isStiring)
            {
                zincCl.GetComponent<ZincScale>().isStiring = false;
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ZincScale>())
        {
            zincCl = other.gameObject;
        }
    }

    public void LockToBowl()
    {
        zincCl.GetComponent<ZincScale>().LockHandleToBowl(gameObject);
    }
}
