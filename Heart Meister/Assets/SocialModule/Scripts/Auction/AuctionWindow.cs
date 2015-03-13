using UnityEngine;
using System.Collections.Generic;
using Webservice;

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
        protected WebService webService;
        protected List<System.Object> resultList;
        protected Dictionary<string, System.Object> resultDict;
        protected PlayerData playerData;
        protected WebService ws;
		
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