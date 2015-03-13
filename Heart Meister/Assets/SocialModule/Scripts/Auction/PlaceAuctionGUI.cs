using UnityEngine;
using System.Collections.Generic;
using SocialModule.Avatar;
using Webservice;

namespace SocialModule.Auction
{
	public class PlaceAuctionGUI : AuctionWindow
	{
		ShowModal showmodal;
		List<Avatars> avatarList;
		int selectedIndex;
		
		public PlaceAuctionGUI(Rect windowRect, GUIStyle style, ShowModal showmodal, PlayerData playerData)
			: base(windowRect, style)
		{
            this.playerData = playerData;
			scrollWindowRect = new Rect(2 * xUnit, 5 * yUnit, 96 * xUnit, 90 * yUnit);
			scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * 15 * yUnit);

			avatarList = new List<Avatars>();
            foreach(Avatars a in playerData.Avatars)
            {
                if (a.IsEquiped == 0)
                    avatarList.Add(a);
            }
			this.showmodal = showmodal;
			scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * avatarList.Count * yUnit);
			selectedIndex = -1;
		}
		
		public void Draw()
		{
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && scrollViewRect.Contains(Input.GetTouch(0).position))
			{
				scrollPos.y += Input.GetTouch(0).deltaPosition.y;
			}
			scrollPos = GUI.BeginScrollView(scrollWindowRect, scrollPos, scrollViewRect);
			for(int i = 0; i < avatarList.Count; i++)
			{
				GUI.Box(new Rect(1 * xUnit, ((itemHeight + 1) * i + 2) * yUnit, 95 * xUnit, itemHeight * yUnit), 
		        new GUIContent
		        (
					"  Avatar name : " + avatarList[i].AvatarName + 
					"\n  Gender : " + ((avatarList[i].Gender == 1) ? "cowok" : "cewek")
					, avatarList[i].GetIconTexture()
				), 
		        	boxStyle
		        );
				if(GUI.Button(new Rect(83 * xUnit, ((itemHeight + 1) * i + 6) * yUnit, 9 * xUnit, 6 * yUnit), "Auction"))
				{
					ButtonCallback(i);
				}
			}
			GUI.EndScrollView();
		}

		public Avatars SelectedItem
		{
			get { return (selectedIndex >= 0) ? avatarList[selectedIndex] : null; }
		}

		void ButtonCallback(int i)
		{
			selectedIndex = i;
			showmodal(true);
		}
	}
}