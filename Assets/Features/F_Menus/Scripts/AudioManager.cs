using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
        }
    }
    void Start()
    {
        
    }

    public void Play(string name,bool isLoop)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.loop = isLoop;
        s.audioSource.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Stop();
    }

    public Sound GetSoundName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
