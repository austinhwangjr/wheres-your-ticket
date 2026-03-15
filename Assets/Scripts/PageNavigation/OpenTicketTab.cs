/**
 * OpenTicketTab.cs
 * 
 * This script contains the logic for clicking on a ticket's tab box and navigating to the respective ticket page.
 * 
 * @author Austin Hwang
 * @date 21 Sep 2025
 */
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenTicketTab : MonoBehaviour, IPointerClickHandler
{
    private Ticket ticket;

    private void Awake()
    {

    }

    private void Start()
    {
        
    }

    public void SetTicket(Ticket t)
    {
        ticket = t;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PageManager.instance.ShowTicketPage(ticket);
    }
}
