using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Have a list of sounds where we can easily add or remove sounds as we go
    // Sounds will have different properties:
    // Audio Clip, Volume, Pitch, Loop, Randomness, Spatial Blend
    // Audio Manager will find the source with that name and play the sound
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake() 
    {
        if(instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    private void Start() 
    {
        Play("Theme");
    }

    public void Play(string name) 
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if(sound == null) 
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        sound.source.Play();
    }
}
