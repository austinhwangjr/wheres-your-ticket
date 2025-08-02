/**
 * OpenSelectedTicket.cs
 * 
 * This script contains the logic for clicking on a ticket box and navigating to the ticket info page
 * 
 * @author Austin Hwang
 * @date 31 July 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenSelectedTicket : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject event_system;

    private void Awake()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (event_system != null)
        {
            PageManager pm = event_system.GetComponent<PageManager>();
            if (pm != null && GetComponent<TicketBoxAttributes>() != null)
            {
                pm.ShowTicketPage(GetComponent<TicketBoxAttributes>().ticket);
            }
        }
    }
}
