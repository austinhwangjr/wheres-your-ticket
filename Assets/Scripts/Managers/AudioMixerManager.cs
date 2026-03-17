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
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audio_mixer;

    [Header("Sliders")]
    [SerializeField]
    private Slider master_slider;
    [SerializeField]
    private Slider sfx_slider;
    [SerializeField]
    private Slider bgm_slider;

    private void Start()
    {
        if (audio_mixer.GetFloat("master_volume", out float masterDB))
            master_slider.value = Mathf.Pow(10f, masterDB / 20f);

        if (audio_mixer.GetFloat("sfx_volume", out float sfxDB))
            sfx_slider.value = Mathf.Pow(10f, sfxDB / 20f);

        if (audio_mixer.GetFloat("bgm_volume", out float bgmDB))
            bgm_slider.value = Mathf.Pow(10f, bgmDB / 20f);
    }

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
