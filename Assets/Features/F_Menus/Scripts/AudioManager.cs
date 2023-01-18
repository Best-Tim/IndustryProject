using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    public Sound[] tutorialSounds;
    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
        }
        foreach (Sound sound in tutorialSounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
        }

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
    public void PlaySoundsForTutorial(Sound sound)
    {
        sound = Array.Find(tutorialSounds, s => s == sound);
        Debug.LogWarning("WHAT IS THE NAME OF IT: " + sound.audioClip.name);
        sound.audioSource.Play();
    }

    
}
