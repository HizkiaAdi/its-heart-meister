using UnityEngine;
using System.Collections.Generic;

namespace SocialModule.Auction
{
	public class AuctionListGUI : AuctionWindow
	{
		List<AuctionItem> auctionList;
		
		public AuctionListGUI(Rect windowRect, GUIStyle style)
			: base(windowRect, style)
		{
			scrollWindowRect = new Rect(2 * xUnit, 5 * yUnit, 96 * xUnit, 90 * yUnit);
			
			auctionList = new List<AuctionItem>();
			//string btnStr;
			for(int i = 0; i < 15; i++)
			{
				auctionList.Add(new AuctionItem(i, i * 100 + 100, "HW101", "bla " + i, i % 2, null, System.DateTime.Now.ToString(), 0));
				//btnStr = System.DateTime.Now.Subtract(auctionList[i].ExpireTime).TotalSeconds.ToString();
				//Debug.Log(btnStr);
			}
			scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * auctionList.Count * yUnit);
		}
		
		public void Draw()
		{
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && scrollViewRect.Contains(Input.GetTouch(0).position))
			{
				scrollPos.y += Input.GetTouch(0).deltaPosition.y;
			}
			scrollPos = GUI.BeginScrollView(scrollWindowRect, scrollPos, scrollViewRect);
			for(int i = 0; i < auctionList.Count; i++)
			{
				GUI.Box(new Rect(1 * xUnit, ((itemHeight + 1) * i + 2) * yUnit, 95 * xUnit, itemHeight * yUnit), 
				        new GUIContent
				        (
					"  Owner : " + auctionList[i].PlayerName + 
					"\n  Avatar name : " + auctionList[i].AvatarName + 
					"\n  Lowest Bid: " +
					auctionList[i].LowestBid, auctionList[i].AvatarIcon
					), 
				        boxStyle
				        );
				GUI.Label
					(
						new Rect(51 * xUnit, ((itemHeight + 1) * i + 5) * yUnit, 40 * xUnit, itemHeight * yUnit),
						"Gender: " + auctionList[i].Gender + "\nExpire: " + auctionList[i].ExpireTime
						);
				if(GUI.Button(new Rect(83 * xUnit, ((itemHeight + 1) * i + 6) * yUnit, 9 * xUnit, 6 * yUnit), "Claim"))
				{
					ButtonCallback(i);
				}
			}
			GUI.EndScrollView();
		}
		
		void ButtonCallback(int i)
		{
			
		}
	}
}