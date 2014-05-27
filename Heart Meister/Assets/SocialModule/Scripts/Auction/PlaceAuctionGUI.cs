using UnityEngine;
using System.Collections.Generic;
using SocialModule.Avatar;

namespace SocialModule.Auction
{
	public class PlaceAuctionGUI : AuctionWindow
	{
		ShowModal showmodal;
		List<Avatars> avatarList;
		int selectedIndex;
		
		public PlaceAuctionGUI(Rect windowRect, GUIStyle style, ShowModal showmodal)
			: base(windowRect, style)
		{
			scrollWindowRect = new Rect(2 * xUnit, 5 * yUnit, 96 * xUnit, 90 * yUnit);
			scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * 15 * yUnit);

			avatarList = new List<Avatars>();
			for(int i = 0; i < 15; i++)
			{
				avatarList.Add(new TopAvatar(i, "bla " + i, null, null, Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"),i%2,0));
			}
			this.showmodal = showmodal;
			scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * avatarList.Count * yUnit);
		}
		
		public void Draw()
		{
			scrollPos = GUI.BeginScrollView(scrollWindowRect, scrollPos, scrollViewRect);
			for(int i = 0; i < avatarList.Count; i++)
			{
				GUI.Box(new Rect(1 * xUnit, ((itemHeight + 1) * i + 2) * yUnit, 95 * xUnit, itemHeight * yUnit), 
		        new GUIContent
		        (
					"  Avatar name : " + avatarList[i].AvatarName + 
					"\n  Gender : " + avatarList[i].Gender
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