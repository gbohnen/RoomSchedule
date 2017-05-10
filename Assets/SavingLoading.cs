using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SavingLoading
{
    static string path = @"..\cleaningrooms.txt";

    public static void SaveData(Dictionary<string, Room> roomList)
    {
            // only need to save room name and list of cleaning dates
        foreach (KeyValuePair<string, Room> pair in roomList)
        {
            PlayerPrefs.SetString(pair.Key, ListToString(pair.Value.CleaningDates));
        }
    }

    static public void LoadData(Dictionary<string, Room> data)
    {
        foreach (KeyValuePair<string, Room> pair in data)
        {
            if (PlayerPrefs.HasKey(pair.Key))
                PlayerPrefs.SetString(pair.Key, ListToString(pair.Value.CleaningDates));
            else
                PlayerPrefs.SetString(pair.Key, ListToString(new List<Date>()));
        }
    }

    static string ListToString(List<Date> list)
    {
        string str = "";

        foreach (Date date in list)
        {
            str += date.PrintDateShort();
            str += ":";
        }

        return str;
    }

    static List<Date> StringToList(string str)
    {

        return null;
    }
}
