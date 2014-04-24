using UnityEngine;
using System.Collections.Generic;
using MiniJSON;

namespace SocialModule
{
	public class PlayerManager : MonoBehaviour
	{
		Dictionary<string, Player> players;
		List<string> playersKey;

		public GameObject playerObject;
		
		void Start()
		{
			players = new Dictionary<string, Player> ();
			playersKey = new List<string> ();
		}

		
		public void NewMessage(string jsonString)
		{
			List<System.Object> resultList;
			Dictionary<string, System.Object> resultDict;
			Player player;

			resultDict = (Dictionary<string, System.Object>)Json.Deserialize(jsonString);
			resultList = (List<System.Object>)resultDict["data"];
			foreach (System.Object o in resultList)
			{
				resultDict = (Dictionary<string, System.Object>)o;
				if(players.ContainsKey(resultDict["id"].ToString()))
				{
					player = players[(string)resultDict["id"]];
					player.Vector = new Vector2(float.Parse(resultDict["vectorX"].ToString()), float.Parse(resultDict["vectorY"].ToString()));
					player.Position = new Vector2(float.Parse(resultDict["x"].ToString()), float.Parse(resultDict["y"].ToString()));
				}
				else
				{
					player = new Player(resultDict["id"].ToString(), resultDict["name"].ToString(),
					                    new Vector2(float.Parse(resultDict["vectorX"].ToString()), float.Parse(resultDict["vectorY"].ToString())),
					                    new Vector2(float.Parse(resultDict["x"].ToString()), float.Parse(resultDict["y"].ToString())),
					                    0);
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