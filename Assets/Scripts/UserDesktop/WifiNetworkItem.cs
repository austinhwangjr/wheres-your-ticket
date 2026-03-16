/**
 * WifiNetworkItem.cs
 * 
 * This script represents an individual WiFi network item in the user desktop mode. Should be attached to each Wifi network object.
 * 
 * @author Austin Hwang
 * @date 16 March 2026
 */
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WifiNetworkItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject text_object;

    public bool initially_connected = false;

    private void Start()
    {
        SetState(initially_connected);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        WifiManager.instance.OnNetworkButtonPressed(this);
    }

    // Called by WifiManager to update this button's visual state
    public void SetState(bool isConnected)
    {
        text_object.GetComponent<TextMeshPro>().text = isConnected ? "Disconnect" : "Connect";
    }
}
