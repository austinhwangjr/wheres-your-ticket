/**
 * DesktopIssueConfig.cs
 * 
 * This config file defines the properties of each issue type that can be reported in the "Remote Desktop" mode.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IssueConfig_", menuName = "HelpdeskSimulator/Issue Config")]
public class DesktopIssueConfig : ScriptableObject
{
    [Header("Issue Info")]
    public IssueType issue_type;

    [Header("Initial Desktop State")]
    public Sprite init_wifi_icon;           // The initial wifi icon shown in the taskbar
    public string init_vpn_text;            // The initial VPN status text shown in the VPN app
    public bool init_vpn_can_connect;       // The initial VPN state (whether the VPN can or cannot connect)
    public bool init_sfc_scannow_executed;  // Whether the user has already executed "sfc /scannow" command in Command Prompt

    [Header("Completion Requirements")]
    [Tooltip("All of these actions must be performed to resolve the ticket")]
    public string[] required_action_ids; // e.g. ["reinstall_wifi_cert"]
}