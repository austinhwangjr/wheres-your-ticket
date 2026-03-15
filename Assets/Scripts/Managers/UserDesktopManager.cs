/**
 * UserDesktopManager.cs
 * 
 * This script manages the "Remote Desktop" mode, which simulates the user desktop environment in the game.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UserDesktopManager : MonoBehaviour
{
    public static UserDesktopManager instance { get; private set; }

    [Header("Issue Configs (all issue.asset configs here)")]
    [SerializeField] 
    private DesktopIssueConfig[] all_issue_configs;

    [Header("Action Configs (all action.asset configs here)")]
    [SerializeField] 
    private DesktopActionConfig[] all_action_configs;

    [Header("Desktop UI Element References")]
    [SerializeField]
    private GameObject wifi_taskbar_icon;
    [SerializeField]
    private GameObject vpn_status_text;

    private DesktopIssueConfig active_config;                       // The currently loaded issue config for the remote desktop session
    private Dictionary<IssueType, DesktopIssueConfig> issue_config_map;   // Map for fast lookup of configs by issue type
    private Dictionary<string, DesktopActionConfig> action_config_map;     // Map for fast lookup of action configs by action id
    private HashSet<string> performed_actions = new HashSet<string>();

    [SerializeField]
    private GameObject desktop_interface;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Build a lookup dictionary for fast access
        issue_config_map = new Dictionary<IssueType, DesktopIssueConfig>();
        foreach (var config in all_issue_configs)
        {
            issue_config_map[config.issue_type] = config;
        }

        action_config_map = new Dictionary<string, DesktopActionConfig>();
        foreach (var config in all_action_configs)
        {
            action_config_map[config.action_id] = config;
        }
    }

    /*--------------------------------------------------*/
    // Called when the remote desktop window is opened for a ticket
    public void LoadDesktopForIssue(IssueType issueType)
    {
        if (!issue_config_map.TryGetValue(issueType, out active_config))
        {
            Debug.LogWarning($"No config found for issue type: {issueType}");
            return;
        }

        performed_actions.Clear();

        // Apply the desktop's initial state based on the loaded config
        ApplyInitialState(active_config);
    }

    private void ApplyInitialState(DesktopIssueConfig config)
    {
        Debug.Log($"Loading desktop for issue: {config.issue_type}");

        if (wifi_taskbar_icon == null || vpn_status_text == null)
        {
            Debug.LogError("Desktop UI element references are not set in the inspector.");
            return;
        }
        
        wifi_taskbar_icon.GetComponent<SpriteRenderer>().sprite = config.init_wifi_icon;
        vpn_status_text.GetComponent<TextMeshPro>().text = config.init_vpn_text;
        // something vpn_can_connect = config.init_vpn_can_connect;
        // something sfc_scannow_executed = config.init_sfc_scannow
    }
    /*--------------------------------------------------*/

    /*--------------------------------------------------*/
    // Called when an action button is pressed (e.g. "Reinstall Wifi Cert" button).
    public void OnActionPerformed(string actionId)
    {
        if (active_config == null) 
            return;

        // Apply the action
        if (action_config_map.TryGetValue(actionId, out DesktopActionConfig action))
        {
            if (action.new_wifi_icon != null)
                wifi_taskbar_icon.GetComponent<SpriteRenderer>().sprite = action.new_wifi_icon;

            if (action.new_vpn_text != null)
                vpn_status_text.GetComponent<TextMeshPro>().text = action.new_vpn_text;

            // something vpn_can_connect = action.new_vpn_can_connect;
            // something sfc_scannow_executed = action.new_sfc_scannow_executed;
        }
        else
        {
            Debug.LogWarning($"No action registered with id: {actionId}");
        }

        // Track and check completion against the active config's requirements
        if (active_config == null)
            return;

        performed_actions.Add(actionId);
        CheckTicketCompletion();
    }

    private void CheckTicketCompletion()
    {
        foreach (string required in active_config.required_action_ids)
        {
            if (!performed_actions.Contains(required))
                return;
        }

        PageManager.instance.ticket_selected.is_completed = true;
        OnTicketResolved();
    }

    private void OnTicketResolved()
    {
        Debug.Log("Ticket resolved!");
    }
    /*--------------------------------------------------*/

    /*--------------------------------------------------*/
    public void LoadExistingDesktop()
    {
        // Find the ticket's respective desktop prefab, and make it active
        Debug.Log($"Have opened desktop before, loading existing desktop state for ticket {PageManager.instance.ticket_selected.id}");
    }
    /*--------------------------------------------------*/
}
