using UnityEngine;
using System.Collections.Generic;
using MiniJSON;

namespace SocialModule
{
	public class PlayerManager : MonoBehaviour
	{
		Dictionary<string, Player> players;
		List<string> playersKey;
		PlayerData playerDataContainer;

		public GameObject playerObject;
		
		void Start()
		{
			players = new Dictionary<string, Player> ();
			playersKey = new List<string> ();
			playerDataContainer = GameObject.Find("PlayerDataContainer").GetComponent<PlayerData>();
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
					//player.Vector = new Vector2(float.Parse((string)resultDict["vectorX"]), float.Parse((string)resultDict["vectorY"]));
					//player.Position = new Vector2(float.Parse((string)resultDict["x"]), float.Parse((string)resultDict["y"]));
				}
				else if(!resultDict["id"].ToString().Equals(playerDataContainer.ID))
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
			Debug.Log("Creating game object");
			GameObject obj = (GameObject)Instantiate (playerObject, this.transform.position, Quaternion.identity);
			player.GameObject = obj;
			obj.GetComponent<NPCController>().SetPlayerData = player;
		}
		
		private void RemovePlayer()
		{
			
		}
	}

}