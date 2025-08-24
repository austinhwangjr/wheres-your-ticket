/**
 * AudioManager.cs
 * 
 * This script handles the audio in the game.
 * 
 * @author Austin Hwang
 * @date 24 August 2025
 */
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource sfxObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Create GameObject, assign an audio clip, play audio, then destroy the GameObject
    public void PlaySFXClip(AudioClip audioClip, Transform transform, float volume)
    {
        // Spawn GameObject
        AudioSource audioSource = Instantiate(sfxObject, transform.position, Quaternion.identity);

        // Assign AudioClip and volume
        audioSource.clip = audioClip;
        audioSource.volume = volume;

        // Play audio
        audioSource.Play();

        // Get length of audio clip
        float length = audioSource.clip.length;

        // Destroy GameObject after playing audio clip
        Destroy(audioSource.gameObject, length);
    }
}
