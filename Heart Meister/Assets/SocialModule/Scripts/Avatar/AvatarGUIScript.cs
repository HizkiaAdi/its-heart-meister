using UnityEngine;
using System.Collections.Generic;

namespace SocialModule.Avatar
{
	public class AvatarGUIScript : MonoBehaviour
	{
		public GameObject viewGUI;
		public GameObject headSlot;
		public GameObject topSlot;
		public GameObject bottomSlot;
		public GameObject dataContainer;
		public GameObject avatar;
		public GameObject avatarIcon;

		private List<Avatars> ownedAvatar;
		private List<GameObject> avatarObjList;
		private PlayerAvatarData data;
		private Transform selectedItem;

		void Awake()
		{
			data = dataContainer.GetComponent<PlayerAvatarData>();
			avatarObjList = new List<GameObject>();
		}

		void Start()
		{
			ownedAvatar = data.ownedAvatar;
			GameObject obj;
			Vector3 pos = this.transform.position;

			pos.x -= 5.5f;
			pos.z = 6;
			for(int i = 0; i < ownedAvatar.Count; i++)
			{
				obj = Instantiate(avatarIcon, new Vector3((i%3)*2f + pos.x, pos.y - (i/3)*1.6f, pos.z), Quaternion.identity) as GameObject;
				obj.GetComponent<AvatarIconScript>().avatarData = ownedAvatar[i];
				obj.transform.parent = this.viewGUI.transform;
				avatarObjList.Add(obj);
			}

			headSlot.GetComponent<SpriteRenderer>().sprite = data.headAvatar.GetIconSprite();
			topSlot.GetComponent<SpriteRenderer>().sprite = data.topAvatar.GetIconSprite();
			bottomSlot.GetComponent<SpriteRenderer>().sprite = data.bottomAvatar.GetIconSprite();
		}

		void Update()
		{
			//Android

			if(Input.touchCount > 0 &&
			   Input.GetTouch(0).phase == TouchPhase.Began)
			{
				selectedItem = Raycast(Input.mousePosition);
				if(selectedItem != null && selectedItem.CompareTag("AvatarItem"))
				{
					AvatarIconScript iconScript = selectedItem.gameObject.GetComponent<AvatarIconScript>();
					if(iconScript.avatarData is HeadAvatar)
					{
						data.headAvatar = selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData;
						headSlot.GetComponent<SpriteRenderer>().sprite = data.headAvatar.GetIconSprite();
						avatar.GetComponent<AvatarScript>().setHeadSprite(
							selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData.GetEditorSprite()
							);
					}
					else if(iconScript.avatarData is TopAvatar)
					{
						data.topAvatar = selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData;
						topSlot.GetComponent<SpriteRenderer>().sprite = data.topAvatar.GetIconSprite();
						avatar.GetComponent<AvatarScript>().setTopSprite(
							selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData.GetEditorSprite()
							);
					}
					else if(iconScript.avatarData is BottomAvatar)
					{
						data.bottomAvatar = selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData;
						bottomSlot.GetComponent<SpriteRenderer>().sprite = data.bottomAvatar.GetIconSprite();
						avatar.GetComponent<AvatarScript>().setBottomSprite(
							selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData.GetEditorSprite()
							);
					}
				}
				else if(selectedItem != null)
				{
					if(selectedItem.CompareTag("HeadAvatar"))
					{
						data.headAvatar = null;
						avatar.GetComponent<AvatarScript>().setHeadSprite(null);
					}
					else if(selectedItem.CompareTag("TopAvatar"))
					{
						data.topAvatar = null;
						avatar.GetComponent<AvatarScript>().setTopSprite(null);
					}
					else if(selectedItem.CompareTag("BottomAvatar"))
					{
						data.bottomAvatar = null;
						avatar.GetComponent<AvatarScript>().setBottomSprite(null);
					}
				}
			}
			if(Input.touchCount > 0 &&
			   Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				selectedItem = null;
			}


			//Windows
			if(Input.GetMouseButtonDown(0))
			{
				selectedItem = Raycast(Input.mousePosition);
				if(selectedItem != null && selectedItem.CompareTag("AvatarItem"))
				{
					Debug.Log(0);
					AvatarIconScript iconScript = selectedItem.gameObject.GetComponent<AvatarIconScript>();
					if(iconScript.avatarData is HeadAvatar)
					{
						data.headAvatar = selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData;
						headSlot.GetComponent<SpriteRenderer>().sprite = data.headAvatar.GetIconSprite();
						avatar.GetComponent<AvatarScript>().setHeadSprite(
							selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData.GetEditorSprite()
							);
					}
					else if(iconScript.avatarData is TopAvatar)
					{
						data.topAvatar = selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData;
						topSlot.GetComponent<SpriteRenderer>().sprite = data.topAvatar.GetIconSprite();
						avatar.GetComponent<AvatarScript>().setTopSprite(
							selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData.GetEditorSprite()
							);
					}
					else if(iconScript.avatarData is BottomAvatar)
					{
						data.bottomAvatar = selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData;
						bottomSlot.GetComponent<SpriteRenderer>().sprite = data.bottomAvatar.GetIconSprite();
						avatar.GetComponent<AvatarScript>().setBottomSprite(
							selectedItem.gameObject.GetComponent<AvatarIconScript>().avatarData.GetEditorSprite()
							);
					}
				}
				else if(selectedItem != null)
				{
					if(selectedItem.CompareTag("HeadAvatar"))
					{
						data.headAvatar = null;
						avatar.GetComponent<AvatarScript>().setHeadSprite(null);
					}
					else if(selectedItem.CompareTag("TopAvatar"))
					{
						data.topAvatar = null;
						avatar.GetComponent<AvatarScript>().setTopSprite(null);
					}
					else if(selectedItem.CompareTag("BottomAvatar"))
					{
						data.bottomAvatar = null;
						avatar.GetComponent<AvatarScript>().setBottomSprite(null);
					}
				}
			}
			if(Input.GetMouseButtonUp(0))
			{
				selectedItem = null;
			}
		}

		Transform Raycast(Vector2 pos)
		{
			Ray ray;
			RaycastHit hit = new RaycastHit();
			ray = Camera.allCameras[1].ScreenPointToRay(pos);
			if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == 11)
			{
				return hit.transform;
			}
			return null;
		}

        void OnGUI()
        {
            if (GUI.Button(new Rect(Screen.width * 3 / 4, Screen.height * 7 / 8, Screen.width * 3 / 16, Screen.height * 3 / 32), "Home"))
            {
                Application.LoadLevel("Home");
            }
        }
	}
}