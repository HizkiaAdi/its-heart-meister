using UnityEngine;
using System.Collections;

namespace SocialModule.Auction
{
	public class AuctionWindow 
	{
		protected Rect windowRect;
		protected Rect scrollViewRect;
		protected Rect scrollWindowRect;
		protected Vector2 scrollPos;
		protected GUIStyle boxStyle;
		protected float xUnit;
		protected float yUnit;
		protected float itemHeight;
		
		public AuctionWindow(Rect windowRect, GUIStyle style)
		{
			this.windowRect = windowRect;
			this.boxStyle = style;
			xUnit = windowRect.width * 0.01f;
			yUnit = windowRect.height * 0.01f;
			scrollPos = Vector2.zero;
			itemHeight = 15f;
		}
	}
}