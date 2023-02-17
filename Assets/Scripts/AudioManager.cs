using UnityEngine.Audio;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public void Play(string clipName)
    {
        AudioClipDict.clipDict[clipName].source.Play();
    }
}

