using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUITextField : GUIElement
	{		
		public GUITextField(int id, float x, float y, float width, float height, string defaultVal, GUICallback callback)
			: base(id, x, y, width, height)
		{
			this.text = defaultVal;
			this.callback = callback;
			this.callbackRes = new Dictionary<string, string>();
			UnityEngine.GameObject.Find("GUIContainner").GetComponent<GUIContainner>().AddGUIElement(this);
		}
		
		public override void Draw()
		{
			if(this.visible)
			{
				UnityEngine.GUI.enabled = this.enabled;
				this.text = UnityEngine.GUI.TextField(this.rect, this.text);
				if(callbackRes.ContainsKey("text"))
				{
					callbackRes["text"] = this.text;
				}
				else
					callbackRes.Add("text", this.text);
				this.callback(this.id, this.callbackRes);
			}
		}
	}

}