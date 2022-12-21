using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MATERIALS
{
    COTTON = 0,
    TUNGSTEIN =1,
    TITANUM = 2
}

public class Identifier : MonoBehaviour
{
    
    public MATERIALS materials;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (other.gameObject.TryGetComponent(out Identifier identifier))
            {
                if (identifier.materials == MATERIALS.COTTON)
                {
                    Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
                }
            }
        }
    }
}



