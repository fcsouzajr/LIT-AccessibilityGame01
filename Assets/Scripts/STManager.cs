using UnityEngine.Audio;
using System;
using UnityEngine;

public class STManager : MonoBehaviour {

    public string levelSoundtrack;
    public Audio[] soundtracks;

    void Awake() {
        Audio soundtrack = Array.Find(soundtracks, sound => sound.name == levelSoundtrack);
        soundtrack.audioSource = gameObject.AddComponent<AudioSource>();
        soundtrack.audioSource.clip = soundtrack.audioClip;
        soundtrack.audioSource.volume = soundtrack.volume;
        soundtrack.audioSource.loop = soundtrack.loop;

        Play(soundtrack);
    }

    public void Play(Audio soundtrack) {
        soundtrack.audioSource.Play();
    }
}