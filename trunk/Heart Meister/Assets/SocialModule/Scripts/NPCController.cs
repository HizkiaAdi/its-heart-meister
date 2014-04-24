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
				position.x = Time.deltaTime * player.Position.x;
				position.y = Time.deltaTime * player.Position.y;
				if(position.magnitude - player.Position.magnitude > 1)
					position = player.Position;
				this.transform.position = player.Position;
				Debug.Log(player.Vector);
			}
		}

		public Player SetPlayerData
		{
			set{this.player = value;}
		}
	}

}