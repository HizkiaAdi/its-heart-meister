using UnityEngine;
using System.Collections;

namespace SocialModule.Auction
{
	public delegate void ShowModal(bool value);

	public class AuctionGUI : MonoBehaviour
	{
		public GUISkin skin;
		
		float xUnit;
		float yUnit;
		Rect selectionRect;
		Rect titleRect;
		Rect windowRect;
		int selectionVal;
		string[] selectionStrings;
		bool showModal;
		
		ModalGUI modalGui;
		SearchGUI searchGui;
		AuctionListGUI auctionListGui;
		BidListGUI bidListGui;
		PlaceAuctionGUI placeAuctionGui;
		
		void Start()
		{
			xUnit = Screen.width * 0.01f;
			yUnit = Screen.height * 0.01f;
			
			selectionRect = new Rect(5 * xUnit, 10 * yUnit, 50 * xUnit, 5 * yUnit);
			selectionStrings = new string[]{"Search Item","My Auctions","Place Auction","My Bids"};
			selectionVal = 0;
			
			titleRect = new Rect(40 * xUnit, 3 * yUnit, 20 * xUnit, 5 * yUnit);
			windowRect = new Rect(5 * xUnit, 17 * yUnit, 90 * xUnit, 78 * yUnit);
			
			showModal = false;
			
			searchGui = new SearchGUI(windowRect, skin.box, ShowModal);
			auctionListGui = new AuctionListGUI(windowRect, skin.box);
			bidListGui = new BidListGUI(windowRect, skin.box);
			placeAuctionGui = new PlaceAuctionGUI(windowRect, skin.box, ShowModal);
			modalGui = new ModalGUI(new Rect(30 * xUnit, 20 * yUnit, 40 * xUnit, 60 * yUnit), ShowModal);
		}
		
		void OnGUI()
		{
			if(showModal)
				GUI.enabled = false;
			
			GUI.Label(titleRect, "Auction House", skin.label);
			selectionVal = GUI.SelectionGrid(selectionRect,selectionVal,selectionStrings,4);
			GUI.Window(0,windowRect,WindowCallback,selectionStrings[selectionVal]);
            if (GUI.Button(new Rect(90 * xUnit, 90 * yUnit, 7 * xUnit, 7 * yUnit), "Home"))
            {
                Application.LoadLevel("HomeSceneTemp");
            }
			
			if(showModal)
			{
				GUI.enabled = true;
				modalGui.Draw(selectionVal);
			}
		}
		
		void ShowModal(bool value)
		{
			showModal = value;
			
			switch(selectionVal)
			{
			case 0:
				modalGui.auctionItem = searchGui.SelectedItem;
				break;
			case 2:
				modalGui.avatar = placeAuctionGui.SelectedItem;
				break;
			}
		}
		
		void WindowCallback(int id)
		{
			switch(selectionVal)
			{
			case 0:
				searchGui.Draw();
				break;
			case 1:
				auctionListGui.Draw();
				break;
			case 2:
				placeAuctionGui.Draw();
				break;
			case 3:
				bidListGui.Draw();
				break;
			}
		}
	}
}
