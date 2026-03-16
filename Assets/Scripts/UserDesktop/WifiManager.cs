/**
 * WifiManager.cs
 * 
 * This script manages the WiFi functionality in the user desktop mode (connected/disconnected).
 * 
 * @author Austin Hwang
 * @date 16 March 2026
 */
using TMPro;
using UnityEngine;

public class WifiManager : MonoBehaviour
{
    public static WifiManager instance { get; private set; }

    // [SerializeField]
    // private GameObject wifi_taskbar_icon;
    // [SerializeField]
    // private Sprite connected_sprite;
    // [SerializeField]
    // private Sprite disconnected_sprite;

    [Header("Reference (for \"Connected to Guest/Company Network\" state)")]
    [SerializeField]
    private WifiIconScript wifi_icon_script;
    [SerializeField]
    private GameObject guest_wifi_object;
    [SerializeField]
    private GameObject company_wifi_object;

    private WifiNetworkItem current_connected = null;
    private WifiNetworkItem last_connected = null;

    // These are the tracked states — only WifiManager owns them
    private bool has_cert_issue = false;
    private bool toggle_on = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        
    }

    public void InitialiseState(bool toggleOn, bool hasCertIssue, bool connected)
    {
        toggle_on = toggleOn;
        has_cert_issue = hasCertIssue;
        
        RefreshIcon();
    }

    // Called by ToggleWifiScript
    public void SetToggleState(bool isOn)
    {
        toggle_on = isOn;

        // If wifi is turned off, disconnect from current network
        if (!isOn && current_connected != null)
        {
            last_connected = current_connected;
            current_connected.SetState(false);
            current_connected = null;
        }
        else if (isOn && last_connected != null)
        {
            current_connected = last_connected;
            current_connected.SetState(true);
            last_connected = null;
        }

        RefreshIcon();
    }

    // Called by UserDesktopManager when initialising issue state
    public void SetCertIssue(bool hasCertIssue)
    {
        has_cert_issue = hasCertIssue;
        RefreshIcon();
    }

    // Called by a network button when clicked
    public void OnNetworkButtonPressed(WifiNetworkItem pressedItem)
    {
        // Disconnect when pressing on currently connected network, otherwise connect to the new one
        if (current_connected == pressedItem)
        {
            pressedItem.SetState(false);
            current_connected = null;
            //UpdateTaskbarIcon(false);
        }
        else
        {
            // Disconnect the previous one if any
            if (current_connected != null)
                current_connected.SetState(false);

            // Connect the new one
            pressedItem.SetState(true);
            current_connected = pressedItem;
            //UpdateTaskbarIcon(true);
        }

        RefreshIcon();
    }

    public void ConnectedToOtherNetwork()
    {
        var guest = guest_wifi_object.GetComponent<WifiNetworkItem>();
        var company = company_wifi_object.GetComponent<WifiNetworkItem>();

        guest.SetState(true);
        guest.initially_connected = true;
        company.SetState(false);
        company.initially_connected = false;

        current_connected = guest;
        RefreshIcon();
    }

    public void ConnectedToInternalNetwork()
    {
        var guest = guest_wifi_object.GetComponent<WifiNetworkItem>();
        var company = company_wifi_object.GetComponent<WifiNetworkItem>();

        guest.SetState(false);
        guest.initially_connected = false;
        company.SetState(true);
        company.initially_connected = true;

        current_connected = company;
        RefreshIcon();
    }

    private void RefreshIcon()
    {
        bool is_connected = current_connected != null;
        wifi_icon_script.SetWifiState(toggle_on, has_cert_issue, is_connected);
    }
}
