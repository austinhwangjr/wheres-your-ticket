/**
 * MinimiseTerminal.cs
 * 
 * This script contains the logic to minimise the in-game terminal.
 * 
 * @author Austin Hwang
 * @date 16 March 2026
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class MinimiseTerminal : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject terminal_group;

    public void OnPointerClick(PointerEventData eventData)
    {        
        if (terminal_group.transform.Find("Terminal Instance " + PageManager.instance.ticket_selected.id) != null)
        {
            GameObject terminalInstance = terminal_group.transform.Find("Terminal Instance " + PageManager.instance.ticket_selected.id).gameObject;
            terminalInstance.SetActive(false);
        }
    }
}
