/**
 * MusicManager.cs
 * 
 * This script handles the music (BGM) in the game.
 * 
 * @author Austin Hwang
 * @date 15 March 2026
 */
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    [SerializeField]
    private AudioSource bgm_object;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseBGM()
    {
        if (bgm_object.isPlaying)
        {
            bgm_object.Pause();
        }
    }

    public void ResumeBGM()
    {
        if (!bgm_object.isPlaying)
        {
            bgm_object.UnPause();
        }
    }
}
