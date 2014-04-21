﻿using UnityEngine;
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
            Application.LoadLevel(0);
        }
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 2 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Dungeon"))
        {
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 3 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Shop"))
        {
            Application.LoadLevel(3);
        }
    }
}
