using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUIButton : GUIElement
	{
		public GUIButton(int id, float x, float y, float width, float height, string text, GUICallback callback)
			: base(id, x, y, width, height)
		{
			this.text = text;
			this.callback = callback;
			UnityEngine.GameObject.Find("GUIContainner").GetComponent<GUIContainner>().AddGUIElement(this);
		}

		public override void Draw()
		{
			if(this.visible)
			{
				UnityEngine.GUI.enabled = this.enabled;
				if(UnityEngine.GUI.Button(this.rect, this.text))
					this.callback(this.id, null);
			}
		}
	}
}