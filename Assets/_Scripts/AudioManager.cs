using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake() {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("No Sound Found");
            return;
        }
        s.source.Play();
    }

    public bool IsPlaying(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return false;
        }
        return s.source.isPlaying;
    }

    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("No Sound Found");
            return;
        }
        s.source.Stop();
    }
}
