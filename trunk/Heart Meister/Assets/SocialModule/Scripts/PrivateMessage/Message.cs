using UnityEngine;
using System.Collections.Generic;

public class Message
{
	public int Id { get; set; }
	public int SenderId { get; set; }
	public string SenderName { get; set; }
	public string MessageString { get; set; }
	public string Date { get; set; }

	public Message(int id, int senderid, string sendername, string messagestring, string date)
	{
		this.Id = id;
		this.SenderId = senderid;
		this.SenderName = sendername;
		this.MessageString = messagestring;
		this.Date = date;
	}

	public override string ToString ()
	{
		return string.Format ("[Message: Id={0}, " +
			"SenderId={1}, " +
			"SenderName={2}, " +
			"MessageString={3}, " + "" +
      		"Date={4}]", 
      		Id, SenderId, SenderName, MessageString, Date);
	}
}
