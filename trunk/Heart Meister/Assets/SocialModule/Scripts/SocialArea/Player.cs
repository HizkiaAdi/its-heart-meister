using UnityEngine;

namespace SocialModule
{
	public class Player
	{
		private string id;
		private string name;
		private Vector2 vector;
		private Vector2 position;
		private int state;
		private GameObject gameObject;
		
		public Player()
		{
			this.id = "placeholder";
			this.name = "name";
			this.vector = Vector2.zero;
			this.position = new Vector2(-0, -100);
			this.gameObject = null;
		}
		
		public Player(string id, string name, Vector2 vector, Vector2 position, int state)
		{
			this.id = id;
			this.name = name;
			this.vector = vector;
			this.position = position;
			this.state = state;
		}
		
		public string ID {get{return this.id;} set{this.id = value;}}
		
		public string Name {get{return this.name;} set{this.name = value;}}
		
		public Vector2 Vector {get{return this.vector;} set{this.vector = value;}}
		
		public Vector2 Position {get{return this.position;} set{this.position = value;}}
		
		public int State {get{return this.state;} set{this.state = value;}}

		public GameObject GameObject {get{return this.gameObject;}set{this.gameObject = value;}}
	}
//}