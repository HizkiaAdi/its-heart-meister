using UnityEngine;
using System.Collections.Generic;

namespace SocialModule
{
	public class PlayerManager : MonoBehaviour
	{
		private List<GameObject> players;
		private List<Player> playerDatas;
		
		void Start()
		{
			this.players = new List<GameObject>();
			this.playerDatas = new List<Player>();
		}
		
		public void NewMessage(string jsonString)
		{
			Debug.Log("message from server: " + jsonString);
		}
		
		void Update()
		{
			foreach(Player p in playerDatas)
			{
				Vector2 position = p.Position;
				Vector2 vector = p.Vector;
				position.x = vector.x * Time.deltaTime;
				position.y = vector.y * Time.deltaTime;
				p.Position = position;
				p.Vector = vector;
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