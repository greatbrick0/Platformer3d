using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSingleton
{
    private static GameObject gameObjectInstance;
    private static AudioManager audioManagerInstance;
    private static bool hasInstance = false;
    public static AudioManager Instance 
    { 
        get
        {
            if (!hasInstance)
            {
                gameObjectInstance = new GameObject("AudioManager");
                gameObjectInstance.AddComponent<AudioSource>();
                audioManagerInstance = gameObjectInstance.AddComponent<AudioManager>();
                hasInstance = true;
            }
            return audioManagerInstance;
        }
        private set 
        { 
        }
    }
}
