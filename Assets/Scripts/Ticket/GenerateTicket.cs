/**
 * GenerateTicket.cs
 * 
 * This script generates tickets. For now, it generates a random ticket via button click.
 * 
 * @author Austin Hwang
 * @date 20 July 2025
 */
using UnityEngine;
using TMPro;

public class GenerateTicket : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject all_tickets_list_content;
    [SerializeField]
    private GameObject ticket_box_prefab;

    [Header("Audio")]
    [SerializeField]
    private AudioClip ticket_generation_sfx;
    [SerializeField]
    private float volume = 1f;

    [Header("Ticket Generation Timing (in-game minutes)")]
    [SerializeField]
    private int min_interval = 15;
    [SerializeField]
    private int max_interval = 25;

    private int next_ticket_minute;  // when the next ticket will be generated (in in-game minutes)
    private int current_minute_total; // current in-game time in total minutes

    private PlayerInput player_input;

    private void Awake()
    {
        player_input = new PlayerInput();
    }

    private void OnEnable()
    {
        player_input.Gameplay.Enable();

        TimerScript.OnMinuteChanged += HandleMinuteChanged;
    }

    private void OnDisable()
    {
        player_input.Gameplay.Disable();

        TimerScript.OnMinuteChanged -= HandleMinuteChanged;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScheduleNextTicket();
    }

    private void HandleMinuteChanged(int hours, int minutes)
    {
        current_minute_total = (hours * 60) + minutes;

        if (current_minute_total >= next_ticket_minute)
        {
            GenerateNewTicket();
            ScheduleNextTicket();
        }
    }

    private void ScheduleNextTicket()
    {
        int interval = Random.Range(min_interval, max_interval + 1);
        next_ticket_minute = current_minute_total + interval;
    }

    // Generates a ticket box, and assigns it a ticket
    private void GenerateNewTicket()
    {
        GameObject generated_ticket_box = Instantiate(ticket_box_prefab, all_tickets_list_content.GetComponent<RectTransform>());
        TicketBoxAttributes ticketBoxAttributes = generated_ticket_box.GetComponent<TicketBoxAttributes>();
        //Transform ticketBoxText = generated_ticket_box.transform.GetChild(0);

        //if (ticketBoxAttributes == null || ticketBoxText == null)
        if (ticketBoxAttributes == null)
        {
            Debug.LogError("Missing TicketBoxAttributes or TicketBoxText on generated ticket box.");
            return;
        }

        //ticketBoxAttributes.ticket = CreateNewTicket(ticketBoxText.GetComponent<TextMeshProUGUI>());
        ticketBoxAttributes.ticket = CreateNewTicket();
        
        // Populate ticket box text with ticket info
        Debug.Log("Children count: " + generated_ticket_box.transform.childCount);
        foreach (Transform child in generated_ticket_box.transform)
        {
            switch (child.name)
            {
                case "Ticket ID (Text)":
                    child.GetComponent<TextMeshProUGUI>().SetText(ticketBoxAttributes.ticket.id.ToString());
                    break;
                case "Ticket Title (Text)":
                    child.GetComponent<TextMeshProUGUI>().SetText(ticketBoxAttributes.ticket.title);
                    break;
                case "Ticket Classification (Text)":
                    child.GetComponent<TextMeshProUGUI>().SetText(ticketBoxAttributes.ticket.classification);
                    break;
                case "Ticket Created By (Text)":
                    child.GetComponent<TextMeshProUGUI>().SetText(ticketBoxAttributes.ticket.created_by);
                    break;
                case "Ticket Priority (Text)":
                    child.GetComponent<TextMeshProUGUI>().SetText(ticketBoxAttributes.ticket.priority);
                    break;
                case "Ticket Due By (Text)":
                    int hours24h = ticketBoxAttributes.ticket.due_by / 60;
                    int minutes = ticketBoxAttributes.ticket.due_by % 60;
                    string amPmString = hours24h >= 12 ? "pm" : "am";
                    int hours12 = hours24h % 12 == 0 ? 12 : hours24h % 12;
                    child.GetComponent<TextMeshProUGUI>().SetText($"{hours12}:{minutes:00} {amPmString}");
                    break;
            }

        }

        // Play SFX
        AudioManager.instance.PlaySFXClip(ticket_generation_sfx, transform, volume);
        Debug.Log($"Ticket generated at in-game time {current_minute_total / 60}:{current_minute_total % 60:00}");

        // Register with TicketManager so it tracks the due time
        TicketManager.instance.RegisterTicket(ticketBoxAttributes.ticket);
    }

    // Update is called once per frame
    /*void Update()
    {
        // Raycast to check if button is clicked
        if (player_input.Gameplay.LeftMouse.triggered)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
            if (hit.collider != null && hit.transform == transform)
            {
                // Generate a new instance of the ticket box prefab
                GameObject generated_ticket_box = Instantiate(ticket_box_prefab, all_tickets_list_content.GetComponent<RectTransform>());

                // Assign generated ticket box with new ticket data
                TicketBoxAttributes ticketBoxAttributes = generated_ticket_box.GetComponent<TicketBoxAttributes>();
                Transform ticketBoxText = generated_ticket_box.transform.GetChild(0);   // TEMP, Ticket Box Text is the only child for now

                if (ticketBoxAttributes == null)
                {
                    Debug.LogError("TicketBoxAttributes component not found on generated ticket box");
                }
                if (ticketBoxText == null)
                {
                    Debug.LogError("Ticket Box Text child not found on generated ticket box");
                }
                if (ticketBoxAttributes != null && ticketBoxText != null)
                {
                    ticketBoxAttributes.ticket = CreateNewTicket(ticketBoxText.GetComponent<TextMeshProUGUI>());
                    Debug.Log("Ticket box assigned with ticket data");
                }
                
                //generated_ticket_box.GetComponent<TicketBoxAttributes>().ticket = CreateNewTicket();
            }
        }
    }*/

    // private Ticket CreateNewTicket(TextMeshProUGUI textMeshPro)
    // {
    //     Ticket ticket = Ticket.GenerateRandomTicket();
    //     ticket.due_by = ticket.minutes_for_completion + current_minute_total;

    //     if (textMeshPro != null)
    //     {
    //         // Display is done in main ticket page
    //         textMeshPro.GetComponent<TextMeshProUGUI>().SetText(
    //             $"Ticket:\n" +
    //             $"Title: {ticket.title}, " +
    //             $"Classification: {ticket.classification}, " +
    //             $"Created By: {ticket.created_by}, " +
    //             $"Priority: {ticket.priority}, " +
    //             $"Due By: {ticket.due_by / 60}:{ticket.due_by % 60:00}"
    //         );
    //     }

    //     return ticket;
    // }

    private Ticket CreateNewTicket()
    {
        Ticket ticket = Ticket.GenerateRandomTicket();
        ticket.due_by = ticket.minutes_for_completion + current_minute_total;

        return ticket;
    }
}
