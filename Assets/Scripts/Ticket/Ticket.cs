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

    // Data from JSON
    public string title { get; set; }               // In TicketData.cs and TicketData.JSON
    public string description { get; set; }         // In TicketData.cs and TicketData.JSON
    public IssueType issue_type { get; set; }       // In TicketData.cs and TicketData.JSON
    public string classification { get; set; }      // In TicketData.cs and TicketData.JSON
    public string created_by { get; set; }          // In UserData.cs and UserData.JSON

    // Calculated data
    public string priority { get; set; }
    public int minutes_for_completion { get; set; }
    public int due_by { get; set; }
    public string remaining_time { get; set; } // Probably not needed
    //public List<string> comments { get; set; } // May or may not do commenting system

    public bool is_completed { get; set; }
    public bool desktop_opened_before { get; set; }

    // Constructor
    private Ticket(TicketData ticketData, UserData userData)
    {
        // Set ticket ID
        if (GameObject.Find("EventSystem") != null)
        {
            id = PageManager.instance.current_ticket_id;
            PageManager.instance.current_ticket_id++;
        }

        // Set ticket data from JSON
        title = ticketData.title;
        description = ticketData.description;
        classification = ticketData.classification;
        created_by = userData.name;
        
        // Convert issue type string to enum
        switch (ticketData.issue_type)
        {
            case "WifiNotOn":
                issue_type = IssueType.WifiNotOn;
                break;
            case "WifiOnNoInternet":
                issue_type = IssueType.WifiOnNoInternet;
                break;
            case "VpnCannotConnect":
                issue_type = IssueType.VpnCannotConnect;
                break;
            case "CannotAccessIntranet":
                issue_type = IssueType.CannotAccessIntranet;
                break;
            case "ComputerSlow":
                issue_type = IssueType.ComputerSlow;
                break;
            case "ManuallyMapPrinter":
                issue_type = IssueType.ManuallyMapPrinter;
                break;
            case "ApplySoftwareLicense":
                issue_type = IssueType.ApplySoftwareLicense;
                break;
        }

        // Priority is based on VIP status and classification
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
