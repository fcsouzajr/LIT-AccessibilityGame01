using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio {
    public string name;
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;

}