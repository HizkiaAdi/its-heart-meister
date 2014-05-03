using UnityEngine;
using System.Collections.Generic;
using CustomGUI;

namespace SocialModule
{
	public class PlayerSocketListener : MonoBehaviour 
	{
		public string host;
		public int port;
		
		private AndroidJavaClass _unityPlayer;
		private AndroidJavaObject _activity;
		private AndroidJavaObject _playerClient;

		private GUIButton button;
		private GUITextField textField;
		private GUITextField textField2;
		private GUILabel label;
		private GUILabel label2;
		private GUIButton backButton;
        PlayerData playerDataContainer;
		
		void Start ()
		{
			label = new GUILabel(55, 5, 14, 8, "ID");
			textField = new GUITextField(1, 70, 5, 25, 8, "5110100082", CallbackMethod);
			label2 = new GUILabel(55, 15, 14, 8, "Server IP");
			textField2 = new GUITextField(2, 70, 15, 25, 8, host, CallbackMethod);
			button = new GUIButton(0, 70, 25, 25, 8, "Connect", CallbackMethod);
			backButton = new GUIButton(3, 80, 90, 18, 8, "Back", CallbackMethod);
            playerDataContainer = GameObject.Find("PlayerDataContainer").GetComponent<PlayerData>();
		}

		void ConnectToServer()
		{
			string[] args = new string[2];
			args[0] = host;
			args[1] = port.ToString();

			_unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			_activity = _unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			/*_activity.Call("runOnUiThread", new AndroidJavaRunnable(()=>
        	{
				_playerClient = new AndroidJavaObject("com.pejuangcinta.player.PlayerClient", args);
			}
			));*/
			_activity.Call("runOnUiThread", new AndroidJavaRunnable(()=>
			                                                        {
				_playerClient = new AndroidJavaObject("com.pejuangcinta.clientplugin.PlayerClient", args);
			}
			));
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

		public void ReceivedMessage(string message)
		{
			//Debug.Log("Received message from server: " + message);
			GameObject.Find("PlayerManager").GetComponent<PlayerManager>().NewMessage(message);
		}
		
		void FixedUpdate ()
		{
			if(_playerClient != null)
			{
				bool success = false;
				string jsonString = PlayerDataToJSON(transform);
				success = _playerClient.Call<bool>("sendMessage", jsonString);
				if (success)
					Debug.Log("Successfully sent message.");
				else
					Debug.Log("Failed to send message.");
			}
		}
		
		private string PlayerDataToJSON(Transform transform)
		{
			Dictionary<string,string> dict = new Dictionary<string, string>();
			dict["x"] = transform.position.x.ToString();
			dict["y"] = transform.position.y.ToString();
            dict["id"] = playerDataContainer.ID;
            dict["name"] = playerDataContainer.PlayerName;
			dict["state"] = "0";
			return MiniJSON.Json.Serialize(dict);
		}
	}
}