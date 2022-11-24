using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // Start is called before the first frame update
    public string name;
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;
    [Range (0f, 1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
