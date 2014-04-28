package com.pejuangcinta.clientplugin;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.UnknownHostException;

import com.unity3d.player.UnityPlayer;

import android.os.Looper;
import android.util.Log;

public class PlayerClient
{
	private static final String TAG = "UnityAndroidPlugin";
	private InetAddress _host;
	private int _port;	
	private DatagramSocket _socket;
	private DatagramPacket _receivedPacket;
	private DatagramPacket _sentPacket;
	private int BUFFER_SIZE = 1500;
	private byte[] _receivedBuffer;
	private byte[] _sentBuffer;
	private Thread _listener;
	private ByteArrayOutputStream baos;
	private ObjectOutputStream oos;
	private ByteArrayInputStream bais;
	private ObjectInputStream ois;
	
	public PlayerClient(String host, String port)
	{
		try
		{
			_host = InetAddress.getByName(host);
			_port = Integer.parseInt(port);
		}
		catch(UnknownHostException ex)
		{
			Log.e(TAG, ex.getLocalizedMessage());
		}
		
		if(Looper.myLooper() == null)
			Looper.prepare();
		
		_listener = new Thread()
		{
			@Override
			public void run()
			{
				try
				{
					_socket = new DatagramSocket(55555);
					_socket.setSoTimeout(10000);
					_receivedBuffer = new byte[BUFFER_SIZE];
					_receivedPacket = new DatagramPacket(_receivedBuffer, _receivedBuffer.length);
					
					//Looper.prepare();
					while(true)
					{
						Log.i(TAG, "Waiting for server message..");
						_socket.receive(_receivedPacket);
						bais = new ByteArrayInputStream(_receivedBuffer);
                        ois = new ObjectInputStream(bais);
                        ois.read(_receivedBuffer);
						String line = (String)ois.readObject();
						Log.i(TAG, "Received message from server. Message = " + line);
						UnityPlayer.UnitySendMessage("Player", "ReceivedMessage", line);
					}
					//Looper.loop();
				}
				catch(IOException | ClassNotFoundException ex)
				{
					ex.printStackTrace();
					Log.e(TAG, ex.getMessage());
					Thread.currentThread().interrupt();
				}				
				//return;
			}
		};
		_listener.start();
	}
	
	public boolean sendMessage(String message)
	{
		try
		{
			baos = new ByteArrayOutputStream();
            oos = new ObjectOutputStream(baos);
            oos.writeObject((Object)message);
            oos.flush();
            _sentBuffer = baos.toByteArray();
            //System.out.println(buffer.length);
			Log.i(TAG, "Sending message to server. Message = " + message);
			//_sentBuffer = message.getBytes();
			_sentPacket = new DatagramPacket(_sentBuffer, _sentBuffer.length, _host, _port);
			_socket.send(_sentPacket);
			return true;
		}
		catch(IOException ex)
		{
			Log.e(TAG, "Unable to send message.", ex);
			_listener.interrupt();
			return false;
		}
	}
}
