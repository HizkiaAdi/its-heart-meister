using UnityEngine;
using System.Collections.Generic;
using Webservice;

namespace SocialModule.Auction
{
	public class SearchGUI : AuctionWindow
	{
		List<AuctionItem> auctionList;
		ComboBox cBox;
		Rect searchFieldRect;
		Rect searchButtonRect;
		Rect comboBoxRect;
		GUIContent[] contents;
		string[] comboBoxString;
		string searchText;
		int comboBoxSelection;
		int selectedIndex;
		GUIStyle cBoxStyle;
		ShowModal showmodal;
        PerformanceCounter pc;
		
		public SearchGUI(Rect windowRect, GUIStyle boxStyle, ShowModal showmodal, PlayerData playerData)
			: base(windowRect, boxStyle)
		{
            this.playerData = playerData;
			cBox = new ComboBox();
			
			auctionList = new List<AuctionItem>();
			
			searchFieldRect = new Rect(15 * xUnit, 5 * yUnit, 70 * xUnit, 6 * yUnit);
			searchText = string.Empty;
			
			comboBoxRect = new Rect(2 * xUnit, 5 * yUnit, 12 * xUnit, 6 * yUnit);
			comboBoxSelection = 0;
			contents = new GUIContent[]{new GUIContent("All"), new GUIContent("Head"),new GUIContent("Top"),new GUIContent("Bottom")};
			
			cBoxStyle = new GUIStyle();
			cBoxStyle.normal.textColor = Color.white; 
			cBoxStyle.onHover.background = cBoxStyle.hover.background = new Texture2D(2, 2);
			cBoxStyle.padding.left = cBoxStyle.padding.right = cBoxStyle.padding.top = cBoxStyle.padding.bottom = 4;
			
			searchButtonRect = new Rect(86 * xUnit, 5 * yUnit, 12 * xUnit, 6 * yUnit);
			
			scrollViewRect = new Rect(2 * xUnit, 12 * yUnit, 96 * xUnit, 86 * yUnit);
			scrollWindowRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * auctionList.Count * yUnit);
			selectedIndex = -1;
			
			this.showmodal = showmodal;
		}
		
		public void Draw()
		{
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && scrollViewRect.Contains(Input.GetTouch(0).position))
			{
				scrollPos.y += Input.GetTouch(0).deltaPosition.y;
			}
			searchText = GUI.TextField(searchFieldRect, searchText);
			if(GUI.Button(searchButtonRect, "Search"))
			{
                SearchAvatar();
				scrollWindowRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * auctionList.Count * yUnit);
			}
			
			scrollPos = GUI.BeginScrollView(scrollViewRect, scrollPos, scrollWindowRect);
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
				if(GUI.Button(new Rect(83 * xUnit, ((itemHeight + 1) * i + 6) * yUnit, 9 * xUnit, 6 * yUnit), "Bid"))
				{
					ButtonCallback(i);
				}
			}
			GUI.EndScrollView();
			comboBoxSelection = cBox.List(comboBoxRect, contents[comboBoxSelection].text, contents, cBoxStyle);
		}
		
		public AuctionItem SelectedItem
		{
			get { return (selectedIndex >= 0) ? auctionList[selectedIndex] : null; }
		}

        void SearchAvatar()
        {
            pc = new PerformanceCounter();
            pc.Start();
            ws = new WebService();
            auctionList.Clear();
            resultList = ws.GetAuctionList(comboBoxSelection - 1, searchText);
            foreach (System.Object o in resultList)
            {
                resultDict = o as Dictionary<string, System.Object>;
                auctionList.Add(new AuctionItem
                    (
                        int.Parse((string)resultDict["auctionid"]), int.Parse((string)resultDict["lowestbid"]),
                        int.Parse((string)resultDict["currentbid"]), (string)resultDict["playername"],
                        (string)resultDict["avatarname"], int.Parse((string)resultDict["gender"]),
                        Resources.Load<Texture2D>("Textures/" + (string)resultDict["iconsprite"]), (string)resultDict["expiretime"]
                    )
                );
            }
            Debug.Log("Search auction: " + pc.End() + "ms");
        }

		void ButtonCallback(int i)
		{
			selectedIndex = i;
			showmodal(true);
		}
	}

}
