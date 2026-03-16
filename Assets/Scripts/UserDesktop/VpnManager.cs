/**
 * VpnManager.cs
 * 
 * This script manages the VPN functionality in the user desktop mode (can/cannot connect).
 * 
 * @author Austin Hwang
 * @date 16 March 2026
 */
using TMPro;
using UnityEngine;

public class VpnManager : MonoBehaviour
{
    public static VpnManager instance { get; private set; }

    public bool has_cert_issue = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        
    }

    public void CanConnectToVpn(bool canConnect)
    {
        has_cert_issue = !canConnect;
    }
}
