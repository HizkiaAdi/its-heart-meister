using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour
{
	private string id = "5110100082";
	private string playerName = "Hizkia";
	
	/*public GUISkin guiSkin;
	
	void OnGUI()
	{
		GUI.skin = guiSkin;
		GUI.Label(new Rect(25, 10, 50, 20), "ID");
		id = GUI.TextField(new Rect(135, 10, 150, 20), id);
		GUI.Label(new Rect(25, 40, 50, 20), "Name");
		playerName = GUI.TextField(new Rect(135, 40, 150, 20), playerName);
	}*/
    void Awake()
    {
 
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
}
