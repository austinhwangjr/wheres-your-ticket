/**
 * TicketCompletedHandler.cs
 * 
 * This script will be attached to each ticket tab, and will handle the logic for when the ticket is completed.
 * 
 * @author Austin Hwang
 * @date 4 Nov 2025
 */
using System.Collections.Specialized;
using UnityEngine;

public class TicketCompletedHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject delete_ticket_button;

    private void OnEnable()
    {
        WireMatchingWinCondition.TriggerTaskComplete += HandleTicketCompleted;
    }

    private void OnDisable()
    {
        WireMatchingWinCondition.TriggerTaskComplete -= HandleTicketCompleted;
    }

    private void HandleTicketCompleted(int ticketID)
    {
        // Find ticket with id ticketID
        Ticket ticket = GameObject.Find("EventSystem").GetComponent<PageManager>().ticket_selected;

        // Set ticket as completed
        ticket.is_completed = true;
    }

    public void Update()
    {
        if (GameObject.Find("EventSystem").GetComponent<PageManager>().ticket_selected == null)
        {
            return;
        }
        
        if (GameObject.Find("EventSystem").GetComponent<PageManager>().ticket_selected.is_completed)
        {
            if (delete_ticket_button.transform.parent.gameObject.activeSelf == true)
            {
                delete_ticket_button.SetActive(true);
            }
            else
            {
                delete_ticket_button.SetActive(false);
            }
        }
        else
        {
            delete_ticket_button.SetActive(false);
        }
    }
}
