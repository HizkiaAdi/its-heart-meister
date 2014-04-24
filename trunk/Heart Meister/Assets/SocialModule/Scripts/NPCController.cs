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
				this.transform.position = player.Position;
			}
		}

		public Player SetPlayerData
		{
			set{this.player = value;}
		}
	}

}