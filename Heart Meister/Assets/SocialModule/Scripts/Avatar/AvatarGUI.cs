using UnityEngine;
using System.Collections.Generic;

namespace SocialModule.Avatar
{
	public class AvatarGUI : MonoBehaviour 
	{
		public GUISkin skin;
        public AvatarScript avatarScript;
		
		float xUnit;
		float yUnit;
		float itemHeight;
		int selectionVal;
        int selectedIndex;
        int[] equipedIndex;
		Rect selectionRect;
		Rect windowRect;
		Rect scrollViewRect;
		Rect scrollWindowRect;
        Rect handlerRect;
		Vector2 scrollPos;
        Vector2 mousePos;
		string[] selectionStrings;
		PlayerAvatarData data;
		List<Avatars>[] avatars;
        Touch touch;
		
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

			data = GameObject.Find("DataContainer").GetComponent<PlayerAvatarData>();
 			avatars = new List<Avatars>[3];
			avatars[0] = data.ownedHeadAvatar;
			avatars[1] = data.ownedTopAvatar;
			avatars[2] = data.ownedBottomAvatar;
            equipedIndex = data.equipedIndex;
		}
		
		void OnGUI()
		{
			selectionVal = GUI.SelectionGrid(selectionRect,selectionVal,selectionStrings,3);
			GUI.Window(0,windowRect,WindowCallback,selectionStrings[selectionVal]);

            if (GUI.Button(new Rect(90 * xUnit, 90 * yUnit, 7 * xUnit, 7 * yUnit), "Home"))
            {
                Application.LoadLevel("Home");
            }
		}
		
		void WindowCallback(int id)
		{
            TouchHandler();

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
                int index = Mathf.CeilToInt ((mousePos.y + scrollPos.y - handlerRect.y) / (itemHeight * yUnit)) - 1;
                //Debug.Log(mousePos);
                //Debug.Log(scrollViewRect);
                Debug.Log(index);
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
                    /*
                     * To-do: Change data in webservice
                     */
                    avatars[selectionVal][selectedIndex].IsEquiped = 0;
                    avatars[selectionVal][selectedIndex].IsEquiped = 1;
                    SetSprite();
                }
            }
        }

        void SetSprite()
        {
            switch (selectionVal)
            {
                case 0:
                    avatarScript.setHeadSprite(avatars[selectionVal][selectedIndex].GetEditorSprite());
                    break;
                case 1:
                    avatarScript.setTopSprite(avatars[selectionVal][selectedIndex].GetEditorSprite());
                    break;
                case 2:
                    avatarScript.setBottomSprite(avatars[selectionVal][selectedIndex].GetEditorSprite());
                    break;
            }
        }
	}
}
