using UnityEngine;
using System.Collections.Generic;
using CustomGUI;

public class GUIScript : MonoBehaviour
{
	GUIButton TheButton;

	void Start () 
	{
		TheButton = new GUIButton(1, 1, 1, 15, 10, "Hello World", CallbackFunction);
		TheButton.Visible = true;
	}

	void CallbackFunction(int id, Dictionary<string, string> callbackResult)
	{
		Debug.Log("HelloWorld");
	}
}
