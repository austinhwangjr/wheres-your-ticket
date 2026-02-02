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
    public string description { get; set; }
    //public string task { get; set; }
    public string classification { get; set; }
    public string created_by { get; set; }
    public string priority { get; set; }
    public int minutes_for_completion { get; set; }
    public int due_by { get; set; }
    public string remaining_time { get; set; } // Probably not needed
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
        description = ticketData.description;
        //task = ticketData.task;
        classification = ticketData.classification;
        created_by = userData.name;

        // Temporary priority system
        //priority = userData.is_VIP ? "P1" : "P5";
        if (userData.is_VIP)
        {
            priority = "P1";
        }
        else
        {
            if (classification == "IT Issue")
            {
                priority = "P2";
            }
            else
            {
                priority = "P3";
            }
        }

        // Based on priority, set minutes for completion
        switch (priority)
        {
            case "P1":
                minutes_for_completion = 30;
                break;
            case "P2":
                minutes_for_completion = 60;
                break;
            case "P3":
                minutes_for_completion = 120;
                break;
        }

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
