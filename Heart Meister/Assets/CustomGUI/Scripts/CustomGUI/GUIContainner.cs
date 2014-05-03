using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUIContainner : MonoBehaviour
	{
		private List<IDrawable> GUIElements;
		public GUISkin skin;

		void Awake()
		{
			GUIElements = new List<IDrawable>();
		}

		void OnGUI()
		{
			GUI.skin = skin;
			foreach(GUIElement i in GUIElements)
				i.Draw();
		}

		public void AddGUIElement(IDrawable element)
		{
			GUIElements.Add(element);
		}

		/*public void RemoveGUIELement(IGUIElement element)
		{
			GUIElements.Remove(element);
		}

		public void RemoveAllGUIELements()
		{
			GUIElements.Clear();
		}*/
	}
}