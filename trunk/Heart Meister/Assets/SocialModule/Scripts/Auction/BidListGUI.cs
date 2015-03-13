using UnityEngine;
using System.Collections.Generic;
using Webservice;

namespace SocialModule.Auction
{
	public class BidListGUI : AuctionWindow
	{	
		List<BidItem> bidList;
		
		public BidListGUI(Rect windowRect, GUIStyle style, ShowModal showmodal,  PlayerData playerData)
			: base(windowRect, style)
		{
            this.playerData = playerData;
			scrollWindowRect = new Rect(2 * xUnit, 5 * yUnit, 96 * xUnit, 90 * yUnit);
            RetrieveBid();
		}

        void RetrieveBid()
        {
            bidList = new List<BidItem>();
            ws = new WebService();
            resultList = ws.GetOwnBid(int.Parse(playerData.ID));
            foreach (System.Object o in resultList)
            {
                resultDict = o as Dictionary<string, System.Object>;
                bidList.Add(
                    new BidItem(int.Parse((string)resultDict["bidid"]),(string)resultDict["avatarowner"],
                        int.Parse((string)resultDict["bidammount"]), int.Parse((string)resultDict["gender"]),
                        (string)resultDict["avatarname"],Resources.Load<Texture2D>("Textures/" + (string)resultDict["iconsprite"]),
                        int.Parse((string)resultDict["status"]),(string)resultDict["expiretime"])
                );
            }
            scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * bidList.Count * yUnit);
        }
		
		public void Draw()
		{
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && scrollViewRect.Contains(Input.GetTouch(0).position))
			{
				scrollPos.y += Input.GetTouch(0).deltaPosition.y;
			}
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
					"Gender: " + bidList[i].Gender + "\nStatus: " + ((bidList[i].Status == 0)?"Win":"Lose")
				);
                if (System.DateTime.Compare(System.DateTime.Now, bidList[i].ExpireTime) < 0)
                    GUI.enabled = false;
				if(GUI.Button(new Rect(83 * xUnit, ((itemHeight + 1) * i + 6) * yUnit, 9 * xUnit, 6 * yUnit), "Claim"))
				{
					ButtonCallback(i);
				}
                GUI.enabled = true;
			}
			GUI.EndScrollView();
		}
		
		void ButtonCallback(int i)
        {
            ws = new WebService();
            ws.ClaimBid(bidList[i].BidId);
            bidList.RemoveAt(i);
            playerData.RetrievePlayerData();
        }
	}
}
