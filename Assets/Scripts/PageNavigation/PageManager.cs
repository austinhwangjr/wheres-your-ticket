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
    [SerializeField]
    private GameObject task_overlay;

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
        selected_ticket_box.GetComponent<TicketBoxAttributes>().ticket = ticket_selected;

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

    // When user clicks on button to open the task overlay
    public void ShowTaskOverlay()
    {
        task_overlay.SetActive(true);
    }

    // When user clicks on button to close the task overlay
    public void HideTaskOverlay()
    {
        task_overlay.SetActive(false);
    }
}
