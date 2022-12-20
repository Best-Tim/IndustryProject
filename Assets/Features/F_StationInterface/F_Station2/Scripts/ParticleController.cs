using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem fire;
    [SerializeField]
    ParticleSystem smoke;
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
                    smoke = child.GetComponent<ParticleSystem>();
                }
                if (child.gameObject.name == "Sparks")
                {
                    sparks = child.GetComponent<ParticleSystem>();
                }
            }
        }
    }
    private ParticleSystem FindCorrectParticle(string s)
    {
        if (s == "Fire")
        {
            return fire;
        }
        if (s == "Smoke")
        {
            return smoke;
        }
        if (s == "Sparks")
        {
            return sparks;
        }
        return null;
    }
    public void PlayParticleByName(string s)
    {
        FindCorrectParticle(s).Play();
    }
    public void StopParticleByName(string s)
    {
        FindCorrectParticle(s).Stop();
    }
}
