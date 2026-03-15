/**
 * TicketData.cs
 * 
 * This class holds the data for a ticket
 * 
 * @author Austin Hwang
 * @date 9 July 2025
 */
using System;

[System.Serializable]
public class TicketData
{
    public string title;
    public string description;
    public string classification;
    public string issue_type;
}

[Serializable]
public class TicketDataList
{
    public TicketData[] tickets;
}