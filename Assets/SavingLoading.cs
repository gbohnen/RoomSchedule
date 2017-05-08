using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SavingLoading
{
    static string path = @"..\cleaningrooms.txt";

    public static void SaveData(Dictionary<string, Room> roomList)
    {
        using (StreamWriter outputFile = new StreamWriter(path))
        {
            // only need to save room name and list of cleaning dates
            foreach (KeyValuePair<string, Room> pair in roomList)
            {
                outputFile.WriteLine(pair.Key + ":" + ListToString(pair.Value.CleaningDates));
            }
        }
    }

    static public Dictionary<string, Room> LoadData()
    {

        return null;
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
