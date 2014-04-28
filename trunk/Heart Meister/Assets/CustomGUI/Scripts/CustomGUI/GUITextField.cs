using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUITextField : IGUIElement
	{
		private int id;
		private Rect rect;
		private float xUnit;
		private float yUnit;
		private string text;
		private GUICallback callback;
		private Dictionary<string, string> callbackRes;
		
		public GUITextField(int id, float x, float y, float width, float height, string defaultVal, GUICallback callback)
		{
			this.id = id;
			this.xUnit = Screen.width * 0.01f;
			this.yUnit = Screen.height * 0.01f;
			this.rect = new Rect(x * xUnit, y * yUnit, width * xUnit, height * yUnit);
			this.text = defaultVal;
			this.callback = callback;
			this.callbackRes = new Dictionary<string, string>();
			UnityEngine.GameObject.Find("GUIContainner").GetComponent<GUIContainner>().AddGUIElement(this);
		}
		
		public void Draw()
		{
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