/**
 * OverlayButtonScript.cs
 * 
 * This script enables/disables the specified overlay on button click.
 * 
 * @author Austin Hwang
 * @date 22 February 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class OverlayButtonScript : MonoBehaviour, IPointerClickHandler
{
    public enum ShowMode
    {
        Open,
        Close
    }
    [SerializeField]
    private ShowMode show_mode;
    [SerializeField]
    private GameObject overlay;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (show_mode)
        {
            case ShowMode.Open:
                overlay.SetActive(true);
                break;
            case ShowMode.Close:
                overlay.SetActive(false);
                break;
        }
    }
}
