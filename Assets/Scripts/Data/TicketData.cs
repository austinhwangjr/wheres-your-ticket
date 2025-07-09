/**
 * TicketData.cs
 * 
 * This class holds the data for a ticket
 * 
 * @author Austin Hwang
 * @date 9 July 2025
 */
using UnityEngine;

[System.Serializable]
public class TicketData
{
    public string title;
    public string description;
    public string task;
    public string classification;
}

[System.Serializable]
public class TicketList
{
    public TicketData[] tickets;
}