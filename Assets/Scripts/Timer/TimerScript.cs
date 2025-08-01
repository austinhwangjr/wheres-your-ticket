using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private int hours = 11, minutes = 55; // Time starts at 9:00 am
    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTimerDisplay();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // Every 0.5 real-life seconds, update in-game
        if (time >= 0.5f)
        {
            time -= 0.5f;

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
