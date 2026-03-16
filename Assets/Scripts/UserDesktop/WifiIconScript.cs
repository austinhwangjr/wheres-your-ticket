/**
 * WifiIconScript.cs
 * 
 * This script manages the wifi icon on the desktop. It is responsible for updating the icon based on the current wifi state.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;

// public enum WifiIconState
// {
//     NoWifi,
//     WifiNotConnected,
//     WifiOff,
//     WifiOn
// }

public class WifiIconScript : MonoBehaviour
{
    [SerializeField]
    private Sprite no_wifi_sprite;
    [SerializeField]
    private Sprite wifi_not_connected_sprite;
    [SerializeField]
    private Sprite wifi_off_sprite;
    [SerializeField]
    private Sprite wifi_on_sprite;

    //public WifiIconState current_state;
    private bool wifi_toggle_on;
    private bool wifi_has_cert_issue;
    private bool wifi_connected;

    public SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Single entry point — everyone calls this instead of touching booleans directly
    public void SetWifiState(bool toggleOn, bool hasCertIssue, bool connected)
    {
        wifi_toggle_on = toggleOn;
        wifi_has_cert_issue = hasCertIssue;
        wifi_connected = connected;
        RefreshIcon(); // Update immediately, no need to wait for Update()
    }

    private void RefreshIcon()
    {
        if (!wifi_toggle_on)
        {
            spriteRenderer.sprite = wifi_off_sprite;
        }
        else if (wifi_has_cert_issue)
        {
            spriteRenderer.sprite = no_wifi_sprite;
        }
        else if (wifi_connected)
        {
            spriteRenderer.sprite = wifi_on_sprite;
        }
        else
        {
            spriteRenderer.sprite = wifi_not_connected_sprite;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (!wifi_toggle_on)
    //     {
    //         //current_state = WifiIconState.WifiOff;
    //         GetComponent<SpriteRenderer>().sprite = wifi_off_sprite;
    //     }
    //     else
    //     {
    //         if (wifi_has_cert_issue)
    //         {
    //             //current_state = WifiIconState.NoWifi;
    //             GetComponent<SpriteRenderer>().sprite = no_wifi_sprite;
    //         }
    //         else if (wifi_connected)
    //         {
    //             //current_state = WifiIconState.WifiOn;
    //             GetComponent<SpriteRenderer>().sprite = wifi_on_sprite;
    //         }
    //         else
    //         {
    //             //current_state = WifiIconState.WifiNotConnected;
    //             GetComponent<SpriteRenderer>().sprite = wifi_not_connected_sprite;
    //         }
    //     }
    // }
}
