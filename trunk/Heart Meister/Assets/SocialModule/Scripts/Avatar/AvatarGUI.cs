using UnityEngine;
using System.Collections.Generic;

namespace SocialModule.Avatar
{
	public class AvatarGUI : MonoBehaviour 
	{
		public GUISkin skin;
        //public AvatarScript avatarScript;
        public GameObject avatarAnchor;
		
		float xUnit;
		float yUnit;
		float itemHeight;
		int selectionVal;
        int selectedIndex;
        int headcount;
        int topcount;
        int bottomcount;
        int[] equipedIndex;
		Rect selectionRect;
		Rect windowRect;
		Rect scrollViewRect;
		Rect scrollWindowRect;
        Rect handlerRect;
		Vector2 scrollPos;
        Vector2 mousePos;
		string[] selectionStrings;
		PlayerData playerData;
		List<Avatars>[] avatars;
        GameObject baseAvatar;
        Transform headAnchor;
        Transform topAnchor;
        Transform bottomAnchor;
        GameObject headAvatar;
        GameObject topAvatar;
        GameObject bottomAvatar;
        Touch touch;
        PerformanceCounter pc;
		
		void Start()
		{
			xUnit = Screen.width * 0.01f;
			yUnit = Screen.height * 0.01f;
			
			selectionVal = 0;
			selectionRect = new Rect(5 * xUnit, 25 * yUnit, 50 * xUnit, 10 * yUnit);
			selectionStrings = new string[]{"Head","Top","Bottom"};
			
			windowRect = new Rect(6 * xUnit, 37 * yUnit, 50 * xUnit, 60 * yUnit);

			itemHeight = 10f;

			scrollPos = Vector2.zero;
			scrollViewRect = new Rect(2 * xUnit, 3 * yUnit, 47 * xUnit, 55 * yUnit);
			scrollWindowRect = new Rect(1 * xUnit, 1 * yUnit, 4 * xUnit, 100 * yUnit);
            handlerRect = new Rect(windowRect.x + scrollViewRect.x, windowRect.y + scrollViewRect.y, scrollViewRect.width, scrollViewRect.height);

            playerData = GameObject.Find("PlayerDataContainner").GetComponent<PlayerData>();
            if (playerData.IsMale == 1)
            {
                baseAvatar = (GameObject)Instantiate(Resources.Load<GameObject>("SocialPrefabs/AvatarMale"),avatarAnchor.transform.position, Quaternion.identity);
            }
            else
            {
                baseAvatar = (GameObject)Instantiate(Resources.Load<GameObject>("SocialPrefabs/AvatarFemale"),avatarAnchor.transform.position, Quaternion.identity);
            }
            baseAvatar.transform.parent = avatarAnchor.transform;
            baseAvatar.transform.position = new Vector3(baseAvatar.transform.position.x,
                baseAvatar.transform.position.y,
                baseAvatar.transform.position.z + 1);
            headAnchor = baseAvatar.transform.FindChild("Sprite/Hair");
            topAnchor = baseAvatar.transform.FindChild("Sprite/Top");
            bottomAnchor = baseAvatar.transform.FindChild("Sprite/Bottom");
 			avatars = new List<Avatars>[3];
            avatars[0] = new List<Avatars>();
            avatars[1] = new List<Avatars>();
            avatars[2] = new List<Avatars>();
            headcount = 0;
            topcount = 0;
            bottomcount = 0;
            equipedIndex = new int[3];
            foreach (Avatars i in playerData.Avatars)
            {
                if (i.InAuction == 1)
                    continue;
                if (i is HeadAvatar && i.Gender == playerData.IsMale)
                {
                    avatars[0].Add(i);
                    if (i.IsEquiped == 1)
                    {
                        equipedIndex[0] = headcount;
                        SetSprite(0);
                    }
                    headcount++;
                }
                else if (i is TopAvatar && i.Gender == playerData.IsMale)
                {
                    avatars[1].Add(i);
                    if (i.IsEquiped == 1)
                    {
                        equipedIndex[1] = topcount;
                        SetSprite(1);
                    }
                    topcount++;
                }
                else if (i is BottomAvatar && i.Gender == playerData.IsMale)
                {
                    avatars[2].Add(i);
                    if (i.IsEquiped == 1)
                    {
                        equipedIndex[2] = bottomcount;
                        SetSprite(2);
                    }
                    bottomcount++;
                }
            }
		}
		
		void OnGUI()
		{
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("Home");
            }
			selectionVal = GUI.SelectionGrid(selectionRect,selectionVal,selectionStrings,3);
			GUI.Window(0,windowRect,WindowCallback,selectionStrings[selectionVal]);
            TouchHandler();
            /*if (GUI.Button(new Rect(90 * xUnit, 90 * yUnit, 7 * xUnit, 7 * yUnit), "Home"))
            {
                Application.LoadLevel("Home");
            }*/
		}
		
		void WindowCallback(int id)
		{
            scrollPos = GUI.BeginScrollView(scrollViewRect, scrollPos, scrollWindowRect);

			for(int i = 0; i < avatars[selectionVal].Count; i++)
			{
				GUI.Box(new Rect(1 * xUnit, ((itemHeight + 1) * i + 2) * yUnit, 44 * xUnit, itemHeight * yUnit),
				new GUIContent
		        (
					" " + avatars[selectionVal][i].AvatarName,
					avatars[selectionVal][i].GetIconTexture()	
				),
					skin.box
	        	);
			}

			GUI.EndScrollView();
		}

        void TouchHandler()
        {
            mousePos = Input.mousePosition;
            mousePos.y = Screen.height - mousePos.y;

            if (Input.GetMouseButtonDown (0) && handlerRect.Contains (mousePos)) 
            {
                selectedIndex = Mathf.CeilToInt ((mousePos.y + scrollPos.y - handlerRect.y) / (itemHeight * yUnit)) - 1;
                if(selectedIndex != equipedIndex[selectionVal] && selectedIndex < avatars[selectionVal].Count)
                {
                    ChangeAvatar();
                }   
            }

            if (Input.touchCount > 0 && handlerRect.Contains(new Vector2(Input.GetTouch(0).position.x, Screen.height - Input.GetTouch(0).position.y)))
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    selectedIndex = Mathf.CeilToInt(((Screen.height - touch.position.y) + scrollPos.y - handlerRect.y) / (itemHeight * yUnit)) - 1;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    if (Mathf.Abs(touch.deltaPosition.y) > 1)
                    {
                        scrollPos.y += touch.deltaPosition.y;
                        selectedIndex = -1;
                    }
                }
                else if (touch.phase == TouchPhase.Canceled)
                {
                    selectedIndex = -1;
                }
                else if (touch.phase == TouchPhase.Ended && selectedIndex != -1)
                {
                    if (selectedIndex != equipedIndex[selectionVal] && selectedIndex < avatars[selectionVal].Count)
                    {
                        ChangeAvatar();
                    } 
                }
            }
        }

        void ChangeAvatar()
        {
            pc = new PerformanceCounter();
            pc.Start();
            avatars[selectionVal][equipedIndex[selectionVal]].IsEquiped = 0;
            avatars[selectionVal][selectedIndex].IsEquiped = 1;
            playerData.ChangeAvatar(avatars[selectionVal][selectedIndex], avatars[selectionVal][equipedIndex[selectionVal]]);
            equipedIndex[selectionVal] = selectedIndex;
            SetSprite(selectionVal);
            Debug.Log("Ganti avatar: " + pc.End() + "ms");
        }

        void SetSprite(int selection)
        {
            switch (selection)
            {
                case 0:
                    DestroyImmediate(headAvatar);
                    headAvatar = (GameObject)Instantiate(avatars[0][equipedIndex[0]].GetEditorSprite());
                    headAvatar.transform.position = headAnchor.position;
                    headAvatar.transform.parent = headAnchor;
                    break;
                case 1:
                    DestroyImmediate(topAvatar);
                    topAvatar = (GameObject)Instantiate(avatars[1][equipedIndex[1]].GetEditorSprite());
                    topAvatar.transform.position = topAnchor.position;
                    topAvatar.transform.parent = topAnchor;
                    break;
                case 2:
                    DestroyImmediate(bottomAvatar);
                    bottomAvatar = (GameObject)Instantiate(avatars[2][equipedIndex[2]].GetEditorSprite());
                    bottomAvatar.transform.position = bottomAnchor.position;
                    bottomAvatar.transform.parent = bottomAnchor;
                    break;
            }
        }
	}
}
