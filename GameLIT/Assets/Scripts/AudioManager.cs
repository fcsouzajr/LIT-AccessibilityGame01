using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Audio[] audios;
    public static AudioManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        foreach (Audio audio in audios) {
            audio.audioSource = gameObject.AddComponent<AudioSource>();
            audio.audioSource.clip = audio.audioClip;
            audio.audioSource.volume = audio.volume;
            audio.audioSource.loop = audio.loop;
        }
    }

    public void Play(string name) {
        Audio audio = Array.Find(audios, sound => sound.name == name);
        if (audio == null)
            return;
        audio.audioSource.Play();
    }
}
