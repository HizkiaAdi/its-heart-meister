using UnityEngine;
using System.Collections;

namespace SocialModule
{
	public class NPCController : MonoBehaviour 
	{
		Player player;
		Vector2 position;

		void Update () 
		{
			if(player != null)
			{
				position = this.transform.position;
				position.x += Time.deltaTime * player.Vector.x;
				position.y += Time.deltaTime * player.Vector.y;
				this.transform.position = position;
			}
		}

		public Player SetPlayerData
		{
			set
			{
				this.player = value;
			}
		}
	}
}