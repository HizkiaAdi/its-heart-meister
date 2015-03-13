using UnityEngine;
using System.Collections.Generic;

namespace SocialModule
{
	public class ChatGUI : MonoBehaviour
	{
		LinkedList<ChatItem> chats;
		LinkedListNode<ChatItem> chatItem;
		Rect chatWindowPos;
		Rect chatViewSize;
		Rect inputPos;
		Rect buttonPos;
        Rect boxRect;
		Vector2 chatScroll;
		string input;
		PlayerSocketListener psl;
        PlayerData playerData;
		
		public GUISkin guiSkin;
		
		void Start ()
		{
			chats = new LinkedList<ChatItem>();
			chatWindowPos = new Rect(10, Screen.height * 0.6f, Screen.width * 0.4f, (Screen.height * 0.9f) - (Screen.height * 0.6f));
			chatViewSize = new Rect(5, 0, chatWindowPos.width - 20, 0);
			inputPos = new Rect(10, Screen.height * 0.9f + 10, Screen.width * 0.3f, 30);
			buttonPos = new Rect(Screen.width * 0.3f + 15, inputPos.y, Screen.width * 0.1f, 30);
            boxRect = new Rect(10, Screen.height * 0.6f, Screen.width * 0.4f, (Screen.height * 0.9f) - (Screen.height * 0.6f));
			chatScroll = Vector2.zero;
			
			chatViewSize.height = chats.Count * 20;
			chatScroll.y = chatViewSize.height;
			input = string.Empty;
			
			psl = GameObject.Find("Player").GetComponent<PlayerSocketListener>();
            playerData = GameObject.Find("PlayerDataContainner").GetComponent<PlayerData>();
		}
		
		void OnGUI()
		{
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("Home");
            }
			GUI.skin = guiSkin;
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && 
			   chatViewSize.Contains(new Vector2(Input.GetTouch(0).position.x, Screen.height - Input.GetTouch(0).position.y)))
				chatScroll.y += Input.GetTouch(0).deltaPosition.y;

            GUI.Box(boxRect,"");
			chatScroll = GUI.BeginScrollView(chatWindowPos, chatScroll, chatViewSize);
			chatItem = chats.First;
			int i = 0;
			while(chatItem != null)
			{
				GUI.Label(new Rect(10, i * 20, chatViewSize.width * 0.2f - 10, 20), chatItem.Value.Name);
				GUI.Label(new Rect(chatViewSize.width * 0.2f, i * 20, chatViewSize.width * 0.8f, 20), chatItem.Value.Message);
				chatItem = chatItem.Next;
				i++;
			}
			GUI.EndScrollView();
			
			input = GUI.TextField(inputPos, input);
			if(GUI.Button(buttonPos, "Send"))
			{
				SendMessage();
			}
		}
		
		public void AddChatItem(string message)
		{
			ChatItem item;
			item = JSONToChatItem(message);
			chats.AddLast(new LinkedListNode<ChatItem>(item));
			chatViewSize.height += 20;
			chatScroll.y = chatViewSize.height;
		}

		private ChatItem JSONToChatItem(string jsonString)
		{
			Dictionary<string, System.Object> dict = MiniJSON.Json.Deserialize(jsonString) as Dictionary<string, System.Object>;
			return new ChatItem((string)dict["id"], (string)dict["name"], (string)dict["message"]);
		}

		private void SendMessage()
		{
            if (input.Length <= 0)
                return;
			psl.SendChatMessage(new ChatItem(playerData.ID, playerData.PlayerName, input));
			input = "";
		}
	}
}