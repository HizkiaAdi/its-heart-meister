using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public class GUIContainner : MonoBehaviour
	{
		private List<IGUIElement> GUIElements;
		public GUISkin skin;

		void Awake()
		{
			GUIElements = new List<IGUIElement>();
		}

		void OnGUI()
		{
			GUI.skin = skin;
			foreach(IGUIElement i in GUIElements)
				i.Draw();
		}

		public void AddGUIElement(IGUIElement element)
		{
			GUIElements.Add(element);
		}

		public void RemoveGUIELement(IGUIElement element)
		{
			GUIElements.Remove(element);
		}

		public void RemoveAllGUIELements()
		{
			GUIElements.Clear();
		}
	}
}