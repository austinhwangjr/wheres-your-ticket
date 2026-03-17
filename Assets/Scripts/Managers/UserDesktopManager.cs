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
    private GameObject wifi_list;
    [SerializeField]
    private GameObject vpn_status_text;

    private DesktopIssueConfig active_config;                               // The currently loaded issue config for the remote desktop session
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

        if (vpn_status_text == null)
        {
            Debug.LogError("Desktop UI element references are not set in the inspector.");
            return;
        }
        
        //wifi_taskbar_icon.GetComponent<SpriteRenderer>().sprite = config.init_wifi_icon;
        //wifi_taskbar_icon.GetComponent<WifiIconScript>().current_state = config.init_wifi_icon_state;

        WifiManager.instance.InitialiseState(
            config.init_wifi_on,
            config.init_wifi_has_cert_issue,
            config.init_wifi_connected
        );

        wifi_list.GetComponent<ToggleWifiScript>().SetWifiState(config.init_wifi_on);

        VpnManager.instance.has_cert_issue = !config.init_vpn_can_connect;
        vpn_status_text.GetComponent<TextMeshPro>().text = config.init_vpn_text;

        if (config.issue_type == IssueType.CannotAccessIntranet)
        {
            WifiManager.instance.ConnectedToOtherNetwork();
        }
        else
        {
            WifiManager.instance.ConnectedToInternalNetwork();
        }

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

        if (!action_config_map.TryGetValue(actionId, out DesktopActionConfig action))
        {
            Debug.LogWarning($"No action registered with id: {actionId}");
            return;
        }

        // If this action belongs to a mutex group, evict all other
        // actions in that group from the performed set before adding this one
        if (!string.IsNullOrEmpty(action.mutex_group))
        {
            //EvictMutexGroup(action.mutex_group, actionId);
            foreach (var action_in_map in action_config_map.Values)
            {
                // Remove any other action in the same group that was previously performed
                if (action_in_map.mutex_group == action.mutex_group && action_in_map.action_id != actionId)
                    performed_actions.Remove(action_in_map.action_id);
            }
        }

        // Apply the action
        switch (actionId)
        {
            case "turn_on_wifi":
                WifiManager.instance.SetToggleState(true);
                break;
            case "turn_off_wifi":
                WifiManager.instance.SetToggleState(false);
                break;
            case "reinstall_wifi_cert":
                WifiManager.instance.SetCertIssue(false);
                break;
            case "reinstall_vpn_cert":
                VpnManager.instance.CanConnectToVpn(true);
                break;
            case "execute_sfc_scannow":
                // Doesn't change the desktop state, for track-keeping purposes only
                break;
        }

        // if (action.new_vpn_text != null)
        //     vpn_status_text.GetComponent<TextMeshPro>().text = action.new_vpn_text;

        Debug.Log($"Applied action: {actionId}");

        // something vpn_can_connect = action.new_vpn_can_connect;
        // something sfc_scannow_executed = action.new_sfc_scannow_executed;

        // Track and check completion against the active config's requirements
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
        TicketManager.instance.ResolveTicket(PageManager.instance.ticket_selected);
        OnTicketResolved();
    }

    private void OnTicketResolved()
    {
        Debug.Log("Ticket resolved! (user desktop)");
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
