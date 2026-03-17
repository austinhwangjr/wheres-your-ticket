/**
 * TicketCompletedHandler.cs
 * 
 * This script will be attached to each ticket tab, and will handle the logic for when the ticket is completed.
 * 
 * @author Austin Hwang
 * @date 4 Nov 2025
 */
using UnityEngine;

public class TicketCompletedHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject close_ticket_button;

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
        Ticket ticket = PageManager.instance.ticket_selected;

        // Set ticket as completed
        ticket.is_completed = true;

        Debug.Log("Ticket " + ticketID + " completed (wire game).");
        //GameObject.Find("LivesManager").GetComponent<LivesManager>().LoseLife(); //testing
    }

    public void Update()
    {
        if (PageManager.instance.ticket_selected == null)
        {
            return;
        }

        if (PageManager.instance.ticket_selected.is_completed)
        {
            if (close_ticket_button.transform.parent.gameObject.activeSelf == true)
            {
                close_ticket_button.SetActive(true);
            }
            else
            {
                close_ticket_button.SetActive(false);
            }
        }
        else
        {
            close_ticket_button.SetActive(false);
        }
    }
}
