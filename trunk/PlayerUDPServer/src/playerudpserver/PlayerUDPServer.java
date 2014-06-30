package playerudpserver;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

/**
 * @author Hizkia Simarmata
 */

public class PlayerUDPServer
{
    private int _port;
    private DatagramSocket serverSocket;
    private DatagramPacket packet;
    private int BUFFER_SIZE = 1024;
    private byte[] buffer = new byte[1024];
    
    public PlayerUDPServer(int port)
    {
        _port = port;
    }
    
    public static void main(String[] args) 
    {
        PlayerUDPServer server;
        
        if(args.length == 1)
            server = new PlayerUDPServer(Integer.parseInt(args[0]));
        else
            server = new PlayerUDPServer(55555);
        
        try
        {
            server.start();       
        }
        catch(IOException ex)
        {
            System.err.println(ex.getLocalizedMessage());
        }
    }
    
    public void start() throws IOException
    {
        System.out.println("Starting server on port " + _port);
        serverSocket = new DatagramSocket(_port);
        PlayerServerConnectionManager.StartManager(serverSocket);
    }    
}
