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
        float buttonHeight = Screen.height / 4, buttonWidth = Screen.width / 4;

        if (GUI.Button(new Rect(10, 45, Screen.width / 3 - 10, Screen.height / 3 - 10), "Attack"))
        {
            Application.LoadLevel("AttackScene");
        }

        if (GUI.Button(new Rect(Screen.width / 3 + 5, 45, Screen.width / 3 - 10, Screen.height / 3 - 10), "Defense"))
        {
            Application.LoadLevel("DefenseScene");
        }

        if (GUI.Button(new Rect(2 * Screen.width / 3, 45, Screen.width / 3 - 10, Screen.height / 3 - 10), "Speed"))
        {
			Application.LoadLevel("SpeedScene");
        }

        if (GUI.Button(new Rect(10, Screen.height / 2 + 20, Screen.width / 3 - 10, Screen.height / 3 - 10), "Special Attack"))
        {

        }

        if (GUI.Button(new Rect(Screen.width / 3 + 5, Screen.height / 2 + 20, Screen.width / 3 - 10, Screen.height / 3 - 10), "Special Defense"))
        {
            Application.LoadLevel("SpecialDefenseScene");
        }

        if (GUI.Button(new Rect(2 * Screen.width / 3, Screen.height / 2 + 20, Screen.width / 3 - 10, Screen.height / 3 - 10), "Health"))
        {
            Application.LoadLevel("HealthScene");
        }

		if (GUI.Button (new Rect (Screen.width * 0.01f * 10, Screen.height * 0.01f * 90, Screen.width * 0.01f * 80, Screen.height * 0.01f * 8), "Home"))
		{
			Application.LoadLevel("Home");
		}
    }
}
