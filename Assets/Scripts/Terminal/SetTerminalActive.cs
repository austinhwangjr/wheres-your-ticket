/**
 * SetTerminalActive.cs
 * 
 * This script contains the logic to activate/deactivate the in-game terminal. (TEST)
 * 
 * @author Austin Hwang
 * @date 8 September 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class SetTerminalActive : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject terminal;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (terminal.activeSelf)
        {
            terminal.SetActive(false);
        }
        else
        {
            terminal.SetActive(true);
        }
    }
}
