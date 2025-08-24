/**
 * PlaySFXOnClick.cs
 * 
 * This script plays an SFX when button is clicked.
 * 
 * @author Austin Hwang
 * @date 24 August 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySFXOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private AudioClip button_click_sfx;
    [SerializeField]
    private float volume = 1f;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.PlaySFXClip(button_click_sfx, transform, volume);
    }
}
