/**
 * DisplayCurrentTicket.cs
 * 
 * This script is used in TicketInformationPage to constantly show the current ticket's information
 * 
 * @author Austin Hwang
 * @date 31 July 2025
 */
using UnityEngine;
using TMPro;

public class DisplayCurrentTicket : MonoBehaviour
{
    //[SerializeField]
    //private GameObject ticket_textmeshpro;
    //private TicketBoxAttributes ticketAttributes;

    [SerializeField]
    private TextMeshPro ticket_title;
    [SerializeField]
    private TextMeshPro ticket_description;
    [SerializeField]
    private TextMeshPro ticket_created_by;
    [SerializeField]
    private TextMeshPro ticket_due_by;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (GetComponent<TicketBoxAttributes>().ticket != null)
        {
            Ticket currentTicket = GetComponent<TicketBoxAttributes>().ticket;
            ticket_title.SetText($"{currentTicket.title}");
            ticket_description.SetText($"{currentTicket.description}");
            ticket_created_by.SetText($"{currentTicket.created_by}");

            // Get am/pm
            int hours24h = currentTicket.due_by / 60;
            int minutes = currentTicket.due_by % 60;
            string amPmString = hours24h >= 12 ? "pm" : "am";
            int hours12 = hours24h % 12 == 0 ? 12 : hours24h % 12;
            ticket_due_by.SetText($"{hours12}:{minutes:00} {amPmString}");
        }

        // if (GetComponent<TicketBoxAttributes>().ticket != null)
        // {
        //     Ticket currentTicket = GetComponent<TicketBoxAttributes>().ticket;
        //     ticket_textmeshpro.GetComponent<TextMeshPro>().SetText(
        //         $"Ticket:\n" +
        //         $"Title: {currentTicket.title}\n" +
        //         $"Description: {currentTicket.description}\n" +
        //         $"Classification: {currentTicket.classification}\n" +
        //         $"Created By: {currentTicket.created_by}\n" +
        //         $"Priority: {currentTicket.priority}\n" +
        //         $"Due By: {currentTicket.due_by / 60}:{currentTicket.due_by % 60:00}"
        //     );
        // }
    }
}
