using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public delegate void GUICallback(int id, Dictionary<string, string> callbackResult);

	public interface IDrawable
	{
		void Draw();
	}

	public abstract class GUIElement : IDrawable
	{
		protected int id;
		protected Rect rect;
		protected float xUnit;
		protected float yUnit;
		protected string text;
		protected GUICallback callback;
		protected Dictionary<string, string> callbackRes;
		protected bool enabled;
		protected bool visible;

		internal GUIElement(int id, float x, float y, float width, float height)
		{
			this.id = id;
			this.xUnit = Screen.width * 0.01f;
			this.yUnit = Screen.height * 0.01f;
			this.rect = new Rect(x * xUnit, y * yUnit, width * xUnit, height * yUnit);
			this.enabled = true;
			this.visible = true;
		}

		public bool Enabled
		{
			get{return this.enabled;} set{this.enabled = value;}
		}

		public bool Visible
		{
			get{return this.visible;} set{this.visible = value;}
		}

		abstract public void Draw();
	}
}