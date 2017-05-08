using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
using UnityEngine.UI;

public enum Building     { ACAD, Centennial, Columbine, Cucharas, Dwire, Engineering, Osborne, Satellite, UHall }

public class Room
{
    public Room(Building b, string n, List<Date> l)
    {
        Building = b;
        RoomName = n;
        CleaningDates = l;
    }


    // date of last cleaning. loaded from bin file
    public Date DateCleaned
    {
        get { return CleaningDates[0]; }
    }

    public Building Building
    { get; set; }

    // name of the room. loaded from xml
    public string RoomName
    { get; set; }

    // list of classes within the room. loaded from xml

    // last grade of room. loaded from private xml
    public string Grade
    { get; set; }

    public List<Date> CleaningDates
    { get; set; }
}

public class RoomManager : MonoBehaviour {

    public static RoomManager Instance;

    Dictionary<string, Room> roomList;

    public GameObject roomButtonPrefab;
    public Transform scrollRect;
    public Scrollbar scrollBar;
    public GameObject roomPanel;

    public Date LastReportDate
    { get; private set; }

	// Use this for initialization
	void Start ()
    {
        Instance = this;

        // get last report date
        if (PlayerPrefs.HasKey("Day") && PlayerPrefs.HasKey("Month") && PlayerPrefs.HasKey("Year"))
            LastReportDate = new Date(PlayerPrefs.GetInt("Day"), PlayerPrefs.GetInt("Month"), PlayerPrefs.GetInt("Year"));
        else
            LastReportDate = new Date(1, 1, 1969);

        // load default objects
        roomList = new Dictionary<string, Room>();
        
        // load room names and times
        TextAsset roomFile = (TextAsset)Resources.Load(@"RoomData");
        XmlDocument roomDoc = new XmlDocument();
        roomDoc.LoadXml(roomFile.text);

        XmlNodeList list = roomDoc.GetElementsByTagName("rooms");
        XmlNodeList buildingList = list[0].ChildNodes;

        // load each room from each building
        foreach (XmlNode buildingNode in buildingList)
        {
            foreach (XmlNode roomNode in buildingNode.ChildNodes)
            {
                // build name of room
                string name;
                if (buildingNode.Name != "Satellite")
                    name = buildingNode.Name + " " + roomNode.Name.Substring(1);
                else
                    name = roomNode.Name;

                // new room
                Room room = new Room((Building)Enum.Parse(typeof(Building), buildingNode.Name), name, new List<Date>());

                // load room times
                // something something parse roomNode.InnerText

                // load date cleaned
                // something something binary formatter and parser

                // load most recent grade
                // something something xml parser other document

                // add the room to list
                roomList.Add(name, room);
            }
        }

        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where( x => x.RoomName != null).ToList<Room>();
        BuildRoomList(linqlist);

        // set deafault UI state
        ClosePanel();
	}

    public void BuildRoomList(List<Room> list)
    {
        // destroy all buttons 
        for (int i = scrollRect.childCount - 1; i >= 0; i--)
        {
            Destroy(scrollRect.GetChild(i).gameObject);
        }

        // populate new list
        foreach (Room room in list)
        {
            GameObject button = Instantiate(roomButtonPrefab);
            button.transform.SetParent(scrollRect);

            button.GetComponent<RoomButton>().LoadData(room);
        }

        scrollBar.value = 1;
    }

    #region Navigation Buttons

    public void ClickAll()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.RoomName != null).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickACAD()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.ACAD).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickCentennial()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.Centennial).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickColumbine()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.Columbine).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickCucharas()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.Cucharas).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickDwire()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.Dwire).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickEngineering()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.Engineering).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickOsborne()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.Osborne).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickSatellite()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.Satellite).ToList<Room>();
        BuildRoomList(linqlist);
    }

    public void ClickUHall()
    {
        List<Room> temp = roomList.Values.ToList<Room>();
        var linqlist = temp.Where(x => x.Building == Building.UHall).ToList<Room>();
        BuildRoomList(linqlist);
    }

    #endregion

    public void ClosePanel()
    {
        roomPanel.SetActive(false);
    }

    public void ClickRoom(Room name)
    {
        roomPanel.SetActive(true);
        roomPanel.GetComponent<RoomDialogue>().LoadPanel(name);
    }

    public void ClickConfirm()
    {
        if (roomPanel.GetComponent<RoomDialogue>().CheckToggles())
        {
            roomPanel.GetComponent<RoomDialogue>().currentRoom.CleaningDates.Add(DateHelper.GetTodaysDate());
            ClickAll();
            ClosePanel();
        }
    }
}
