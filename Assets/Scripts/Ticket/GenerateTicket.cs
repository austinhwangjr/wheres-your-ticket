using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class GenerateTicket : MonoBehaviour, IPointerClickHandler
{
    public GameObject ticket_textmeshpro;
    public GameObject generated_ticket_box; // TEMP, TO CHANGE WHEN I IMPLEMENT MULTIPLE TICKET BOXES

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
        //button.onClick.AddListener(GenerateTicket);
    }

    // Update is called once per frame
    void Update()
    {
        if (player_input.Gameplay.LeftMouse.triggered)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
            if (hit.collider != null && hit.transform == transform)
            {
                generated_ticket_box.GetComponent<TicketBoxAttributes>().ticket = CreateNewTicket();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //CreateNewTicket();
    }

    private void OnDestroy()
    {
        //button.onClick.RemoveListener(GenerateTicket);
    }

    private Ticket CreateNewTicket()
    {
        Ticket ticket = Ticket.GenerateRandomTicket();

        ticket_textmeshpro.GetComponent<TextMeshPro>().SetText(
            $"Ticket:\n" +
            $"Title: {ticket.title}\n" +
            $"Classification: {ticket.classification}\n" +
            $"Created By: {ticket.created_by}\n" +
            $"Priority: {ticket.priority}\n"
        );

        Debug.Log("GENERATE TICKET");

        return ticket;
    }
}
