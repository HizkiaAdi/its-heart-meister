using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUILabel : GUIElement
	{		
		public GUILabel(float x, float y, float width, float height, string text)
			: base(-1, x, y, width, height)
		{
			this.text = text;
			UnityEngine.GameObject.Find("GUIContainner").GetComponent<GUIContainner>().AddGUIElement(this);
		}

		public override void Draw()
		{
			if(this.visible)
			{
				UnityEngine.GUI.enabled = this.enabled;
				UnityEngine.GUI.Label(rect, this.text);
			}
		}

		public string Text
		{
			get {return this.text;} set {this.text = value;}
		}
	}
}