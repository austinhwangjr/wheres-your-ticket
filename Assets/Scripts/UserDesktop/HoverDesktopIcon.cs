/**
 * HoverDesktopIcon.cs
 * 
 * This script contains logic for the desktop icons in the user's desktop.
 * 
 * @author Austin Hwang
 * @date 22 February 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDesktopIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color newColor = GetComponent<SpriteRenderer>().color;
        newColor.a = 0.37f;
        GetComponent<SpriteRenderer>().color = newColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // If enrollment software, open the enrollment software overlay
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color newColor = GetComponent<SpriteRenderer>().color;
        newColor.a = 0f;
        GetComponent<SpriteRenderer>().color = newColor;
    }
}
