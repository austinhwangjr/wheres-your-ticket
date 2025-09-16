/**
 * DeleteTicket.cs
 * 
 * This script contains the logic for deleting/removing a ticket.
 * For now, tickets are deleted via button click.
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
    [SerializeField]
    private GameObject event_system;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ticket_list_content != null && event_system != null)
        {
            PageManager pm = event_system.GetComponent<PageManager>();
            if (pm != null)
            {
                // On button click, iterate through ticket list and delete the ticket
                for (int i = 0; i < ticket_list_content.transform.childCount; ++i)
                {
                    if (ticket_list_content.transform.GetChild(i).GetComponent<TicketBoxAttributes>().ticket.id == pm.ticket_selected.id)
                    {
                        // Destroy the gameobject itself and redirect to home page
                        Destroy(ticket_list_content.transform.GetChild(i).gameObject);
                        pm.ShowHomePage();
                        break;
                    }
                }
            }
        }
    }
}
