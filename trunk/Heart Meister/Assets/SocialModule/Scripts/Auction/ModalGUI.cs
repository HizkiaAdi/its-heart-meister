using UnityEngine;
using System.Collections;
using SocialModule.Avatar;

namespace SocialModule.Auction
{
	public class ModalGUI
	{
		public AuctionItem auctionItem;
		public Avatars avatar;
		
		Rect rect;
		Rect cBoxRect;
		GUIContent[] contents;
		GUIStyle cBoxStyle;
		string bidAmmount;
		string statusString;
		float xUnit;
		float yUnit;
		int comboBoxSelection;
		ComboBox cBox;
		ShowModal showModal;
		
		internal ModalGUI(Rect rect, ShowModal showModal)
		{
			this.rect = rect;
			xUnit = rect.width * 0.01f;
			yUnit = rect.height * 0.01f;
			this.showModal = showModal;
			contents = new GUIContent[]{new GUIContent("24 Hour"), new GUIContent("2 Days"),new GUIContent("5 Days"),new GUIContent("7 Days")};
			bidAmmount = string.Empty;
			statusString = string.Empty;

			cBox = new ComboBox();
			cBoxRect = new Rect(30 * xUnit, 65 * yUnit, 25 * xUnit, 10 * yUnit);
			cBoxStyle = new GUIStyle();
			cBoxStyle.normal.textColor = Color.white; 
			cBoxStyle.onHover.background = cBoxStyle.hover.background = new Texture2D(2, 2);
			cBoxStyle.padding.left = cBoxStyle.padding.right = cBoxStyle.padding.top = cBoxStyle.padding.bottom = 4;
		}
		
		public void Draw(int i)
		{
			switch(i)
			{
			case 0:
				GUI.ModalWindow(0, rect, BidModal, "Bid");
				break;
			case 2:
				GUI.ModalWindow(0, rect, PlaceAuctionModal, "Place new auction");
				break;
			}
			
		}

		void PlaceAuctionModal(int id)
		{
			GUI.DrawTexture(new Rect(40 * xUnit, 8 * yUnit, 20 * xUnit, 20 * xUnit), avatar.GetIconTexture());
			GUI.Label(new Rect(3 * xUnit, 30 * xUnit, 80 * xUnit, 30 * yUnit), 
			          "Avatar name: \t" + avatar.AvatarName + 
			          "\n\nGender: \t\t\t" + avatar.AvatarName);
			GUI.Label(new Rect(3 * xUnit, 50 * yUnit, 25 * xUnit, 10 * yUnit), "Starting bid:");
			bidAmmount = GUI.TextField(new Rect(30 * xUnit, 50 * yUnit, 60 * xUnit, 10 * yUnit), bidAmmount);
			GUI.Label(new Rect(3 * xUnit, 67 * yUnit, 25 * xUnit, 10 * yUnit), "Duration:");
			comboBoxSelection = cBox.List(cBoxRect, contents[comboBoxSelection].text, contents, cBoxStyle);
			GUI.Label(new Rect(30 * xUnit, 78 * yUnit, 60 * xUnit, 10 * yUnit), statusString);
			if(GUI.Button(new Rect(3 * xUnit, 85 * yUnit, 30 * xUnit, 12 * yUnit), "Cancel"))
			{
				statusString = string.Empty;
				bidAmmount = string.Empty;
				showModal(false);
			}
			if(GUI.Button(new Rect(67 * xUnit, 85 * yUnit, 30 * xUnit, 12 * yUnit), "Confirm!"))
			{
				int res;
				if(!System.Int32.TryParse(bidAmmount, out res))
				{
					statusString = "Please insert number only!";
					return;
				}
				statusString = string.Empty;
				bidAmmount = string.Empty;
				showModal(false);
			}
		}

		void BidModal(int id)
		{
			GUI.DrawTexture(new Rect(40 * xUnit, 8 * yUnit, 20 * xUnit, 20 * xUnit), auctionItem.AvatarIcon);
			GUI.Label(new Rect(3 * xUnit, 30 * xUnit, 80 * xUnit, 30 * yUnit), 
			          "Avatar name: \t" + auctionItem.AvatarName + 
			          "\n\nOwner: \t\t\t\t" + auctionItem.PlayerName + 
			          "\n\nLowest bid: \t\t" + auctionItem.LowestBid);
			GUI.Label(new Rect(3 * xUnit, 60 * yUnit, 25 * xUnit, 10 * yUnit), "Your bid:");
			bidAmmount = GUI.TextField(new Rect(30 * xUnit, 60 * yUnit, 60 * xUnit, 10 * yUnit), bidAmmount);
			GUI.Label(new Rect(30 * xUnit, 71 * yUnit, 60 * xUnit, 10 * yUnit), statusString);
			if(GUI.Button(new Rect(3 * xUnit, 85 * yUnit, 30 * xUnit, 12 * yUnit), "Cancel"))
			{
				statusString = string.Empty;
				bidAmmount = string.Empty;
				showModal(false);
			}
			if(GUI.Button(new Rect(67 * xUnit, 85 * yUnit, 30 * xUnit, 12 * yUnit), "Bid!"))
			{
				int res;
				if(!System.Int32.TryParse(bidAmmount, out res))
				{
					statusString = "Please insert number only!";
					return;
				}
				if(res < auctionItem.LowestBid)
				{
					statusString = auctionItem.LowestBid + " is the lowest allowed bid!";
					return;
				}
				statusString = string.Empty;
				bidAmmount = string.Empty;
				showModal(false);
			}
		}
	}
}