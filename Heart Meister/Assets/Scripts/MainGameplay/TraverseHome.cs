using UnityEngine;
using System.Collections;

public class TraverseHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
            Application.LoadLevel("DungeonMenu");
        }
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 3 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Shop"))
        {
            Application.LoadLevel("Shop");
        }

        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 6 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "To Training Menu"))
        {
            Application.LoadLevel("LevelOptionScene");
        }
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 7 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "To Avatar Menu"))
        {
            Application.LoadLevel("Avatar");
        }
        if (GUI.Button(new Rect(Screen.width * 2 / 4, Screen.height * 7 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Private Messages"))
        {
            Application.LoadLevel("PrivateMessage");
        }
    }
}
