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
    private GameObject event_system;
    private Ticket ticket;

    private void Awake()
    {

    }

    private void Start()
    {
        event_system = GameObject.Find("EventSystem");
    }

    public void SetTicket(Ticket t)
    {
        ticket = t;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (event_system != null)
        {
            PageManager pm = event_system.GetComponent<PageManager>();
            if (pm != null)
            {
                pm.ShowTicketPage(ticket);
            }
        }
    }
}
