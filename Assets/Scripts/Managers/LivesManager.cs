/**
 * LivesManager.cs
 * 
 * This script manages the player's lives in the game.
 * Simulates SLA system.
 * 
 * @author Austin Hwang
 * @date 28 December 2025
 */
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField]
    private int maxLives = 3;
    private int currentLives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoseLife()
    {
        if (currentLives > 0)
        {
            --currentLives;
            Debug.Log("Ticket breached, current lives: " + currentLives);
        }
        else
        {
            Debug.Log("No lives left! Game Over.");

            // Future game over logic here

        }
    }
    
    private void ResetLives()
    {
        currentLives = maxLives;
    }
}
