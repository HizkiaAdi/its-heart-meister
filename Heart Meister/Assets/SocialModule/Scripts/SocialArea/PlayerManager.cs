using UnityEngine;
using System.Collections.Generic;
using MiniJSON;

namespace SocialModule
{
	public class PlayerManager : MonoBehaviour
	{
		Dictionary<string, Player> players;
		List<string> playersKey;
		PlayerData playerData;

		public GameObject npcMale;
        public GameObject npcFemale;
        public GameObject malePlayer;
        public GameObject femalePlayer;
		
		void Awake()
		{
			players = new Dictionary<string, Player> ();
			playersKey = new List<string> ();
			playerData = GameObject.Find("PlayerDataContainner").GetComponent<PlayerData>();
            if (playerData.IsMale == 1)
            {
                GameObject o = (GameObject)GameObject.Instantiate(malePlayer);
                o.transform.name = "Player";
            }
            else
            {
                GameObject o = (GameObject)GameObject.Instantiate(femalePlayer);
                o.transform.name = "Player";
            }
		}

		
		public void NewMessage(string jsonString)
		{
			List<System.Object> resultList;
			Dictionary<string, System.Object> resultDict;
			Player player;

			Debug.Log("Parsing jsonstring: " + jsonString);
			resultDict = (Dictionary<string, System.Object>)Json.Deserialize(jsonString);
			resultList = (List<System.Object>)resultDict["data"];
			foreach (System.Object o in resultList)
			{
				resultDict = (Dictionary<string, System.Object>)o;
				if(players.ContainsKey(resultDict["id"].ToString()))
				{
					player = players[(string)resultDict["id"]];
					player.PositionUpdate(new Vector2(float.Parse((string)resultDict["x"]), float.Parse((string)resultDict["y"])),
					                      new Vector2(float.Parse((string)resultDict["vectorX"]), float.Parse((string)resultDict["vectorY"])));
				}
				else if(!resultDict["id"].ToString().Equals(playerData.ID))
				{
					player = new Player((string)resultDict["id"],
					                    new Vector2(float.Parse((string)resultDict["vectorX"]), float.Parse((string)resultDict["vectorY"])),
					                    new Vector2(float.Parse((string)resultDict["x"]), float.Parse((string)resultDict["y"])));
					players.Add((string)resultDict["id"], player);
					AddPlayer(player);
				}
			}
		}

		private void AddPlayer(Player player)
        {
            Debug.Log("Creating new player object");

            GameObject obj;
            GameObject obj2;

            if (player.Gender == 1)
            {
                obj = (GameObject)Instantiate(npcMale, new Vector3(0,0,5), Quaternion.identity);
            }
            else
            {
                obj = (GameObject)Instantiate(npcMale, new Vector3(0, 0, 5), Quaternion.identity);
                //obj = (GameObject)Instantiate(npcFemale, new Vector3(0,0,5), Quaternion.identity);
            }

            Debug.Log("PlayerObject => ", obj);

            player.GameObject = obj;
            obj.GetComponent<NPCController>().SetPlayerData = player;
            obj.transform.FindChild("Text").GetComponent<TextMesh>().text = player.Name;
            Vector3 pos = obj.transform.position;
            Debug.Log("Base pos: " + pos);

            obj2 = (GameObject)Instantiate(player.Head, new Vector3(pos.x, pos.y, pos.z - 1), Quaternion.identity);
            obj2.transform.parent = obj.transform.FindChild("Sprite/" +
                ((player.Gender == 1) ? "AvatarMale" : "AvatarFemale") + "/Sprite/Head");
            obj2.transform.localScale = new Vector3(1,1,1);
            Debug.Log("Head pos: " + obj2.transform.position);

            obj2 = (GameObject)Instantiate(player.Top, new Vector3(pos.x, pos.y, pos.z - 1), Quaternion.identity);
            obj2.transform.parent = obj.transform.FindChild("Sprite/" +
               ((player.Gender == 1) ? "AvatarMale" : "AvatarFemale") + "/Sprite/Top");
            obj2.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Top pos: " + obj2.transform.position);

            obj2 = (GameObject)Instantiate(player.Bottom, new Vector3(pos.x, pos.y, pos.z - 1), Quaternion.identity);
            obj2.transform.parent = obj.transform.FindChild("Sprite/" +
               ((player.Gender == 1) ? "AvatarMale" : "AvatarFemale") + "/Sprite/Bottom");
            obj2.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Bottom pos: " + obj2.transform.position);
        }
		
		private void RemovePlayer()
		{
			
		}
	}

}