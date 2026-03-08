/**
 * OpenCloseOverlayScript.cs
 * 
 * This script enables/disables the specified overlay when the same button is clicked.
 * 
 * @author Austin Hwang
 * @date 8 March 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCloseOverlayScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject overlay;

    public void OnPointerClick(PointerEventData eventData)
    {
        overlay.SetActive(!overlay.activeSelf);
    }
}
