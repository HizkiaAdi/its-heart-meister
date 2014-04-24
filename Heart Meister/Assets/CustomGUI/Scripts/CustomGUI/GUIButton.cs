using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUIButton : IGUIElement
	{
		private int id;
		private Rect rect;
		private float xUnit;
		private float yUnit;
		private string text;
		private GUICallback callback;

		public GUIButton(int id, float x, float y, float width, float height, string text, GUICallback callback)
		{
			this.id = id;
			this.xUnit = Screen.width * 0.01f;
			this.yUnit = Screen.height * 0.01f;
			this.rect = new Rect(x * xUnit, y * yUnit, width * xUnit, height * yUnit);
			this.text = text;
			this.callback = callback;
			UnityEngine.GameObject.Find("GUIContainer").GetComponent<GUIContainner>().AddGUIElement(this);
		}

		public void Draw()
		{
			if(UnityEngine.GUI.Button(this.rect, this.text))
				this.callback(this.id, null);
		}
	}
}