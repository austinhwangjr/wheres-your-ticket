/**
 * AudioMixerManager.cs
 * 
 * This script handles the audio mixer in the game, managing the volume settings.
 * 
 * @author Austin Hwang
 * @date 1 September 2025
 */
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audio_mixer;

    // The following 3 functions set the values of the master, SFX and BGM volumes in the audio mixer.
    // NOTE:
    // Mathf.Log10(volume) * 20f is used to properly convert the volume value from a decibel scale to a linear scale.
    public void SetMasterVolume(float volume)
    {
        audio_mixer.SetFloat("master_volume", Mathf.Log10(volume) * 20f);
    }

    public void SetSFXVolume(float volume)
    {
        audio_mixer.SetFloat("sfx_volume", Mathf.Log10(volume) * 20f);
    }
    
    public void SetBGMVolume(float volume)
    {
        audio_mixer.SetFloat("bgm_volume", Mathf.Log10(volume) * 20f);
    }
}
