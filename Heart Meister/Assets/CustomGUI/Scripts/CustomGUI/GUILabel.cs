using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUILabel : IGUIElement
	{
		private Rect rect;
		private float xUnit;
		private float yUnit;
		private string text;
		
		public GUILabel(float x, float y, float width, float height, string text)
		{
			this.xUnit = Screen.width * 0.01f;
			this.yUnit = Screen.height * 0.01f;
			this.rect = new Rect(x * xUnit, y * yUnit, width * xUnit, height * yUnit);
			this.text = text;
			UnityEngine.GameObject.Find("GUIContainner").GetComponent<GUIContainner>().AddGUIElement(this);
		}

		public void Draw()
		{
			UnityEngine.GUI.Label(rect, this.text);
		}

		public string Text
		{
			get {return this.text;} set {this.text = value;}
		}
	}
}