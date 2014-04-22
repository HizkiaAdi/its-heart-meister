using UnityEngine;
using System.Collections.Generic;

namespace SocialModule
{
	public class PlayerSocketListener : MonoBehaviour 
	{
		public string host;
		public int port;
		
		private AndroidJavaClass _unityPlayer;
		private AndroidJavaObject _activity;
		private AndroidJavaObject _playerClient;
		
		void Start ()
		{
			string[] args = new string[2];
			args[0] = host;
			args[1] = port.ToString();
			
			_unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			_activity = _unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			_activity.Call("runOnUiThread", new AndroidJavaRunnable(()=>
        	{
				_playerClient = new AndroidJavaObject("com.pejuangcinta.player.PlayerClient", args);
			}
			));
		}
		
		public void ReceivedMessage(string message)
		{
			GameObject.Find("PlayerManager").GetComponent<PlayerManager>().NewMessage(message);
		}
		
		void FixedUpdate ()
		{
			bool success = false;
			string jsonString = PlayerDataToJSON(transform);
			success = _playerClient.Call<bool>("sendMessage", jsonString);
			if (success)
				Debug.Log("Successfully sent message.");
			else
				Debug.Log("Failed to send message.");
		}
		
		private string PlayerDataToJSON(Transform transform)
		{
			Dictionary<string,string> dict = new Dictionary<string, string>();
			dict["x"] = transform.position.x.ToString();
			dict["y"] = transform.position.y.ToString();
			dict["id"] = PlayerData.id;
			dict["name"] = PlayerData.playerName;
			dict["state"] = "0";
			return MiniJSON.Json.Serialize(dict);
		}
	}
}