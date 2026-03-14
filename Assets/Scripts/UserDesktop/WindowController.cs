/**
 * WindowController.cs
 * 
 * This script contains logic for individual windows in the user desktop. This is attached to each window/overlay.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WindowController : MonoBehaviour, IPointerClickHandler
{
    // Events the TaskbarIcon listens to
    public event Action OnWindowFocused;
    public event Action OnWindowHidden;
    public event Action OnWindowClosed;
    public event Action<bool> SetInTaskbar;

    [Header("References")]
    public GameObject close_button;
    public GameObject minimise_button;
    public GameObject header_bar; // Clicking the title bar focuses the window

    private void Awake()
    {
        // Attach handlers to sub-objects
        if (close_button != null)
            close_button.GetComponent<ClickHandler>().on_click = CloseWindow;

        if (minimise_button != null)
            minimise_button.GetComponent<ClickHandler>().on_click = MinimizeWindow;

        if (header_bar != null)
            header_bar.GetComponent<ClickHandler>().on_click = Focus;
    }

    private void OnEnable()
    {
        // When window is re-shown via taskbar, notify taskbar icon
        Focus();
    }

    public void Focus()
    {
        // Bring to front
        transform.SetAsLastSibling();

        // Notify all OTHER windows to go inactive
        TaskbarManager.instance.OnWindowFocused(this);

        OnWindowFocused?.Invoke();
    }

    public void MinimizeWindow()
    {
        gameObject.SetActive(false);
        OnWindowHidden?.Invoke();
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);    // instead of destroying, hide it for 'illusion'
        OnWindowClosed?.Invoke();
        SetInTaskbar?.Invoke(false);    // reset is_in_taskbar to false
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Focus();
    }
}
