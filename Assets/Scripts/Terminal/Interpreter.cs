/**
 * Interpreter.cs
 * 
 * This script contains the logic for commands in the in-game terminal.
 * 
 * @author Austin Hwang
 * @date 13 September 2025
 */
using UnityEngine;
using System.Collections.Generic;

public class Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();

    public List<string> Interpret(string input)
    {
        response.Clear();

        if (string.IsNullOrWhiteSpace(input))
            return response;

        string[] args = input.ToLower().Split();
        string command = args[0];

        if (command == "help")
        {
            response.Add("Available Commands:");
            response.Add("help - Display a list of commands");
            response.Add("exit - Exit the game");
            response.Add("wmic bios get serialnumber - Get the system serial number");
        }
        /*else if (command  == "exit")
        {
            Application.Quit();
        }*/
        else if (command == "wmic")
        {
            // wmic bios get serialnumber
            if (args.Length == 4 && args[1] == "bios" && args[2] == "get" && args[3] == "serialnumber")
            {
                response.Add("SerialNumber");
                response.Add("placeholder_S/N"); // TODO: SerialNumber here
            }
            else
            {
                response.Add("Invalid wmic command.");
            }
        }
        else
        {
            response.Add("Unknown command. Type help for a list of commands.");
        }

        return response;
    }
}
