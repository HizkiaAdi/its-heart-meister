using UnityEngine;
using System.Collections.Generic;
using Webservice;

namespace SocialModule.Auction
{
	public class AuctionListGUI : AuctionWindow
	{
		List<AuctionItem> auctionList;
        PerformanceCounter pc;
		
		public AuctionListGUI(Rect windowRect, GUIStyle style, PlayerData playerData)
			: base(windowRect, style)
		{
            this.playerData = playerData;
            auctionList = new List<AuctionItem>();
			scrollWindowRect = new Rect(2 * xUnit, 5 * yUnit, 96 * xUnit, 90 * yUnit);
            RetrieveData();
			scrollViewRect = new Rect(1 * xUnit, 1 * yUnit, 92 * xUnit, (itemHeight + 1) * auctionList.Count * yUnit);
		}

        void RetrieveData()
        {
            pc = new PerformanceCounter();
            pc.Start();
            auctionList = new List<AuctionItem>();
            ws = new WebService();
            resultList = ws.GetOwnAuction(int.Parse(playerData.ID));
            foreach (System.Object o in resultList)
            {
                resultDict = o as Dictionary<string, System.Object>;
                auctionList.Add(new AuctionItem(
                    int.Parse((string)resultDict["auctionid"]),int.Parse((string)resultDict["lowestbid"]),
                    int.Parse((string)resultDict["currentbid"]),(string)resultDict["playername"],
                    (string)resultDict["avatarname"],int.Parse((string)resultDict["gender"]),
                    Resources.Load<Texture2D>("Textures/" + (string)resultDict["iconsprite"]), (string)resultDict["expiretime"]
                    ));
            }
            Debug.Log("Retrieve auction list: " + pc.End() + "ms");
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
					"\n  Current Bid: " +
					auctionList[i].CurrentBid, auctionList[i].AvatarIcon
					), 
				        boxStyle
				    );
				GUI.Label
					(
						new Rect(51 * xUnit, ((itemHeight + 1) * i + 5) * yUnit, 40 * xUnit, itemHeight * yUnit),
						"Gender: " + auctionList[i].Gender + "\nExpire: " + auctionList[i].ExpireTime
					);
                if (System.DateTime.Compare(System.DateTime.Now, auctionList[i].ExpireTime) < 0)
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
            pc = new PerformanceCounter();
            pc.Start();
            ws = new WebService();
            ws.ClaimAuction(auctionList[i].AuctionId);
            playerData.Money = playerData.Money + auctionList[i].CurrentBid;
            auctionList.RemoveAt(i);
            Debug.Log("Claim auction: " + pc.End() + "ms");
		}
	}
}