/**
 * TaskbarIcon.cs
 * 
 * This script contains logic for each icon in the taskbar (user desktop).
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaskbarIcon : MonoBehaviour, IPointerClickHandler
{
    [Header("References")]
    [SerializeField]
    private GameObject icon_ref;
    private GameObject linked_window;

    public void Init(Sprite icon, GameObject window)
    {
        icon_ref.GetComponent<SpriteRenderer>().sprite = icon;
        linked_window = window;

        // Subscribe to window events
        WindowController windowController = linked_window.GetComponent<WindowController>();
        if (windowController != null)
        {
            windowController.OnWindowFocused += SetActive;
            windowController.OnWindowHidden += SetHidden;
            windowController.OnWindowClosed += RemoveFromTaskbar;
        }

        //SetActive();
    }

    // When taskbar icon is clicked, toggle the linked window's visibility
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Click");
        if (linked_window == null) return;

        if (!linked_window.activeSelf)
        {
            // Re-show and focus the window
            linked_window.SetActive(true);
            Debug.Log($"Taskbar icon clicked, showing window {linked_window.name}");
            linked_window.GetComponent<WindowController>()?.Focus();
        }
        else
        {
            // Minimize (hide) the window
            linked_window.SetActive(false);
            SetHidden();
        }
    }

    public void SetActive()
    {
        //backgroundImage.color = activeColor;
    }

    public void SetHidden()
    {
        //backgroundImage.color = hiddenColor;
    }

    public void SetInactive()
    {
        //backgroundImage.color = normalColor;
    }
    
    public GameObject GetLinkedWindow() => linked_window;

    private void RemoveFromTaskbar()
    {
        Debug.Log($"Removing taskbar icon for window {linked_window.name}");
        // Unsubscribe to avoid memory leaks
        if (linked_window != null)
        {
            WindowController windowController = linked_window.GetComponent<WindowController>();
            if (windowController != null)
            {
                windowController.OnWindowFocused -= SetActive;
                windowController.OnWindowHidden -= SetHidden;
                windowController.OnWindowClosed -= RemoveFromTaskbar;
            }
        }

        TaskbarManager.instance.RemoveIcon(this);
    }

    private void OnDestroy()
    {
        // Safety cleanup if object is destroyed externally
        if (linked_window != null)
        {
            WindowController windowController = linked_window.GetComponent<WindowController>();
            if (windowController != null)
            {
                windowController.OnWindowFocused -= SetActive;
                windowController.OnWindowHidden -= SetHidden;
                windowController.OnWindowClosed -= RemoveFromTaskbar;
            }
        }
    }
}
