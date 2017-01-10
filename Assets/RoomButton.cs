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

        cleaned.isOn = (Random.Range(0, 2) == 1);

        int blurp = Random.Range(0, 5);
        switch (blurp)
        {
            case 0: condition.color = terrible; break;
            case 1: condition.color = bad; break;
            case 2: condition.color = moderate; break;
            case 3: condition.color = good; break;
            case 4: condition.color = great; break;
        }

        thisRoom = newRoom;
    }

    public void ClickRoom()
    {
        RoomManager.Instance.ClickRoom(thisRoom.RoomName);
    }
}
