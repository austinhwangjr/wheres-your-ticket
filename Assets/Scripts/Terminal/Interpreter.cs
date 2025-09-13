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

        string[] args = input.Split();

        if (args[0] == "help")
        {
            response.Add("help - Display a list of commands");
            response.Add("exit - Exit the game");
        }
        /*else if (args[0] == "exit")
        {
            Application.Quit();
        }*/
        else
        {
            response.Add("Unknown command. Type help for a list of commands.");
        }

        return response;
    }
}
