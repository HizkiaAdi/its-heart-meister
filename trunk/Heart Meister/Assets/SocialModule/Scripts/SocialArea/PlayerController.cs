using UnityEngine;
using System.Collections.Generic;
using Webservice;

namespace SocialModule
{
	public class PlayerController : MonoBehaviour
	{
		float widthUnit;
		float heightUnit;
		Rect leftControl;
		Rect rightControl;
        Transform headAnchor;
        Transform topAnchor;
        Transform bottomAnchor;
        GameObject head;
        GameObject top;
        GameObject bottom;
		Vector2 velocity;
        PlayerData playerData;
        WebService ws;
        List<System.Object> resultList;
        Dictionary<string, System.Object> resultDict;

        public Vector2 speed;
        public GameObject background;
		
		void Start ()
		{
            playerData = GameObject.Find("PlayerDataContainner").GetComponent<PlayerData>();
			widthUnit = Screen.width * 0.01f;
			heightUnit = Screen.height * 0.01f;
			leftControl = new Rect(0, 0, 10 * widthUnit, 100 * heightUnit);
			rightControl = new Rect(90 * widthUnit, 0, 10 * widthUnit, 100 * heightUnit);
            headAnchor = this.gameObject.transform.FindChild("Sprite/" + 
                ((playerData.IsMale == 1)?"AvatarMale":"AvatarFemale") + "/Sprite/Hair");
            topAnchor = this.gameObject.transform.FindChild("Sprite/" +
                ((playerData.IsMale == 1) ? "AvatarMale" : "AvatarFemale") + "/Sprite/Top");
            bottomAnchor = this.gameObject.transform.FindChild("Sprite/" +
                ((playerData.IsMale == 1) ? "AvatarMale" : "AvatarFemale") + "/Sprite/Bottom");
            ws = new WebService();
            resultList = ws.GetEquipedAvatars(int.Parse(playerData.ID));
            foreach (System.Object o in resultList)
            {
                resultDict = o as Dictionary<string, System.Object>;
                if (((string)resultDict["type"]).Equals("0"))
                {
                    head = (GameObject)Instantiate(Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]),
                        headAnchor.position, Quaternion.identity);
                    head.transform.parent = headAnchor;
                    head.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (((string)resultDict["type"]).Equals("1"))
                {
                    top = (GameObject)Instantiate(Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]),
                        topAnchor.position, Quaternion.identity);
                    top.transform.parent = topAnchor;
                    top.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    bottom = (GameObject)Instantiate(Resources.Load<GameObject>("SocialPrefabs/" + (string)resultDict["sprite"]),
                        bottomAnchor.position, Quaternion.identity);
                    bottom.transform.parent = bottomAnchor;
                    bottom.transform.localScale = new Vector3(1, 1, 1);
                }
            }
		}
		
		void Update ()
		{
			velocity = rigidbody2D.velocity;
			velocity.x = 0;
			#if UNITY_EDITOR
			if(Input.GetAxis("Horizontal") > 0)
				velocity.x = speed.x;
			else if(Input.GetAxis("Horizontal") < 0)
				velocity.x = -speed.x;
			#elif UNITY_ANDROID
			if(Input.touchCount > 0)
			{
				if(rightControl.Contains(Input.GetTouch(0).position))
					velocity.x = speed.x;
				else if(leftControl.Contains(Input.GetTouch(0).position))
					velocity.x = -speed.x;
			}
			#endif
			Camera.main.transform.position = new Vector3(this.transform.position.x, 
			                                             Camera.main.transform.position.y, 
			                                             Camera.main.transform.position.z);
		}
		
		void FixedUpdate()
		{
			rigidbody2D.velocity = velocity;
		}
	}
}