/**
 * DesktopActionConfig.cs
 * 
 * This config file defines the results of each action (for each button) in the "Remote Desktop" mode.
 * 
 * @author Austin Hwang
 * @date 15 March 2026
 */
using UnityEngine;

[CreateAssetMenu(fileName = "ActionConfig_", menuName = "HelpdeskSimulator/Action Config")]
public class DesktopActionConfig : ScriptableObject
{
    [Header("Action Info")]
    public string action_id;                // e.g. "reinstall_wifi_cert"

    [Header("UI/Gameplay Changes")]
    public Sprite new_wifi_icon;            // New wifi icon to swap to after action
    public string new_vpn_text;             // New VPN status text to swap to after action
    public bool new_vpn_can_connect;        // Should be True most of the time
    public bool new_sfc_scannow_executed;   // Should be True most of the time
}