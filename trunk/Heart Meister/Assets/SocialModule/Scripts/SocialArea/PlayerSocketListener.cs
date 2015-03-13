using UnityEngine;
using System.Collections.Generic;
using CustomGUI;

namespace SocialModule
{
	public class PlayerSocketListener : MonoBehaviour 
	{	
		private AndroidJavaClass unityPlayer;
		private AndroidJavaObject activity;
		private AndroidJavaObject playerClient;
		private AndroidJavaObject chatClient;

        /*private GUIButton button;
        private GUITextField textField;
        private GUITextField textField2;
        private GUILabel label;
        private GUILabel label2;
        private GUIButton backButton;*/
        PlayerData playerData;
		ChatGUI chatGUI;
		
		void Start ()
		{
            playerData = GameObject.Find("PlayerDataContainner").GetComponent<PlayerData>();
			chatGUI = GameObject.Find("ChatGUI").GetComponent<ChatGUI>();
            ConnectToServer();
		}

		void ConnectToServer()
		{
			string[] args = new string[2];
			string[] args2 = new string[2];
            args[0] = playerData.ServerAddress;
			args[1] = playerData.ServerPort.ToString();
			args2[0] = playerData.ServerAddress;
			args2[1] = (playerData.ServerPort + 1).ToString();
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
					playerData.ID = callbackRes["text"];
					break;
				/*case 2:
					host = callbackRes["text"];
					break;*/
				case 3:
					Application.LoadLevel("Home");
					break;
			}
		}

		public void SendChatMessage(ChatItem item)
		{
			if(chatClient != null)
			{
                Debug.Log(item.Message);
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
			dict["id"] = playerData.ID;
			return MiniJSON.Json.Serialize(dict);
		}
	}
}