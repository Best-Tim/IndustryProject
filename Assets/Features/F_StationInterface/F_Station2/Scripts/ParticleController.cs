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

    public IEnumerator enumerator;

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
                if (child.gameObject.name == "Smoke")
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

    public void PlayParticleSequence(string s1, string s2, string s3)
    {
        enumerator = PlayParrticlesSequenceCoroutine(s1, s2, s3);
        StartCoroutine(enumerator);
    }
    private IEnumerator PlayParrticlesSequenceCoroutine(string s1, string s2, string s3)
    {
        for (int i = 0; i <= 2; i++)
        {
            string s = "";

            if (i == 0)
            {
                s = s1;
            }
            if (i == 1)
            {
                s = s2;
            }
            if (i==2)
            {
                s = s3;
            }

            FindCorrectParticle(s).Play();
            yield return new WaitForSecondsRealtime(3);
            FindCorrectParticle(s).Stop();
        }
        
    }
}
