using UnityEngine;
using System.Collections.Generic;
using Webservice;

public class MessageChecker : MonoBehaviour 
{
	int i;
	List<Message> messageList;
    WebService ws;
    PlayerData playerData;
    List<System.Object> resultList;
    Dictionary<string, System.Object> resultDict;
    PerformanceCounter pc;

	void Awake ()
	{
		messageList = new List<Message>();
        playerData = GameObject.Find("PlayerDataContainner").GetComponent<PlayerData>();
	}

	void Start () 
	{
        RetrieveMessage();
	}

	void RetrieveMessage()
	{
        pc = new PerformanceCounter();
        pc.Start();
        ws = new WebService();
        resultList = ws.GetPM(int.Parse(playerData.ID));
        foreach (System.Object o in resultList)
        {
            resultDict = o as Dictionary<string, System.Object>;
            messageList.Add(new Message(int.Parse((string)resultDict["pmid"]),
                int.Parse((string)resultDict["fromid"]), (string)resultDict["sendername"],
                (string)resultDict["message"], (string)resultDict["time"]));
        }
        Debug.Log("Mengambil daftar pesan: " + pc.End() + "ms");
	}

	public void GetMessageList(out List<Message> param)
	{
		param = this.messageList;
	}

    public void SendPM(string target, string message)
    {
        pc = new PerformanceCounter();
        pc.Start();
        ws = new WebService();
        ws.SendPM(int.Parse(playerData.ID),target,message);
        Debug.Log("Mengirim pesan: " + pc.End() + "ms");
    }

    public void DeletePM(int id)
    {
        pc = new PerformanceCounter();
        pc.Start();
        ws = new WebService();
        ws.DeletePM(id);
        Debug.Log("Menghapus pesan: " + pc.End() + "ms");
    }
}
