using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDialogue : MonoBehaviour {

    public Text header;

    public void LoadPanel(string name)
    {
        header.text = name;
    }

}
