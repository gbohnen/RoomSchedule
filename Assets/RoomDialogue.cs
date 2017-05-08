using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RoomDialogue : MonoBehaviour {

    public Text header;
    public GameObject toggleParent;
    public GameObject warning;
    public Room currentRoom;

    public void LoadPanel(Room name)
    {
        currentRoom = name;

        header.text = name.RoomName;
        var list = toggleParent.GetComponentsInChildren<Toggle>();

        foreach (Toggle toggle in list)
        {
            toggle.isOn = false;
        }

        warning.SetActive(false);
    }

    public bool CheckToggles()
    {
        var list = toggleParent.GetComponentsInChildren<Toggle>();
        List<Toggle> toggles = list.ToList<Toggle>();

        if (!toggles.All(x => x.isOn == true))
            warning.SetActive(true);

        return toggles.All(x => x.isOn == true);
    }

}
