using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipDict : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;

    public static Dictionary<string, Sound> clipDict = new Dictionary<string, Sound>();

    private void Awake()
    {
        foreach (Sound ii in sounds)
        {
            ii.source = gameObject.AddComponent<AudioSource>();
            ii.source.clip = ii.clip;
            ii.source.volume = ii.volume;
            ii.source.pitch = ii.pitch;
            clipDict.Add(ii.name, ii);
        }
    }
}
