/**
 * Ticket.cs
 * 
 * This class holds the data for a ticket displayed on IT Center.
 * If a ticket needs certain attributes, it should be added here.
 * Not to be confused with TicketBoxAttributes.cs (for ticket boxes in the home page)
 * 
 * @author Austin Hwang
 * @date 9 July 2025
 */
using UnityEngine;
using System.Collections.Generic;

public class Ticket
{
    public int id { get; set; }
    public string title { get; set; }
    //public string task { get; set; }
    public string classification { get; set; }
    public string created_by { get; set; }
    public string priority { get; set; }
    public string remaining_time { get; set; }
    //public List<string> comments { get; set; } // May or may not do commenting system

    public bool is_completed { get; set; }

    // Constructor
    private Ticket(TicketData ticketData, UserData userData)
    {
        if (GameObject.Find("EventSystem") != null)
        {
            id = GameObject.Find("EventSystem").GetComponent<PageManager>().current_ticket_id;
            GameObject.Find("EventSystem").GetComponent<PageManager>().current_ticket_id++;
        }
        title = ticketData.title;
        //task = ticketData.task;
        classification = ticketData.classification;
        created_by = userData.name;

        // Temporary priority system
        priority = userData.is_VIP ? "P1" : "P5";

        // Set time based on priority
        //remaining_time = CalculateRemainingTime(priority);

        // Set completion status to false by default
        is_completed = false;
    }

    // Generate a random ticket
    public static Ticket GenerateRandomTicket()
    {
        List<TicketData> ticketData = DataLoader.LoadTicketData();
        List<UserData> userData = DataLoader.LoadUserData();

        // Select a random ticket from JSON
        TicketData randomTicket = ticketData[Random.Range(0, ticketData.Count)];

        // Select a random user from JSON
        UserData randomUser = userData[Random.Range(0, userData.Count)];

        return new Ticket(randomTicket, randomUser);
    }
}
