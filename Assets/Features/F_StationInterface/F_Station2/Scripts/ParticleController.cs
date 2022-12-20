using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem fire;
    [SerializeField]
    ParticleSystem chiefKeef;
    [SerializeField]
    ParticleSystem sparks;

    List<Transform> transformOven = new List<Transform>();
    private void Start()
    {
        transformOven.AddRange(GetComponentsInChildren<Transform>());

        Transform parent = this.transform;

        foreach (Transform child in transformOven)
        {
            if (child.parent == parent)
            {
                child.GetComponent<ParticleSystem>().Stop();
                if (child.gameObject.name == "Fire")
                {
                    fire = child.GetComponent<ParticleSystem>();
                }
                if (child.gameObject.name == "ChiefKeef")
                {
                    chiefKeef = child.GetComponent<ParticleSystem>();
                }
                if (child.gameObject.name == "Sparks")
                {
                    sparks = child.GetComponent<ParticleSystem>();
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            fire.Play();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            fire.Stop();
        }
    }

}
