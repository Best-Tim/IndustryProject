using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableMediator : MonoBehaviour
{
    private GameObject zincCl;
    public bool isStiring;

    private void Awake()
    {
        isStiring = false;
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
}
