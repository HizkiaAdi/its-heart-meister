using UnityEngine;
using System.Collections;

public class EpicBattleMenuGUI : MonoBehaviour 
{
	float xUnit;
	float yUnit;
	Vector2 scrollPos;
	Rect windowRect;
	Rect scrollViewRect;
	Rect scrollWindowRect;

	void Start()
	{
		xUnit = Screen.width * 0.01f;
		yUnit = Screen.height * 0.01f;
		windowRect = new Rect(5 * xUnit, 25 * yUnit, 40 * xUnit, 60 * yUnit);
		scrollViewRect = new Rect(1 * xUnit, 4 * yUnit, 38 * xUnit, 55 * yUnit);
		scrollWindowRect = new Rect(1 * xUnit, 1 * yUnit, 33 * xUnit, 100 * yUnit);
		scrollPos = Vector2.zero;
	}

	void OnGUI()
	{
		GUI.Window(0, windowRect, WindowCallback, "Top 25");
	}

	void WindowCallback(int id)
	{
		scrollPos =  GUI.BeginScrollView(scrollViewRect, scrollPos, scrollWindowRect);
		GUI.EndScrollView();
	}
}
