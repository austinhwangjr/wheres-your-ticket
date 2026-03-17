/**
 * LivesManager.cs
 * 
 * This script manages the player's lives in the game.
 * Simulates SLA system.
 * 
 * @author Austin Hwang
 * @date 28 December 2025
 */
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance { get; private set; }

    [SerializeField]
    private UnityEngine.Object game_over_scene;
    [SerializeField]
    private UnityEngine.Object win_scene;
    [SerializeField]
    private GameObject lives_text;
    [SerializeField]
    private int maxLives = 3;
    private int currentLives;

    [Header("Audio")]
    [SerializeField]
    private AudioClip lose_life_sfx;
    [SerializeField]
    private float volume = 1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives_text != null)
        {
            lives_text.GetComponent<TextMeshPro>().text = "SLA Violations Left: " + currentLives.ToString();
        }
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            --currentLives;
            AudioManager.instance.PlaySFXClip(lose_life_sfx, transform, volume);
            Debug.Log("Ticket breached, current lives: " + currentLives);
        }
        else
        {
            Debug.Log("No lives left! Game Over.");

            SceneManager.LoadScene(game_over_scene.name);
        }
    }
    
    public void ResetLives()
    {
        currentLives = maxLives;
    }

    public void WinGame()
    {
        SceneManager.LoadScene(win_scene.name);
    }
}
