using UnityEngine;
using TMPro;

public class DisplayCurrentTicket : MonoBehaviour
{
    [SerializeField]
    private GameObject ticket_textmeshpro;
    //private TicketBoxAttributes ticketAttributes;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (GetComponent<TicketBoxAttributes>().ticket != null)
        {
            Ticket currentTicket = GetComponent<TicketBoxAttributes>().ticket;
            ticket_textmeshpro.GetComponent<TextMeshPro>().SetText(
                $"Ticket:\n" +
                $"Title: {currentTicket.title}\n" +
                $"Classification: {currentTicket.classification}\n" +
                $"Created By: {currentTicket.created_by}\n" +
                $"Priority: {currentTicket.priority}\n"
            );
        }
    }
}
