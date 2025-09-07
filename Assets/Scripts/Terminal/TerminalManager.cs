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

    private void Awake()
    {
        player_input = new PlayerInput();
        terminal_input.onSubmit.AddListener(HandleSubmit);
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
        message_list.GetComponent<RectTransform>().sizeDelta = new Vector2(messageListSize.x, messageListSize.y + 55f);

        // Instantiate directory line
        GameObject directoryLine = Instantiate(directory_line, message_list.transform);

        // Set child index
        directoryLine.transform.SetSiblingIndex(message_list.transform.childCount - 1);

        // Set text
        directoryLine.GetComponentsInChildren<TMP_Text>()[1].text = input;
    }
}
