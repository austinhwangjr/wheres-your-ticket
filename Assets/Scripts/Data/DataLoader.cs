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
using System.Linq;

public static class JsonHelper
{
    public static string fixJson(string value)
    {
        value = "{" + value + "}";
        return value;
    }

    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

public static class DataLoader
{
    public static List<TicketData> LoadTicketData()
    {
        TextAsset ticketDataText = Resources.Load<TextAsset>("JSON Data/TicketData");
        List<TicketData> tickets = new List<TicketData>(JsonHelper.FromJson<TicketData>(ticketDataText.text));
        return tickets;
    }

    public static List<UserData> LoadUserData()
    {
        TextAsset userDataText = Resources.Load<TextAsset>("JSON Data/UserData");
        List<UserData> users = new List<UserData>(JsonHelper.FromJson<UserData>(userDataText.text));
        return users;
    }

    // Helper class for JSON list deserialization
    [System.Serializable]
    private class SerializationList<T>
    {
        public List<T> items;
        public List<T> ToList() => items;
    }
}