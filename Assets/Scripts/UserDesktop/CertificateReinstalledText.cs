/**
 * CertificateReinstalledText.cs
 * 
 * This script manages the text display for when a certificate is reinstalled.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class CertificateReinstalledText : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject cert_reinstalled_text;

    public void OnPointerClick(PointerEventData eventData)
    {
        cert_reinstalled_text.SetActive(true);
    }
}
