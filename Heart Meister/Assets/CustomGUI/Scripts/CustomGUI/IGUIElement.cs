using UnityEngine;
using System.Collections.Generic;

namespace CustomGUI
{
	public delegate void GUICallback(int id, Dictionary<string, string> callbackResult);

	public interface IGUIElement
	{
		void Draw();
	}
}