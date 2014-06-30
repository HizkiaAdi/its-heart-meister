package chatserver;

import java.io.IOException;
import java.net.*;

/**
 *
 * @author Voron
 */
public class ChatServer
{
    private int _port;
    
    public ChatServer(int port)
    {
        _port = port;
    }
    
    public static void main(String[] args)
    {
        ChatServer server;
        
        if(args.length == 1)
            server = new ChatServer(Integer.parseInt(args[0]));
        else
            server = new ChatServer(55556);
        
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
        System.out.println("Starting server on port ["+_port+"].");
        ServerSocket serverSocket = new ServerSocket(_port);

        while (true)
        {
            Socket client = serverSocket.accept();
            System.out.println("Accepted connection from ["+client.getInetAddress()+"].");
            ChatServerHandler c = new ChatServerHandler(client);
            c.start();
        }
    }
}
