/**
 * PageManager.cs
 * 
 * This script contains functions for managing pages (page navigation).
 * 
 * @author Austin Hwang
 * @date 31 July 2025
 */
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject home_page;
    [SerializeField]
    private GameObject ticket_information_page;
    [SerializeField]
    private GameObject selected_ticket_box;
    [SerializeField]
    private GameObject tickets_list;

    private Ticket ticket_selected; // The ticket that the user selects

    // When user clicks on a single ticket
    public void ShowTicketPage(Ticket ticket)
    {
        if (home_page != null && ticket_information_page != null && tickets_list != null)
        {
            home_page.SetActive(false);
            ticket_information_page.SetActive(true);
            tickets_list.SetActive(false);
        }

        // Set the selected ticket
        ticket_selected = ticket;
        selected_ticket_box.GetComponent<TicketBoxAttributes>().ticket = ticket;

        Debug.Log("Selected ticket: " + ticket.title);
    }

    // When user goes back to the home page
    public void ShowHomePage()
    {
        home_page.SetActive(true);
        ticket_information_page.SetActive(false);
        tickets_list.SetActive(true);

        // Reset the selected ticket
        ticket_selected = null;
    }
}
