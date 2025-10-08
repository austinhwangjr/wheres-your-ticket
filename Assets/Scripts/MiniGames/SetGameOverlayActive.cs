/**
 * SetGameOverlayActive.cs
 * 
 * This script contains the logic to activate/deactivate the selected game overlay. (TEST)
 * 
 * @author Austin Hwang
 * @date 7 October 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class SetGameOverlayActive : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject mini_game_overlay;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mini_game_overlay.activeSelf)
        {
            mini_game_overlay.SetActive(false);
        }
        else
        {
            mini_game_overlay.SetActive(true);
        }
    }
}
