/**
 * ClickHandler.cs
 * 
 * This script contains logic for handling click events for game objects.
 * 
 * @author Austin Hwang
 * @date 14 March 2026
 */
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    // On-click event that other scripts can subscribe to
    public Action on_click;

    public void OnPointerClick(PointerEventData eventData)
    {
        on_click?.Invoke();
    }
}