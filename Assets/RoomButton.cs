using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour {

    public Text buttonName;
    public Toggle cleaned;
    public Text dateCleaned;
    public Image condition;
    public Text grade;

    public Color terrible;
    public Color bad;
    public Color moderate;
    public Color good;
    public Color great;

    public Room thisRoom;

    public void LoadData(Room newRoom)
    {
        buttonName.text = newRoom.RoomName;
        if (newRoom.CleaningDates.Count > 0)
        {
            dateCleaned.text = newRoom.DateCleaned.PrintDateShort();
            grade.text = newRoom.Grade;
            cleaned.isOn = DateHelper.SinceLastCleaning(newRoom.DateCleaned, RoomManager.Instance.LastReportDate);

            switch (newRoom.Grade)
            {
                case "A": condition.color = great; break;
                case "B": condition.color = good; break;
                case "C": condition.color = moderate; break;
                case "D": condition.color = bad; break;
                case "F": condition.color = terrible; break;
            }
        }
        else
        {
            dateCleaned.text = "";
            grade.text = "F";
            cleaned.isOn = false;
                condition.color = terrible;
        }

        thisRoom = newRoom;
    }

    public void ClickRoom()
    {
        RoomManager.Instance.ClickRoom(thisRoom);
    }
}
