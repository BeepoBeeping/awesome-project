using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float musicVolume, sfxVolume;
    public static AudioManager instance;

    public Sound[] sounds;
    AudioSource audioSource; //reference to the audio source component on the game object

    void Awake()
    {
        // if instance is null, store a reference to this instance
        if (instance == null)
        {
            // a reference does not exist, so store it
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
            return;
        }

        foreach( Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    private void Start()
    {
        ChangeMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        PlayClip("MainMenu");
    }

    public void PlayClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopClip()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); //stop currently playing clip
    }

    public void ChangeAudioSourceVolume(string name, float vol)
    {
        Sound s = Array.Find(sounds, AudioSystem => AudioSystem.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "Not found!");
            return;
        }
        s.source.volume = vol;


    }


    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
    }


}
