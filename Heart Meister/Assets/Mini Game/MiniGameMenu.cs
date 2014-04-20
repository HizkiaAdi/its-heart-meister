using UnityEngine;
using System.Collections;

public class MiniGameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 45, Screen.width / 3 - 10, Screen.height / 3 - 10), "Attack"))
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width / 3 + 5, 45, Screen.width / 3 - 10, Screen.height / 3 - 10), "Defense"))
        {
            Application.LoadLevel(2);
        }

        if (GUI.Button(new Rect(2 * Screen.width / 3, 45, Screen.width / 3 - 10, Screen.height / 3 - 10), "Speed"))
        {

        }

        if (GUI.Button(new Rect(10, Screen.height / 2 + 20, Screen.width / 3 - 10, Screen.height / 3 - 10), "Special Attack"))
        {

        }

        if (GUI.Button(new Rect(Screen.width / 3 + 5, Screen.height / 2 + 20, Screen.width / 3 - 10, Screen.height / 3 - 10), "Special Defense"))
        {

        }

        if (GUI.Button(new Rect(2 * Screen.width / 3, Screen.height / 2 + 20, Screen.width / 3 - 10, Screen.height / 3 - 10), "Health"))
        {

        }
    }
}
