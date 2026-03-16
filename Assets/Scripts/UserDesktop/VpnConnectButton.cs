/**
 * VpnConnectButton.cs
 * 
 * This script manages the VPN connect button functionality in the user desktop mode.
 * 
 * @author Austin Hwang
 * @date 16 March 2026
 */
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class VpnConnectButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject vpn_status_text;
    [SerializeField]
    private GameObject vpn_button_text;

    public void OnPointerClick(PointerEventData eventData)
    {
        string buttonText = vpn_button_text.GetComponent<TextMeshPro>().text.Trim();
        Debug.Log("Textt" + buttonText);
        if (buttonText == "Connect")
        {
            Debug.Log("VPN Connect button clicked");
            if (VpnManager.instance.has_cert_issue)
            {
                vpn_status_text.GetComponent<TextMeshPro>().text = "Connection failed";
            }
            else
            {
                vpn_status_text.GetComponent<TextMeshPro>().text = "Connected to VPN";
                vpn_button_text.GetComponent<TextMeshPro>().text = "Disconnect";
            }
        }
        else if (buttonText == "Disconnect")
        {
            vpn_status_text.GetComponent<TextMeshPro>().text = "Disconnected from VPN";
            vpn_button_text.GetComponent<TextMeshPro>().text = "Connect";
        }
    }
}
