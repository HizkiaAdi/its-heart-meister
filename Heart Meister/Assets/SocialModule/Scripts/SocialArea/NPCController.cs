using UnityEngine;
using System.Collections;

namespace SocialModule
{
	public class NPCController : MonoBehaviour 
	{
		Player player;
		Vector2 position;

		void Start () 
		{
			
		}
		
		
		void Update () 
		{
			if(player != null)
			{
				position = transform.position;
				position.x = Time.deltaTime * player.Vector.x;
				if(position.x - player.Position.x > 2)
					position = player.Position;
				this.transform.position = player.Position;
				//Debug.Log("Game object pos: " + this.transform.position);
			}
		}

		public Player SetPlayerData
		{
			set{this.player = value;}
		}
	}

}