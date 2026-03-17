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
            response.Add("wmic bios get serialnumber - Display the system's serial number");
            response.Add("sfc /scannow - Clean up system files");
            response.Add("exit - Exit the terminal");
        }
        else if (args[0] == "exit")
        {
            // Exit terminal
            Destroy(gameObject);
        }
        else if (args[0] == "wmic")
        {
            // wmic bios get serialnumber
            if (args.Length == 4 && args[1] == "bios" && args[2] == "get" && args[3] == "serialnumber")
            {
                response.Add("SerialNumber");                
                response.Add(PageManager.instance.ticket_selected.laptop_serial_number);
                Debug.Log("Executed wmic command, returned serial number: " + PageManager.instance.ticket_selected.laptop_serial_number);
            }
            else
            {
                response.Add("Invalid wmic command.");
            }
        }
        else if (args[0] == "sfc")
        {
            // sfc /scannow
            if (args.Length == 2 && args[1] == "/scannow")
            {
                response.Add("Beginning system scan...");
                response.Add("Scan complete. No integrity violations found.");

                // Trigger action after running sfc command
                UserDesktopManager.instance.OnActionPerformed("execute_sfc_scannow");
            }
            else
            {
                response.Add("Invalid sfc command.");
            }
        }
        else
        {
            response.Add("Unknown command. Type help for a list of commands.");
        }
        
        response.Add("");
        return response;
    }
}
