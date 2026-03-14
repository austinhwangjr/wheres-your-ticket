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
    private DesktopIssueConfig[] all_configs;

    [Header("Desktop UI Element References")]
    [SerializeField]
    private GameObject wifi_taskbar_icon;
    [SerializeField]
    private GameObject vpn_status_text;
    //[SerializeField] 
    //private GameObject taskbar;
    //[SerializeField] 
    //private GameObject vpn_app_window;
    // Add references to other desktop element scripts here

    private DesktopIssueConfig active_config;                       // The currently loaded issue config for the remote desktop session
    private Dictionary<IssueType, DesktopIssueConfig> config_map;   // Map for fast lookup of configs by issue type


    [SerializeField]
    private GameObject desktop_interface;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Build a lookup dictionary for fast access
        config_map = new Dictionary<IssueType, DesktopIssueConfig>();
        foreach (var config in all_configs)
        {
            config_map[config.issue_type] = config;
        }  
    }

    /*--------------------------------------------------*/
    // Called when the remote desktop window is opened for a ticket
    public void LoadDesktopForIssue(IssueType issueType)
    {
        if (!config_map.TryGetValue(issueType, out active_config))
        {
            Debug.LogWarning($"No config found for issue type: {issueType}");
            return;
        }

        // Apply the desktop's initial state based on the loaded config
        ApplyInitialState(active_config);
    }

    private void ApplyInitialState(DesktopIssueConfig config)
    {
        Debug.Log($"Loading desktop for issue: {config.issue_type}");
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

        foreach (var action in active_config.actions)
        {
            if (action.action_id != actionId)
                continue;

            // Apply whatever this action changes
            if (action.new_wifi_icon != null)
                wifi_taskbar_icon.GetComponent<SpriteRenderer>().sprite = action.new_wifi_icon;

            if (action.new_vpn_text != null)
                vpn_status_text.GetComponent<TextMeshPro>().text = action.new_vpn_text;

            // something vpn_can_connect = action.new_vpn_can_connect;
            // something sfc_scannow_executed = action.new_sfc_scannow_executed;

            // if (action.resolvedTicket)
            //     Debug.Log("Ticket resolved!"); // Hook into your TicketManager here

            break;
        }
    }
    /*--------------------------------------------------*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
