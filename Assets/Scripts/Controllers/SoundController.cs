using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public AudioSource audioSource;
    private static float musicVolume = 50f;
    private static bool toggle = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // == public methods ==
    public void PlayOneShot(AudioClip clip)
    {
        if(clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void ToggleSounds()
    {
        if(toggle)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
        
        // placeholder
        audioSource.mute = !audioSource.mute;
    }

    public static SoundController FindSoundController()
    {
        SoundController sc = FindObjectOfType<SoundController>();
        if(!sc)
        {
            Debug.LogWarning("Missing Sound Controller");
        }
        return sc;
    }
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    //  setVolume method to be utilized by menu slider
    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
