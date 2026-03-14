/**
 * TaskbarManager.cs
 * 
 * This script manages the taskbar elements in the user desktop mode.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskbarManager : MonoBehaviour
{
    public static TaskbarManager instance;

    [Header("References")]
    public Transform icon_container;
    public GameObject taskbar_icon_prefab;

    private List<TaskbarIcon> taskbar_icons = new List<TaskbarIcon>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddIcon(Sprite icon, GameObject window)
    {
        Debug.Log($"Adding taskbar icon for window {window.name}");
        GameObject newIcon = Instantiate(taskbar_icon_prefab, icon_container);
        TaskbarIcon taskbarIcon = newIcon.GetComponent<TaskbarIcon>();
        taskbarIcon.Init(icon, window);
        taskbar_icons.Add(taskbarIcon);
    }

    public void RemoveIcon(TaskbarIcon icon)
    {
        if (taskbar_icons.Contains(icon))
        {
            taskbar_icons.Remove(icon);
            Destroy(icon.gameObject);
        }
    }

    // Called by WindowController when a window is focused
    // Dims all other taskbar icons so only the focused one is highlighted
    public void OnWindowFocused(WindowController focusedWindow)
    {
        foreach (TaskbarIcon icon in taskbar_icons)
        {
            if (icon == null) continue;

            WindowController iconWindow = icon.GetLinkedWindow()?.GetComponent<WindowController>();
            if (iconWindow == focusedWindow)
                icon.SetActive();
            else
                icon.SetInactive();
        }
    }
}
