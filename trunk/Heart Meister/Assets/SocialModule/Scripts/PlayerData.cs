using UnityEngine;
using System.Collections.Generic;
using SocialModule.Avatar;
using Webservice;

public class PlayerData : MonoBehaviour
{
	private string id = "1";
	private string playerName = "Hizkia";
    private int isMale;
    private int money;
    private string facebook;
    private List<Friend> friends;
    private List<Avatars> avatars;
    private WebService ws;
    private Dictionary<string, System.Object> resultDict;
    private List<System.Object> resultList;
    private string serverAddress;
    private int serverPort;
    private PerformanceCounter pc;
	
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.serverAddress = "192.168.0.105";
        this.serverPort = 55555;
    }

    void Start()
    {
        RetrievePlayerData();
        RetrieveFriendsList();
        RetrieveAvatarsList();
    }

    public string ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public string PlayerName
    {
        get { return this.playerName; }
        set { this.playerName = value; }
    }

    public int IsMale
    {
        get { return this.isMale; }
        set { this.isMale = value; }
    }

    public int Money
    {
        get { return this.money; }
        set { this.money = value; }
    }

    public string Facebook
    {
        get { return this.facebook; }
        set { this.facebook = value; }
    }

    public List<Friend> Friends
    {
        get { return this.friends; }
        set { this.friends = value; }
    }

    public List<Avatars> Avatars
    {
        get { return this.avatars; }
        set { this.avatars = value; }
    }

    public string ServerAddress
    {
        get { return this.serverAddress; }
        set { this.serverAddress = value; }
    }

    public int ServerPort
    {
        get { return this.serverPort; }
        set { this.serverPort = value; }
    }

    public void RetrievePlayerData()
    {
        ws = new WebService();
        resultDict = ws.GetPlayerData(int.Parse(id));
        PlayerName = (string)resultDict["playername"];
        Money = int.Parse((string)resultDict["money"]);
        IsMale = int.Parse((string)resultDict["male"]);
        Facebook = (string)resultDict["facebook"];
    }

    public void RetrieveFriendsList()
    {
        pc = new PerformanceCounter();
        pc.Start();
        ws = new WebService();
        resultList = ws.GetFriends(int.Parse(id));
        List<Friend> friends = new List<Friend>();
        foreach (object o in resultList)
        {
            resultDict = o as Dictionary<string, System.Object>;
            friends.Add(new Friend(int.Parse((string)resultDict["targetid"])));
        }
        Friends = friends;
        Debug.Log("Mengambil daftar teman: " + pc.End() + "ms");
    }

    public void RetrieveAvatarsList()
    {
        pc = new PerformanceCounter();
        pc.Start();
        ws = new WebService();
        resultList = ws.GetOwnedAvatar(int.Parse(id));
        avatars = new List<Avatars>();
        foreach (object o in resultList)
        {
            resultDict = o as Dictionary<string, System.Object>;
            if (((string)resultDict["inauction"]).Equals("1"))
                continue;
            if (int.Parse((string)resultDict["type"]) == 0)
            {
                avatars.Add(new HeadAvatar(int.Parse((string)resultDict["ownershipid"]),
                    (string)resultDict["avatarname"],
                    Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]),
                    Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["editorsprite"]),
                    Resources.Load<Texture2D>("Textures/" + (string)resultDict["iconsprite"]),
                    int.Parse((string)resultDict["gender"]),
                    int.Parse((string)resultDict["isequiped"]),
                    int.Parse((string)resultDict["inauction"])));
            }
            else if (int.Parse((string)resultDict["type"]) == 1)
            {
                avatars.Add(new TopAvatar(int.Parse((string)resultDict["ownershipid"]),
                    (string)resultDict["avatarname"],
                    Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]),
                    Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["editorsprite"]),
                    Resources.Load<Texture2D>("Textures/" + (string)resultDict["iconsprite"]),
                    int.Parse((string)resultDict["gender"]),
                    int.Parse((string)resultDict["isequiped"]),
                    int.Parse((string)resultDict["inauction"])));
            }
            else if (int.Parse((string)resultDict["type"]) == 2)
            {
                avatars.Add(new BottomAvatar(int.Parse((string)resultDict["ownershipid"]),
                    (string)resultDict["avatarname"],
                    Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]),
                    Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["editorsprite"]),
                    Resources.Load<Texture2D>("Textures/" + (string)resultDict["iconsprite"]),
                    int.Parse((string)resultDict["gender"]),
                    int.Parse((string)resultDict["isequiped"]),
                    int.Parse((string)resultDict["inauction"])));
            }
        }
        Debug.Log("Mengambil daftar avatar: " + pc.End() + "ms");
    }

    public void ChangeAvatar(Avatars equiped, Avatars unequiped)
    {
        ws = new WebService();
        //Debug.Log(equiped.OwnershipID + " - " + unequiped.OwnershipID);
        ws.SetAvatars(equiped.OwnershipID, unequiped.OwnershipID);
    }
}
