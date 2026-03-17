/**
 * TicketManager.cs
 * 
 * This class manages tickets (TEMP FILE DESC)
 * 
 * @author Austin Hwang
 * @date 9 July 2025
 */
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    public static TicketManager instance { get; private set; }

    // Tracks tickets that are still active (not yet resolved or expired)
    private readonly List<Ticket> active_tickets = new();

    private int current_minute_total;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnEnable()
    {
        TimerScript.OnMinuteChanged += HandleMinuteChanged;
    }

    private void OnDisable()
    {
        TimerScript.OnMinuteChanged -= HandleMinuteChanged;
    }

    private void HandleMinuteChanged(int hours, int minutes)
    {
        current_minute_total = (hours * 60) + minutes;

        // Iterate backwards so we can safely remove while looping
        for (int i = active_tickets.Count - 1; i >= 0; --i)
        {
            Ticket ticket = active_tickets[i];

            if (current_minute_total >= ticket.due_by)
            {
                Debug.Log($"Ticket '{ticket.title}' overdue. Deducting life.");
                LivesManager.instance.LoseLife();
                active_tickets.RemoveAt(i);
            }
        }
    }

    // Called by GenerateTicket after creating a ticket
    public void RegisterTicket(Ticket ticket)
    {
        active_tickets.Add(ticket);
        Debug.Log($"Ticket '{ticket.title}' registered. Due at {ticket.due_by / 60}:{ticket.due_by % 60:00}");
    }

    // Called when the player resolves a ticket
    public void ResolveTicket(Ticket ticket)
    {
        if (active_tickets.Remove(ticket))
            Debug.Log($"Ticket '{ticket.title}' resolved in TicketManager.");
        else
            Debug.LogWarning($"Tried to resolve ticket '{ticket.title}' but it wasn't in the active list.");

        
    }
}
