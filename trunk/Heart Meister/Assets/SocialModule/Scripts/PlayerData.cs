using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour
{
	public static string id = "5110100082";
	public static string playerName = "Hizkia";
	
	public GUISkin guiSkin;
	
	void OnGUI()
	{
		GUI.skin = guiSkin;
		GUI.Label(new Rect(25, 10, 50, 20), "ID");
		id = GUI.TextField(new Rect(135, 10, 150, 20), id);
		GUI.Label(new Rect(25, 40, 50, 20), "Name");
		playerName = GUI.TextField(new Rect(135, 40, 150, 20), playerName);
	}
}
