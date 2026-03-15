/**
 * ReturnToHomePage.cs
 * 
 * This script returns players to the home page.
 * 
 * @author Austin Hwang
 * @date 31 July 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnToHomePage : MonoBehaviour, IPointerClickHandler
{
    private void Awake()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PageManager.instance.ShowHomePage();
    }
}
