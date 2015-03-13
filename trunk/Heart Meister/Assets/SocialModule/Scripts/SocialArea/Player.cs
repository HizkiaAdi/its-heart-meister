using UnityEngine;
using System.Collections.Generic;
using Webservice;

namespace SocialModule
{
	public class Player
	{
		private string id;
		private string name;
        private int gender;
        private GameObject head;
        private GameObject top;
        private GameObject bottom;
		private Vector2 vector;
		private Vector2 position;
		private int state;
		private GameObject gameObject;
        private WebService ws;
        private List<System.Object> resultList;
        private Dictionary<string, System.Object> resultDict;
		
		public Player()
		{
			this.id = "placeholder";
			this.name = "name";
			this.vector = Vector2.zero;
			this.position = new Vector2(0, 0);
			this.gameObject = null;
		}

		public Player(string id, Vector2 vector, Vector2 position)
		{
            Debug.Log("Creating new Player");
			this.id = id;
			this.vector = vector;
			this.position = position;

            ws = new WebService();
            resultDict = ws.GetPlayerData(int.Parse(this.id));
            this.name = (string)resultDict["playername"];
            this.gender = 1;

            ws = new WebService();
            resultList = ws.GetEquipedAvatars(int.Parse(this.id));
            foreach (System.Object o in resultList)
            {
                resultDict = o as Dictionary<string, System.Object>;
                if (((string)resultDict["type"]).Equals("0"))
                {
                    head = Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]);
                }
                else if (((string)resultDict["type"]).Equals("1"))
                {
                    top = Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]);
                }
                else
                {
                    bottom = Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]);
                }
            }
		}

		public void PositionUpdate(Vector2 newPos, Vector2 newVector)
		{
			this.position = newPos;
			this.vector = newVector;
			if(Mathf.Abs(gameObject.transform.position.magnitude - newPos.magnitude) > 2)
			{
				gameObject.transform.position = newPos;
			}
		}
		
		public string ID {get{return this.id;} set{this.id = value;}}
		
		public string Name {get{return this.name;} set{this.name = value;}}

        public int Gender { get { return this.gender; } set { this.gender = value; } }
		
		public Vector2 Vector {get{return this.vector;} set{this.vector = value;}}
		
		public Vector2 Position {get{return this.position;} set{this.position = value;}}
		
		public int State {get{return this.state;} set{this.state = value;}}

		public GameObject GameObject {get{return this.gameObject;}set{this.gameObject = value;}}

        public GameObject Head { get { return this.head; } }

        public GameObject Top { get { return this.top; } }

        public GameObject Bottom { get { return this.bottom; } }
	}
}