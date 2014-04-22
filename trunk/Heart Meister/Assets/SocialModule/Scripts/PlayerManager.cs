﻿using UnityEngine;
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
			List<System.Object> tempList;
			Dictionary<string, System.Object> tempDict;
			Player player;

			//resultList = (List<System.Object>)Json.Deserialize(jsonString);

			/*
			//New Player
			tempDict = (Dictionary<string, System.Object>)resultList [0];
			tempList = (List<System.Object>)tempDict ["newplayer"];
			foreach (System.Object o in tempList)
			{
				tempDict = (Dictionary<string, System.Object>) o;
				AddPlayer();
			}
			*/

			//PlayerData
			tempDict = (Dictionary<string, System.Object>)Json.Deserialize(jsonString);
			tempList = (List<System.Object>)tempDict["data"];
			foreach (System.Object o in tempList)
			{
				tempDict = (Dictionary<string, System.Object>)o;
				if(players.ContainsKey(tempDict["id"].ToString()))
				{
					player = players[(string)tempDict["id"]];
					player.Vector = new Vector2(float.Parse(tempDict["vectorX"].ToString()), float.Parse(tempDict["vectorY"].ToString()));
					player.Position = new Vector2(float.Parse(tempDict["x"].ToString()), float.Parse(tempDict["y"].ToString()));
				}
				else
				{
					player = new Player(tempDict["id"].ToString(), tempDict["name"].ToString(),
					                    new Vector2(float.Parse(tempDict["vectorX"].ToString()), float.Parse(tempDict["vectorY"].ToString())),
					                    new Vector2(float.Parse(tempDict["x"].ToString()), float.Parse(tempDict["y"].ToString())),
					                    0, AddPlayer());
					players.Add((string)tempDict["id"], player);
					AddPlayer();
				}
			}
		}

		private GameObject AddPlayer()
		{
			Debug.Log("Creating game object");
			GameObject obj = (GameObject)Instantiate (playerObject, this.transform.position, Quaternion.identity);
			Debug.Log(obj);
			return obj;
		}
		
		private void RemovePlayer()
		{
			
		}
	}

}