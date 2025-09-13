/**
 * TerminalManager.cs
 * 
 * This script contains the logic for the in-game terminal.
 * 
 * @author Austin Hwang
 * @date 7 September 2025
 */
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class TerminalManager : MonoBehaviour
{
    // Player input singleton
    private PlayerInput player_input;

    // Output prefabs
    [SerializeField]
    private GameObject directory_line;
    [SerializeField]
    private GameObject response_line;

    // Input prefabs
    [SerializeField]
    private TMP_InputField terminal_input;
    [SerializeField]
    private GameObject user_input_line;

    // GameObjects for terminal
    [SerializeField]
    private ScrollRect scroll_rect;
    [SerializeField]
    private GameObject message_list;

    Interpreter interpreter;

    private void Awake()
    {
        player_input = new PlayerInput();
        terminal_input.onSubmit.AddListener(HandleSubmit);
    }

    private void Start()
    {
        interpreter = GetComponent<Interpreter>();
    }

    private void OnEnable()
    {
        player_input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        player_input.Gameplay.Disable();
    }

    private void HandleSubmit(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return;
        }

        // Add directory line
        ClearInputField();
        AddDirectoryLine(input);

        // Add interpretation lines
        int lines = AddInterpreterLines(interpreter.Interpret(input));

        // Scroll to bottom
        ScrollToBottom(lines);

        // Push terminal input to the bottom
        user_input_line.transform.SetAsLastSibling();

        // Re-focus on input field
        terminal_input.ActivateInputField();
        terminal_input.Select();

        // OLD METHOD, IN ONGUI
        /*if (terminal_input.isFocused && terminal_input.text != "" && player_input.Gameplay.RightShift.WasPerformedThisFrame())
        {
            Debug.Log("Enter");
            // Store user input and clear input field
            //string input = terminal_input.text;

            // Add directory line
            ClearInputField();
            AddDirectoryLine(input);

            // Push terminal input to the bottom
            user_input_line.transform.SetAsLastSibling();

            // Re-focus on input field
            terminal_input.ActivateInputField();
            terminal_input.Select();
        }*/
    }

    private void ClearInputField()
    {
        terminal_input.text = "";
    }

    private void AddDirectoryLine(string input)
    {
        // Resize command line container
        Vector2 messageListSize = message_list.GetComponent<RectTransform>().sizeDelta;
        message_list.GetComponent<RectTransform>().sizeDelta = new Vector2(messageListSize.x, messageListSize.y + 35f);

        // Instantiate directory line
        GameObject directoryLine = Instantiate(directory_line, message_list.transform);

        // Set child index
        directoryLine.transform.SetSiblingIndex(message_list.transform.childCount - 1);

        // Set text
        directoryLine.GetComponentsInChildren<TMP_Text>()[1].text = input;
    }

    int AddInterpreterLines(List<string> interpretation)
    {
        for (int i = 0; i < interpretation.Count; ++i)
        {
            // Instantiate response line
            GameObject responseLine = Instantiate(response_line, message_list.transform);

            // Set child index (last index)
            responseLine.transform.SetAsLastSibling();

            // Resize command line container
            Vector2 messageListSize = message_list.GetComponent<RectTransform>().sizeDelta;
            message_list.GetComponent<RectTransform>().sizeDelta = new Vector2(messageListSize.x, messageListSize.y + 35f);

            // Set text
            responseLine.GetComponentsInChildren<TMP_Text>()[0].text = interpretation[i];
        }

        return interpretation.Count;
    }

    private void ScrollToBottom(int lines)
    {
        Debug.Log("Lines: " + lines);
        if (lines > 4)
        {
            scroll_rect.velocity = new Vector2(0f, 300f);
        }
        else
        {
            scroll_rect.verticalNormalizedPosition = 0f;
        }
    }
}
