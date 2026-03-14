/**
 * DesktopIcon.cs
 * 
 * This script contains logic for each icon on the desktop (user desktop).
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopIcon : MonoBehaviour, IPointerClickHandler
{
    [Header("App Info")]
    [SerializeField]
    private Sprite app_icon;
    [SerializeField]
    private GameObject app_window;

    private bool is_in_taskbar = false;

    public void Start()
    {
        // Subscribe to window events
        WindowController windowController = app_window.GetComponent<WindowController>();
        if (windowController != null)
        {
            windowController.SetInTaskbar += SetInTaskbar;
        }
    }

    // Mainly for resetting is_in_taskbar when the window is closed
    public void SetInTaskbar(bool inTaskbar)
    {
        is_in_taskbar = inTaskbar;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!is_in_taskbar)
        {
            // First time opening app, add to taskbar
            app_window.SetActive(true);
            TaskbarManager.instance.AddIcon(app_icon, app_window);
            is_in_taskbar = true;
        }
        else
        {
            // If app is already 'open', just make it active
            if (!app_window.activeSelf)
                app_window.SetActive(true);

            app_window.GetComponent<WindowController>()?.Focus();
        }
    }
}
