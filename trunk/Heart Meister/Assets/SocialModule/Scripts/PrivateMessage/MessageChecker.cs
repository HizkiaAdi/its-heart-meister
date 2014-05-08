using UnityEngine;
using System.Collections.Generic;

public class MessageChecker : MonoBehaviour 
{
	int i;
	List<Message> messageList;

	void Awake ()
	{
		messageList = new List<Message>();
	}

	void Start () 
	{
		/*
		 * To-do:
		 * Get all message from webservice
		 */
		for(i = 0 ; i < 50; i++)
			messageList.Add(new Message(i,1,"Hizkia","Haha " + i, System.DateTime.Now.ToString()));
		
		/*foreach(Message i in messageList)
			Debug.Log(i.ToString());*/

		InvokeRepeating("CheckForNewMessage", 0, 3);
	}

	void CheckForNewMessage()
	{
		/*
		To-do:
		Check new message from webservice
		*/
		//messageList.Add(new Message(++i,1,"Hizkia","Haha " + i, System.DateTime.Now.ToString()));
	}

	public void GetMessageList(out List<Message> param)
	{
		param = this.messageList;
	}
}
