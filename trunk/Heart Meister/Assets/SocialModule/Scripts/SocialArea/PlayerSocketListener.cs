using UnityEngine;
using System.Collections.Generic;
using CustomGUI;

namespace SocialModule
{
	public class PlayerSocketListener : MonoBehaviour 
	{
		public string host;
		public int port;
		public int chatPort;
		
		private AndroidJavaClass unityPlayer;
		private AndroidJavaObject activity;
		private AndroidJavaObject playerClient;
		private AndroidJavaObject chatClient;

		private GUIButton button;
		private GUITextField textField;
		private GUITextField textField2;
		private GUILabel label;
		private GUILabel label2;
		private GUIButton backButton;
        PlayerData playerDataContainer;
		ChatGUI chatGUI;
		
		void Start ()
		{
			label = new GUILabel(55, 5, 14, 8, "ID");
			textField = new GUITextField(1, 70, 5, 25, 8, "5110100082", CallbackMethod);
			label2 = new GUILabel(55, 15, 14, 8, "Server IP");
			textField2 = new GUITextField(2, 70, 15, 25, 8, host, CallbackMethod);
			button = new GUIButton(0, 70, 25, 25, 8, "Connect", CallbackMethod);
			backButton = new GUIButton(3, 80, 90, 18, 8, "Back", CallbackMethod);
            playerDataContainer = GameObject.Find("PlayerDataContainer").GetComponent<PlayerData>();
			chatGUI = GameObject.Find("ChatGUI").GetComponent<ChatGUI>();
		}

		void ConnectToServer()
		{
			string[] args = new string[2];
			string[] args2 = new string[2];
			args[0] = host;
			args[1] = port.ToString();
			args2[0] = host;
			args2[1] = chatPort.ToString();
			unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			activity.Call("runOnUiThread", new AndroidJavaRunnable(()=>
			{
				playerClient = new AndroidJavaObject("com.pejuangcinta.clientplugin.PlayerClient", args);
				chatClient = new AndroidJavaObject("com.pejuangcinta.clientplugin.ChatClient", args2);
			}
			));

			InvokeRepeating("SendPlayerData", 0, 0.5f);
		}

		public void CallbackMethod(int id, Dictionary<string, string> callbackRes)
		{
			switch(id)
			{
				case 0:
					ConnectToServer();
					break;
				case 1:
					playerDataContainer.ID = callbackRes["text"];
					break;
				case 2:
					host = callbackRes["text"];
					break;
				case 3:
					Application.LoadLevel("Home");
					break;
			}
		}

		public void SendChatMessage(ChatItem item)
		{
			if(chatClient != null)
			{
				bool success = false;
				string jsonString = ChatItemToJSON(item);
				success = chatClient.Call<bool>("sendMessage", jsonString);
				if (success)
					Debug.Log("Successfully sent message.");
				else
					Debug.Log("Failed to send message.");
			}
		}

		void SendPlayerData ()
		{
			if(playerClient != null)
			{
				bool success = false;
				string jsonString = PlayerDataToJSON(transform);
				success = playerClient.Call<bool>("sendMessage", jsonString);
				if (success)
					Debug.Log("Successfully sent message.");
				else
					Debug.Log("Failed to send message.");
			}
		}

		public void ReceivedMessage(string message)
		{
			Debug.Log("Received message from server: " + message);
			GameObject.Find("PlayerManager").GetComponent<PlayerManager>().NewMessage(message);
		}

		public void ReceivedChatMessage(string message)
		{
			chatGUI.AddChatItem(message);
		}

		private string ChatItemToJSON(ChatItem item)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			dict["id"] = item.ID;
			dict["name"] = item.Name;
			dict["message"] = item.Message;
			return MiniJSON.Json.Serialize(dict);
		}

		private string PlayerDataToJSON(Transform transform)
		{
			Dictionary<string,string> dict = new Dictionary<string, string>();
			dict["x"] = transform.position.x.ToString();
			dict["y"] = transform.position.y.ToString();
			dict["id"] = playerDataContainer.ID;
			return MiniJSON.Json.Serialize(dict);
		}
	}
}