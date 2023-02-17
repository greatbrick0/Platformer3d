using UnityEngine.Audio;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound ii in sounds)
        {
            ii.source = gameObject.AddComponent<AudioSource>();
            ii.source.clip = ii.clip;
            ii.source.volume = ii.volume;
            ii.source.pitch = ii.pitch;
        }
    }

    public void Play(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == clipName);
        s.source.Play();
    }
}

