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
    public enum ButtonType
    {
        Open,
        Close
    }

    [SerializeField]
    private GameObject[] cert_reinstalled_text;
    [SerializeField]
    private ButtonType button_type;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (button_type == ButtonType.Open)
        {
            foreach (GameObject text in cert_reinstalled_text)
            {
                text.SetActive(true);
            }
        }
        else if (button_type == ButtonType.Close)
        {
            foreach (GameObject text in cert_reinstalled_text)
            {
                text.SetActive(false);
            }
        }
    }
}