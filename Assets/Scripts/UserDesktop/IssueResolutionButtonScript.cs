/**
 * IssueResolutionButtonScript.cs
 * 
 * This script contains functions for resolving users' various issues on button click.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;
using UnityEngine.EventSystems;

public enum DesktopButtonType
{
    None,
    ReinstallWifiCert,
    ReinstallVpnCert,
    ToggleWifi,
    ConnectToInternalNetwork,
    ConnectToOtherNetwork
}

public class IssueResolutionButtonScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private DesktopButtonType desktop_button_type;

    [SerializeField]
    private ToggleWifiScript toggle_wifi_script;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (desktop_button_type)
        {
            case DesktopButtonType.ReinstallWifiCert:
                UserDesktopManager.instance.OnActionPerformed("reinstall_wifi_cert");
                break;
            case DesktopButtonType.ReinstallVpnCert:
                UserDesktopManager.instance.OnActionPerformed("reinstall_vpn_cert");
                break;
            case DesktopButtonType.ToggleWifi:
                if (toggle_wifi_script == null)
                {
                    Debug.LogError("ToggleWifiScript reference is not set.");
                    return;
                }
                toggle_wifi_script.ToggleWifiState();
                break;
            case DesktopButtonType.ConnectToInternalNetwork:
                UserDesktopManager.instance.OnActionPerformed("connect_to_internal_network");
                break;
            case DesktopButtonType.ConnectToOtherNetwork:
                UserDesktopManager.instance.OnActionPerformed("connect_to_other_network");
                break;
        }
    }
}
