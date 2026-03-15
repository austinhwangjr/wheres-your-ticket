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

public class IssueResolutionButtonScript : MonoBehaviour, IPointerClickHandler
{
    public enum DesktopButtonType
    {
        None,
        ReinstallWifiCert,
        ReinstallVpnCert,
        TurnOnWifi,
        TurnOffWifi,
    }
    [SerializeField]
    private DesktopButtonType desktop_button_type;

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
        }
    }
}
