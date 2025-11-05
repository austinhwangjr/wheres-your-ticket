/**
 * WireMatchingWinCondition.cs
 * 
 * This script checks for the win condition of the wire-matching game (x number of lights on).
 * 
 * @author Austin Hwang
 * @date 6 November 2025
 */
using UnityEngine;

public class WireMatchingWinCondition : MonoBehaviour
{
    public static WireMatchingWinCondition instance;

    [SerializeField]
    private int wire_count;

    private int on_count = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncrementCount(int points)
    {
        on_count += points;
        if (on_count == wire_count)
        {
            // Send event that the win condition has been met
        }
    }
}
