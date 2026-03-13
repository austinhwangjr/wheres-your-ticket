/**
 * DesktopIssueConfig.cs
 * 
 * This config file defines the properties of each issue type that can be reported in the "Remote Desktop" mode.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;

[CreateAssetMenu(fileName = "IssueConfig", menuName = "HelpdeskSimulator/Issue Config")]
public class DesktopIssueConfig : ScriptableObject
{
    [Header("Issue Info")]
    public IssueType issue_type;

    [Header("Taskbar Icons")]
    public Sprite init_wifi_icon;           // The initial wifi icon shown in the taskbar
    public string init_vpn_text;            // The initial VPN status text shown in the VPN app
    public bool init_vpn_can_connect;       // The initial VPN state (whether the VPN can or cannot connect)
    public bool init_sfc_scannow_executed;  // Whether the user has already executed "sfc /scannow" command in Command Prompt

    [Header("Action Results")]
    public ActionResult[] actions;      // Each button maps to a result
}

[System.Serializable]
public class ActionResult
{
    public string actionId;          // e.g. "reinstall_wifi_cert"
    public Sprite newWifiIcon;       // Icon to swap to after action
    public Sprite newVpnIcon;
    public string vpnStatusText;     // e.g. "Connected" or "Disconnected"
    public bool resolvedTicket;      // Does this action fix the issue?
}