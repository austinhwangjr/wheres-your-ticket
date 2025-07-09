/**
 * DataLoader.cs
 * 
 * This class loads data from JSON files (in Assets/Resources/JSON Data/)
 * 
 * @author Austin Hwang
 * @date 9 July 2025
 */
using UnityEngine;
using System.Collections.Generic;

public static class DataLoader
{
    public static List<TicketData> LoadTicketData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON Data/TicketData");
        Debug.Log("Ticket Data: " + jsonFile.text);
        return JsonUtility.FromJson<SerializationList<TicketData>>(jsonFile.text).ToList();
    }

    public static List<UserData> LoadUserData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON Data/UserData");
        return JsonUtility.FromJson<SerializationList<UserData>>(jsonFile.text).ToList();
    }

    // Helper class for JSON list deserialization
    [System.Serializable]
    private class SerializationList<T>
    {
        public List<T> items;
        public List<T> ToList() => items;
    }
}