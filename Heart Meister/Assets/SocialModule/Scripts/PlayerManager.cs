using UnityEngine;
using System.Collections.Generic;
using MiniJSON;

namespace SocialModule
{
	public class PlayerManager : MonoBehaviour
	{
		Dictionary<string, Player> players;
		List<string> playersKey;
		
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

			resultList = (List<System.Object>)Json.Deserialize(jsonString);
			tempDict = (Dictionary<string, System.Object>)resultList[0];
			tempList = (List<System.Object>)tempDict["newplayer"];
			Debug.Log((tempList[0] as Dictionary<string, System.Object>)["id"]);
		}
		
		void Update()
		{
			foreach(string i in playersKey)
			{
				/*Vector2 position = p.Position;
				Vector2 vector = p.Vector;
				position.x = vector.x * Time.deltaTime;
				position.y = vector.y * Time.deltaTime;
				p.Position = position;
				p.Vector = vector;*/
			}
		}
		
		private void AddPlayer()
		{
			
		}
		
		private void RemovePlayer()
		{
			
		}
		
		void FixedUpdate()
		{
			
		}
	}

}