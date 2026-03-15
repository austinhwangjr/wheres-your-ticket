/**
 * OpenSelectedTicket.cs
 * 
 * This script contains the logic for clicking on a ticket box and navigating to the ticket info page
 * 
 * @author Austin Hwang
 * @date 31 July 2025
 */
//using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenSelectedTicket : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject ticket_tab_prefab;
    
    private GameObject event_system;
    private GameObject tickets_tab_group;

    private void Awake()
    {

    }

    private void Start()
    {
        event_system = GameObject.Find("EventSystem");
        tickets_tab_group = GameObject.Find("Tickets Tab Group");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (event_system != null)
        {
            if (GetComponent<TicketBoxAttributes>() != null)
            {
                if (GameObject.Find("Ticket Tab " + GetComponent<TicketBoxAttributes>().ticket.id) == null)
                {
                    // When clicking on ticket in the home page (all tickets page), create respective tab box and open ticket
                    GameObject generatedTicketTab = Instantiate(ticket_tab_prefab, tickets_tab_group.transform);
                    generatedTicketTab.name = "Ticket Tab " + GetComponent<TicketBoxAttributes>().ticket.id;
                    generatedTicketTab.GetComponentInChildren<OpenTicketTab>().SetTicket(GetComponent<TicketBoxAttributes>().ticket);
                    generatedTicketTab.GetComponentInChildren<TextMeshPro>().SetText("Ticket " + GetComponent<TicketBoxAttributes>().ticket.id);
                }

                PageManager.instance.ShowTicketPage(GetComponent<TicketBoxAttributes>().ticket);
            }
        }
    }
}
