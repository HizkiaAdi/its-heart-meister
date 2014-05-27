using UnityEngine;
using System.Collections.Generic;

namespace SocialModule.Auction
{
	public class BidListGUI : AuctionWindow
	{	
		List<BidItem> bidList;
		
		public BidListGUI(Rect windowRect, GUIStyle style)
			: base(windowRect, style)
		{
			scrollWindowRect = new Rect(2 * xUnit, 5 * yUnit, 96 * xUnit, 90 * yUnit);
			
			bidList = new List<BidItem>();
			for(int i = 0; i < 15; i++)
			{
				bidList.Add(new BidItem(i, "HW101", i * 100 + 100, i % 2, "bla " + i, null, 0));
			}
			scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * bidList.Count * yUnit);
		}
		
		public void Draw()
		{
			scrollPos = GUI.BeginScrollView(scrollWindowRect, scrollPos, scrollViewRect);
			for(int i = 0; i < bidList.Count; i++)
			{
				GUI.Box(new Rect(1 * xUnit, ((itemHeight + 1) * i + 2) * yUnit, 95 * xUnit, itemHeight * yUnit), 
		        new GUIContent
		        (
					"  Owner : " + bidList[i].AvatarOwner + 
					"\n  Avatar name : " + bidList[i].AvatarName + 
					"\n  Your Bid: " + bidList[i].BidAmmount, 
					bidList[i].AvatarIcon
				), 
			        boxStyle
		        );
				GUI.Label
				(
					new Rect(51 * xUnit, ((itemHeight + 1) * i + 5) * yUnit, 40 * xUnit, itemHeight * yUnit),
					"Gender: " + bidList[i].Gender + "\nStatus: " + bidList[i].Status 
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
