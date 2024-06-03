using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    [HideInInspector] public AudioSource source;
    public string name;
    public AudioClip sound;
    public AudioMixerGroup mixer;
    [Range(0f, 1f)] public float volume;
    public bool loop, playOnAwake;
}
