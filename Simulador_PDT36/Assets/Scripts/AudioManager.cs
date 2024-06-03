using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public Sounds currentSound;

    void Awake()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Update()
    {
        foreach(Sounds s in sounds)
        {
            if (s.source.isPlaying) { currentSound = s; break; }
        }
    }

    public void PlaySound(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public AudioSource GetAudioSource(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        return s.source;
    }
}
