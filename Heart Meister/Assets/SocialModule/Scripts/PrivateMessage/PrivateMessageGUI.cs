using UnityEngine;
using System.Collections.Generic;

public class PrivateMessageGUI : MonoBehaviour
{
	public GameObject container;
	public GUISkin skin;

	List<Message> messageList;
	Rect scrollViewRect;
	Rect viewWindowRect;
	Rect descWindowRect;
	Rect senderLabelRect;
	Rect dateLabelRect;
	Rect messageLabelRect;
	Rect messageBoxRect;
	Rect delButtonRect;
	Rect replyButtonRect;
	Rect newButtonRect;
	Rect modalWindowRect;
	Rect receiverLabelRect;
	Rect sentMessageLabel;
	Rect receiverFieldRect;
	Rect sentMessageFieldRect;
	Rect modalSendRect;
	Rect modalCancelRect;
	Vector2 scrollPos;
	Vector2 mousePos;
	float screenHeight;
	float screenWidth;
	float xUnit;
	float yUnit;
	float scrollItemHeight;
	Message selectedMessage;
	string senderString;
	string dateString;
	string messageString;
	string receiverString;
	string sentMessageString;
	bool drawModal;

	void Awake()
	{
		//Get current screen width and height
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		//Calculate x and y unit size for GUI
		xUnit = Screen.width * 0.01f;
		yUnit = screenHeight * 0.01f;
		//Initialize the scroll view position & size
		scrollViewRect = new Rect(5 * xUnit, 10 * yUnit, 40 * xUnit, 85 * yUnit);
		viewWindowRect = new Rect(0, 0, 37 * xUnit, 0);
		//Initialize the scroll view item height
		scrollItemHeight = 10f;
		//Initialize scroll position to zero
		scrollPos = Vector2.zero;
		//Initialize the message description window position & size
		descWindowRect = new Rect(50 * xUnit, 10 * yUnit, 45 * xUnit, 75 * yUnit);
		//Initialize the description window's position & elements size
		senderLabelRect = new Rect(2 * xUnit, 3 * yUnit, descWindowRect.width - 4 * xUnit, 10 * yUnit);
		dateLabelRect = new Rect(2 * xUnit, 13 * yUnit, descWindowRect.width - 4 * xUnit, 10 * yUnit);
		messageLabelRect = new Rect(2 * xUnit, 23 * yUnit, descWindowRect.width - 4 * xUnit, 5 * yUnit);
		messageBoxRect = new Rect(2 * xUnit, 28 * yUnit, descWindowRect.width - 4 * xUnit, 44 * yUnit);
		//Initialize buttons position & size
		newButtonRect = new Rect(50 * xUnit, 90 * yUnit, 12 * xUnit, 5 * yUnit);
		replyButtonRect = new Rect(66.5f * xUnit, 90 * yUnit, 12 * xUnit, 5 * yUnit);
		delButtonRect = new Rect(83 * xUnit, 90 * yUnit, 12 *xUnit, 5 * yUnit);
		//Initialize all string to empty
		senderString = string.Empty;
		dateString = string.Empty;
		messageString = string.Empty;
		receiverString = string.Empty;
		sentMessageString = string.Empty;
		//Initialize modal window position & size
		modalWindowRect = new Rect(35 * xUnit, 25 * yUnit, 30 * xUnit, 50 * yUnit);
		//Initialize modal's elemts position & size
		receiverLabelRect = new Rect(2 * xUnit, 3 * yUnit, 26 * xUnit, 5 * yUnit);
		receiverFieldRect = new Rect(2 * xUnit, 9 * yUnit, 26 * xUnit, 5 * yUnit);
		sentMessageLabel = new Rect(2 * xUnit, 15  * yUnit, 26 * xUnit, 5 * yUnit);
		sentMessageFieldRect = new Rect(2 * xUnit, 21 * yUnit, 26 * xUnit, 20 * yUnit);
		modalSendRect = new Rect(2 * xUnit, 42 * yUnit, 12 * xUnit, 5 * yUnit);
		modalCancelRect = new Rect(16 * xUnit, 42 * yUnit, 12 * xUnit, 5 * yUnit);
	}

	void Start()
	{
		//Get message from container object
		container.GetComponent<MessageChecker>().GetMessageList(out messageList);
	}

	void OnGUI()
	{
		DrawMessageList();
		DrawDescriptionWindow();
		if(drawModal)
			DrawModalWindow();
	}

	void DrawMessageList()
	{
		if(messageList == null)
			return;

		if(drawModal)
			GUI.enabled = false;
		
		mousePos = Input.mousePosition;
		mousePos.y = screenHeight - mousePos.y;
		
		if(!drawModal && Input.GetMouseButtonDown(0) && scrollViewRect.Contains(mousePos))
		{
			int index = Mathf.CeilToInt((mousePos.y + scrollPos.y - scrollViewRect.y) / (scrollItemHeight * yUnit)) - 1;
			selectedMessage = messageList[index];
			senderString = selectedMessage.SenderName;
			dateString = selectedMessage.Date;
			messageString = selectedMessage.MessageString;
		}
		
		viewWindowRect.height = messageList.Count * scrollItemHeight * yUnit;
		
		GUI.skin = skin;
		
		scrollPos = GUI.BeginScrollView (scrollViewRect, scrollPos, viewWindowRect);
		for(int i = 0; i < messageList.Count; i++)
		{
			GUI.Box(new Rect(0, scrollItemHeight * i * yUnit, viewWindowRect.width, scrollItemHeight * yUnit), 
			        "Date: " + messageList[i].Date + "\nSender: " + messageList[i].MessageString);
		}
		GUI.EndScrollView();
	}

	void DrawDescriptionWindow()
	{
		if(drawModal)
			GUI.enabled = false;

		GUI.Window(0, descWindowRect, WindowCallback, "Message Detail");

		if(GUI.Button(newButtonRect, "New message"))
		{
			drawModal = true;
		}

		if(selectedMessage == null)
			GUI.enabled = false;

		if(GUI.Button(replyButtonRect, "Reply"))
		{
			receiverString = selectedMessage.SenderName;
			drawModal = true;
		}

		if(GUI.Button(delButtonRect, "Delete"))
		{
			DeleteSelectedMessage();
		}

		GUI.enabled = true;
	}

	void DeleteSelectedMessage()
	{
		messageList.Remove(selectedMessage);
		selectedMessage = null;
	}

	void DrawModalWindow()
	{
		GUI.enabled = true;
		GUI.ModalWindow(1, modalWindowRect, WindowCallback, "Send Message");
	}

	void WindowCallback(int id)
	{
		switch(id)
		{
			case 0:
				GUI.Label(senderLabelRect, "Sender:\n\t\t" + senderString);
				GUI.Label(dateLabelRect, "Date:\n\t\t" + dateString);
				GUI.Label(messageLabelRect, "Message:");
				GUI.Box(messageBoxRect, messageString);
				break;

			case 1:
				GUI.Label(receiverLabelRect, "Receiver:");
				receiverString = GUI.TextField(receiverFieldRect, receiverString);
				GUI.Label(sentMessageLabel, "Message:");
				sentMessageString = GUI.TextArea(sentMessageFieldRect, sentMessageString);
				if(GUI.Button(modalSendRect, "Send!"))
				{
					receiverString = string.Empty;
					sentMessageString = string.Empty;
					drawModal = false;
				}
				if(GUI.Button(modalCancelRect, "Cancel"))
				{
					receiverString = string.Empty;
					sentMessageString = string.Empty;
					drawModal = false;
				}
				break;
		}
	}
}