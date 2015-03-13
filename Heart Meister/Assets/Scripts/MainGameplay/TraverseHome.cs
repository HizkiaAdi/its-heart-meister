using UnityEngine;
using System.Collections;

public class TraverseHome : MonoBehaviour
{
    public GameObject playerDataContainner;
    public GameObject facebookManager;

	// Use this for initialization
	void Start ()
    {
        if (!GameObject.Find("PlayerDataContainner"))
        {
            GameObject obj = (GameObject)Instantiate(playerDataContainner, this.gameObject.transform.position, Quaternion.identity);
            obj.transform.name = "PlayerDataContainner";
        }
        if (!GameObject.Find("FacebookHandler"))
        {
            GameObject obj = (GameObject)Instantiate(facebookManager, this.gameObject.transform.position, Quaternion.identity);
            obj.transform.name = "FacebookHandler";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 1 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Social Area"))
        {
            Application.LoadLevel("SocialArea");
        }
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 2 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Dungeon"))
        {
            //Application.LoadLevel("DungeonMenu");
        }
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 3 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Shop"))
        {
            //Application.LoadLevel("Shop");
        }
		if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 4 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Auction House"))
		{
			Application.LoadLevel("Auction");
		}
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 5 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Friends List"))
        {
            Application.LoadLevel("FriendList");
        }

        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 6 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "To Training Menu"))
        {
            //Application.LoadLevel("LevelOptionScene");
        }
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 7 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "To Avatar Menu"))
        {
            Application.LoadLevel("Avatar");
        }
        if (GUI.Button(new Rect(Screen.width * 2 / 4, Screen.height * 7 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Private Messages"))
        {
            Application.LoadLevel("PrivateMessage");
        }
        if (GUI.Button(new Rect(Screen.width * 1 / 4, Screen.height * 7 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Option"))
        {
            Application.LoadLevel("Option");
        }
        if (GUI.Button(new Rect(Screen.width * 1 / 4, Screen.height * 3 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Hospital"))
        {
            //Application.LoadLevel("Hospital");
        }
    }
}
