using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class TestGenerateTask : MonoBehaviour
{
    public Button button;
    public GameObject task_textmeshpro;

    InputAction leftMouseAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(GenerateTask);
        //leftMouseAction = InputSystem.actions.FindAction("Click");
    }

    // Update is called once per frame
    void Update()
    {
        // if (leftMouseAction.IsPressed())
        // {
        //     GenerateTask();
        // }
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(GenerateTask);
    }

    private void GenerateTask()
    {
        Ticket ticket = Ticket.GenerateRandomTicket();

        Debug.Log($"Ticket:\n" +
            $"Title: {ticket.title}\n" +
            $"Classification: {ticket.classification}\n" +
            $"Created By: {ticket.created_by}\n" +
            $"Priority: {ticket.priority}\n"
        );

        task_textmeshpro.GetComponent<TextMeshPro>().SetText(
            $"Ticket:\n" +
            $"Title: {ticket.title}\n" +
            $"Classification: {ticket.classification}\n" +
            $"Created By: {ticket.created_by}\n" +
            $"Priority: {ticket.priority}\n"
        );

        //task.GetComponent<TextMeshProUGUI>().SetText("TASK GENERATED");
        // Ticket ticket = Ticket.GenerateRandomTicket();
        // Debug.Log($"Ticket:\n" +
        //           $"Title: {ticket.title}\n" +
        //           $"Classification: {ticket.classification}\n" +
        //           $"Created By: {ticket.created_by}\n" +
        //           $"Priority: {ticket.priority}\n"
        //);
    }
}
