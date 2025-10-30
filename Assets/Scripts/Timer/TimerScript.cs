/**
 * TimerScript.cs
 * 
 * This script is used to simulate the in-game clock.
 * 
 * @author Austin Hwang
 * @date 1 August 2025
 */
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerScript : MonoBehaviour
{
    public static event Action<int, int> OnMinuteChanged; 

    // vars for actual timer
    private int hours = 9, minutes = 0; // Time starts at 9:00 am
    private float time;

    // vars to calculate seconds per in-game minute
    private float round_time_seconds;
    private float seconds_per_ingame_minute;

    [SerializeField]
    private int round_time_minutes = 3; // How many real-life minutes in a round

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTimerDisplay();
        time = 0.0f;
        round_time_seconds = round_time_minutes * 60f;
        seconds_per_ingame_minute = round_time_seconds / ((18 - 9) * 60);   // 9am to 6pm in seconds
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // Every seconds_per_ingame_minute real-life seconds, update in-game
        if (time >= seconds_per_ingame_minute)
        {
            time -= seconds_per_ingame_minute;

            // Handle am/pm and hours/mins logic
            ++minutes;
            if (minutes >= 60)
            {
                minutes = 0;

                ++hours;
                if (hours >= 24)
                {
                    hours = 0;
                }
            }

            // Notify listeners
            OnMinuteChanged?.Invoke(hours, minutes);

            // Update timer display
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        string hoursString = (hours > 12) ? (hours - 12).ToString() : hours.ToString();
        string minutesString = minutes.ToString("00");
        string amPmString = (hours >= 12) ? "pm" : "am";
        GetComponent<TextMeshPro>().text = $"{hoursString}:{minutesString} {amPmString}";
    }
}
