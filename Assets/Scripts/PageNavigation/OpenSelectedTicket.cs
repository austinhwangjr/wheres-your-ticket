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
using UnityEngine.UIElements;

public class OpenSelectedTicket : MonoBehaviour, IPointerClickHandler
{
    private GameObject event_system;
    private GameObject tickets_tab_group;

    [SerializeField]
    private GameObject ticket_tab_prefab;

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
            PageManager pm = event_system.GetComponent<PageManager>();
            if (pm != null && GetComponent<TicketBoxAttributes>() != null)
            {
                // When clicking on ticket in the home page (all tickets page), create respective tab box and open ticket
                GameObject generatedTicketTab = Instantiate(ticket_tab_prefab, tickets_tab_group.transform);

                Vector3 newPos = generatedTicketTab.transform.position;
                newPos.x = -8.427f + (tickets_tab_group.transform.childCount - 1) * (2.30573f + 0.2f); // TEMP
                generatedTicketTab.transform.position = newPos;

                generatedTicketTab.GetComponent<OpenTicketTab>().SetTicket(GetComponent<TicketBoxAttributes>().ticket);
                Transform ticketTabText = generatedTicketTab.transform.GetChild(0);   // TEMP, Ticket Box Text is the only child for now
                ticketTabText.GetComponent<TextMeshPro>().SetText("Ticket " + GetComponent<TicketBoxAttributes>().ticket.id);

                pm.ShowTicketPage(GetComponent<TicketBoxAttributes>().ticket);
            }
        }
    }
}
