/**
 * DeleteTicket.cs
 * 
 * This script contains the logic for deleting/removing a ticket.
 * Tickets are deleted via button click (to simulate closing the ticket).
 * 
 * @author Austin Hwang
 * @date 17 September 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteTicket : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject ticket_list_content;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ticket_list_content != null)
        {
            // On button click, iterate through ticket list and delete the ticket
            for (int i = 0; i < ticket_list_content.transform.childCount; ++i)
            {
                if (ticket_list_content.transform.GetChild(i).GetComponent<TicketBoxAttributes>().ticket.id == PageManager.instance.ticket_selected.id)
                {
                    // Destroy the gameobject itself and redirect to home page
                    Destroy(ticket_list_content.transform.GetChild(i).gameObject);
                    if (GameObject.Find("Ticket Tab " + PageManager.instance.ticket_selected.id) != null)
                    {
                        Destroy(GameObject.Find("Ticket Tab " + PageManager.instance.ticket_selected.id));
                    }
                    PageManager.instance.ShowHomePage();
                    break;
                }
            }
        }
    }
}
