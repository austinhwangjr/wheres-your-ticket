/**
 * OpenTerminalButton.cs
 * 
 * This script contains the logic to create an instance of the in-game terminal, or open the terminal for the current ticket.
 * 
 * @author Austin Hwang
 * @date 8 September 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenTerminalButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject terminal_prefab;
    [SerializeField]
    private GameObject terminal_group;

    public void OnPointerClick(PointerEventData eventData)
    {
        // If terminal instance doesn't exist for the current ticket
        if (terminal_group.transform.Find("Terminal Instance " + PageManager.instance.ticket_selected.id) == null)
        {
            GameObject terminalInstance = Instantiate(terminal_prefab, terminal_group.transform);
            terminalInstance.name = "Terminal Instance " + PageManager.instance.ticket_selected.id;
        }
        // Open terminal instance for the current ticket
        else
        {
            GameObject terminalInstance = terminal_group.transform.Find("Terminal Instance " + PageManager.instance.ticket_selected.id).gameObject;
            terminalInstance.SetActive(true);
        }
    }
}
