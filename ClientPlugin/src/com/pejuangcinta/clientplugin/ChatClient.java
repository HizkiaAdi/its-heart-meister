package com.pejuangcinta.clientplugin;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

import android.os.Looper;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

public class ChatClient 
{
private static final String TAG = "UnityChatClient";
	
	private volatile Socket _socket;
	private volatile DataInputStream _inputStream;
	private volatile DataOutputStream _outputStream;
	private volatile String _host;
	private volatile int _port;
	
	private Thread _listener;
	
	public ChatClient(String host, String port) throws IOException
	{
		_host = host;
		_port = Integer.parseInt(port);
		
		if (Looper.myLooper() == null) {
	        Looper.prepare();
	    }
		
		_listener = new Thread()
		{
			@Override
			public void run()
			{
				try
				{
					_socket = new Socket(_host, _port);
					Log.v(TAG,"Connected to chat server at " + _socket.getInetAddress().getHostAddress() + ":" + _socket.getLocalPort());
					_inputStream = new DataInputStream(_socket.getInputStream());
					Log.v(TAG,"InputStream: " + _inputStream.toString());
					_outputStream = new DataOutputStream(_socket.getOutputStream());
					Log.v(TAG,"OutputStream: " + _outputStream.toString());
					
					while (true) 
					{
						Log.i(TAG, "Waiting for server message...");
						String line = _inputStream.readUTF();
						Log.i(TAG, "Received message from server. Message = ["+line+"].");
						UnityPlayer.UnitySendMessage("Player", "ReceivedChatMessage", line);
					}
				}
				catch(IOException ex)
				{
					Log.e(TAG, ex.getLocalizedMessage());
				}
				Thread.currentThread().interrupt();
				return;
			}
		};
		_listener.start();
	}
	
	public boolean sendMessage(String message)
	{
		try
		{
			Log.i(TAG, "Sending message to server. Message = ["+message+"].");
			_outputStream.writeUTF(message);
			_outputStream.flush();
			return true;
		}
		catch (IOException e) 
		{
			Log.e(TAG, "Unable to send message.", e);
			_listener.interrupt();
		}
		return false;
	}
}
