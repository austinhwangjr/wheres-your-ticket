/**
 * ToggleWifiScript.cs
 * 
 * This script handles the functionality for toggling the WiFi status (toggle button).
 * 
 * @author Austin Hwang
 * @date 16 March 2026
 */
using UnityEngine;
using UnityEngine.EventSystems;
public class ToggleWifiScript : MonoBehaviour//, IPointerClickHandler
{    
    [Header("References")]
    [SerializeField]
    private GameObject wifi_toggle_button;
    [SerializeField]
    private GameObject wifi_off_text;
    [SerializeField]
    private GameObject wifi_list_group;

    [Header("Sprites for wifi toggle")]
    [SerializeField]
    private Sprite wifi_toggle_on_sprite;
    [SerializeField]
    private Sprite wifi_toggle_off_sprite;

    public static bool wifi_toggle_on = true;

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     Debug.Log("Toggling wifi (Start)");
    //     Debug.Log($"Current wifi toggle state: {wifi_toggle_on}");
    //     wifi_toggle_on = !wifi_toggle_on;
    //     if (wifi_toggle_on)
    //     {
    //         GetComponent<SpriteRenderer>().sprite = wifi_toggle_on_sprite;
    //     }
    //     else
    //     {
    //         GetComponent<SpriteRenderer>().sprite = wifi_toggle_off_sprite;
    //     }
    //     Debug.Log($"New wifi toggle state: {wifi_toggle_on}");
    //     Debug.Log("Toggling wifi (End)");
    // }

    public void SetWifiState(bool isOn)
    {
        wifi_toggle_on = isOn;
    }

    public void ToggleWifiState()
    {
        wifi_toggle_on = !wifi_toggle_on;
        if (wifi_toggle_on)
        {
            UserDesktopManager.instance.OnActionPerformed("turn_on_wifi");
        }
        else
        {
            UserDesktopManager.instance.OnActionPerformed("turn_off_wifi");
        }
    }

    void Update()
    {
        if (wifi_toggle_on)
        {
            wifi_toggle_button.GetComponent<SpriteRenderer>().sprite = wifi_toggle_on_sprite;
            wifi_off_text.SetActive(false);
            wifi_list_group.SetActive(true);
        }
        else
        {
            wifi_toggle_button.GetComponent<SpriteRenderer>().sprite = wifi_toggle_off_sprite;
            wifi_off_text.SetActive(true);
            wifi_list_group.SetActive(false);
        }
    }
}
