/**
 * UrlBarScript.cs
 * 
 * This script contains the logic for the URL bar. Shows the ticket ID / Home Page depending on the current page.
 * 
 * @author Austin Hwang
 * @date 17 March 2026
 */
using TMPro;
using UnityEngine;

public class UrlBarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PageManager.instance.ticket_selected == null)
        {
            GetComponent<TextMeshPro>().text = "Home Page";
        }
        else
        {
            GetComponent<TextMeshPro>().text = $"Ticket {PageManager.instance.ticket_selected.id} - {PageManager.instance.ticket_selected.title}";
        }
    }
}
