/**
 * UserData.cs
 * 
 * This class holds the data for a user
 * 
 * @author Austin Hwang
 * @date 9 July 2025
 */
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string name;
    public bool is_VIP;
}

[System.Serializable]
public class UserDataList
{
    public UserData[] users;
}