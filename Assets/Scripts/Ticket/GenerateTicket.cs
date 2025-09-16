using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class GenerateTicket : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject all_tickets_list_content;
    [SerializeField]
    private GameObject ticket_box_prefab;

    private PlayerInput player_input;

    private void Awake()
    {
        player_input = new PlayerInput();
    }

    private void OnEnable()
    {
        player_input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        player_input.Gameplay.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //CreateNewTicket();
    }

    private Ticket CreateNewTicket(TextMeshProUGUI textMeshPro)
    {
        Ticket ticket = Ticket.GenerateRandomTicket();

        if (textMeshPro != null)
            {
                textMeshPro.GetComponent<TextMeshProUGUI>().SetText(
                    $"Ticket:\n" +
                    $"Title: {ticket.title}, " +
                    $"Classification: {ticket.classification}, " +
                    $"Created By: {ticket.created_by}, " +
                    $"Priority: {ticket.priority}"
                );
            }

        Debug.Log("GENERATE TICKET");

        return ticket;
    }
}
