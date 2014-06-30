package playerudpserver;

/**
 *
 * @author Hizkia Simarmata
 */

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.json.simple.*;
import org.json.simple.parser.*;

public class PlayerServerConnectionManager 
{
    private static DatagramSocket serverSocket;
    private static DatagramPacket receivedPacket;
    private static DatagramPacket sentPacket;
    private static final int BUFFER_SIZE = 1500;
    private static byte[] sentBuffer;
    private static byte[] receivedBuffer;
    private static List<String> _handlersKey;
    private static Map<String, PlayerServerHandler> _handlers;
    private static List<String> _removeQueue;
    private static String message;
    private static JSONObject _jsonObj;
    private static JSONObject _jsonFinalObj;
    private static JSONArray _jsonArray;
    private static Long _start;
    private static Long _end;
    private static ByteArrayInputStream bais;
    private static ObjectInputStream ois;
    private static ByteArrayOutputStream baos;
    private static ObjectOutputStream oos;
    private static Thread listener;
    private static Thread sender;
    
    public static void AddHandler(String id, PlayerServerHandler p)
    {
        _handlersKey.add(id);
        _handlers.put(id, p);
    }
    
    public static void StartManager(DatagramSocket s)
    {
        serverSocket = s;
        _handlersKey = new ArrayList<>();
        _handlers = new HashMap<>();
        _removeQueue = new ArrayList<>();
        StartListener();
        StartBroadCast();
    }
    
    private static void AddPlayer(Player player, InetAddress address, int port)
    {
        PlayerServerHandler handler = new PlayerServerHandler(address, port, player);
        AddHandler(player.getID(), handler);
    }
    
    private static void StartListener()
    {
        listener = new Thread()
        {
            @Override
            public void run()
            {
                receivedBuffer = new byte[BUFFER_SIZE];    
                try
                {
                    serverSocket.setSoTimeout(0);
                    while(true)
                    {
                        receivedPacket = new DatagramPacket(receivedBuffer, receivedBuffer.length);
                        serverSocket.receive(receivedPacket);
                        //System.out.println(receivedPacket.getLength());
                        //System.out.println("Get message from " + receivedPacket.getAddress() + ": " + new String(receivedPacket.getData()));
                        bais = new ByteArrayInputStream(receivedBuffer);
                        ois = new ObjectInputStream(bais);
                        ois.read(receivedBuffer);
                        ProcessJSON((String)ois.readObject(), receivedPacket.getAddress(), receivedPacket.getPort());
                    }
                }
                catch(IOException | ParseException | ClassNotFoundException ex)
                {
                    System.err.println("Listener error: " + ex.getMessage());
                    //ex.printStackTrace();
                }
            }
        };
        listener.start();
    }
    
    private static void ProcessJSON(String jsonString, InetAddress address, int port) throws ParseException
    {
        JSONObject jsonObj;
        JSONParser parser = new JSONParser();
        Player player;
        
        //System.out.println("Received message from: " + address.getHostAddress() + ":" + port + ", message: " + jsonString);
        //System.out.println(jsonString.length());
        jsonObj = (JSONObject)parser.parse(jsonString);
        if(_handlersKey.contains((String)jsonObj.get("id")))
        {
            player = _handlers.get((String)jsonObj.get("id")).getPlayer();
            player.SetNew(Float.parseFloat((String)jsonObj.get("x")),
                    Float.parseFloat((String)jsonObj.get("y")));
        }
        else
        {
            player = new Player((String)jsonObj.get("id"),
                    Float.parseFloat((String)jsonObj.get("x")),
                    Float.parseFloat((String)jsonObj.get("y")));
            PlayerServerConnectionManager.AddPlayer(player, address, port);
        }            
    }
    
    private static void StartBroadCast()
    {
        while(true)
        {   
            RemovePlayerFromList();
            _start = System.currentTimeMillis();
            synchronized(_handlers)
            {
                _jsonFinalObj = new JSONObject();
                _jsonArray = new JSONArray();
                System.out.println(_handlersKey.size());
                for(String key : _handlersKey)
                {
                    if(_start - _handlers.get(key).getLastUpdateTime() > 5000)
                    {
                        _removeQueue.add(key);
                        continue;
                    }
                    _jsonObj = new JSONObject();
                    _jsonObj.put("id",_handlers.get(key).getPlayer().getID());
                    _jsonObj.put("vectorX",String.valueOf(_handlers.get(key).getPlayer().getVectorX()));
                    _jsonObj.put("vectorY",String.valueOf(_handlers.get(key).getPlayer().getVectorY()));
                    _jsonObj.put("x",String.valueOf(_handlers.get(key).getPlayer().getX()));
                    _jsonObj.put("y",String.valueOf(_handlers.get(key).getPlayer().getY()));
                    _jsonArray.add(_jsonObj);
                }
                _jsonFinalObj.put("data",_jsonArray);
                message = _jsonFinalObj.toJSONString();

                try
                {
                    baos = new ByteArrayOutputStream();
                    oos = new ObjectOutputStream(baos);
                    oos.writeObject((Object)message);
                    oos.flush();
                    sentBuffer = baos.toByteArray();
                }
                catch(IOException ex)
                {
                    System.err.println(ex.getLocalizedMessage());
                }

                for(String key : _handlersKey)
                {
                    //System.out.println("Sending message to " + _handlers.get(key).GetAddress() + ":" + _handlers.get(key).GetPort());
                    sentPacket = new DatagramPacket(sentBuffer, sentBuffer.length, _handlers.get(key).GetAddress(), _handlers.get(key).GetPort());
                    try
                    {
                        serverSocket.send(sentPacket);
                    }
                    catch(IOException ex)
                    {
                        System.out.println("Error broadcasting message: " + ex.getLocalizedMessage());
                    }
                }
            }
            _end = System.currentTimeMillis();
            try
            {
                if((_end - _start) <= 500)
                    Thread.currentThread().sleep(500 - (_end - _start));
            }
            catch(InterruptedException ex)
            {
                System.err.println("Thread error: " + ex.getLocalizedMessage());
            }
        }
    }
    
    private static void RemovePlayerFromList()
    {
        synchronized(_handlers)
        {
            for(String key : _removeQueue)
            {
                _handlers.remove(key);
                _handlersKey.remove(key);
            }
        }
    }
}
