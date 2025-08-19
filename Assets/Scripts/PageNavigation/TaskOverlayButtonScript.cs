/**
 * TaskOverlayButtonScript.cs
 * 
 * This script calls the function to enable the task overlay for the existing task.
 * 
 * @author Austin Hwang
 * @date 17 August 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class TaskOverlayButtonScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject event_system;

    public enum ShowMode
    {
        Open,
        Close
    }
    [SerializeField]
    private ShowMode show_mode;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (event_system != null)
        {
            PageManager pm = event_system.GetComponent<PageManager>();
            if (pm != null)
            {
                switch (show_mode)
                {
                    case ShowMode.Open:
                        pm.ShowTaskOverlay();
                        break;
                    case ShowMode.Close:
                        pm.HideTaskOverlay();
                        break;
                }
            }
        }
    }
}
