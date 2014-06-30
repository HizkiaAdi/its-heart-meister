package chatserver;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Voron
 */

public class ChatServerConnectionManager
{
    private static List<ChatServerHandler> _handlers = new ArrayList<>();
    
    public static void addHandler(ChatServerHandler c)
    {
        _handlers.add(c);
    }
    
    public static void removeHandler(ChatServerHandler c)
    {
        _handlers.remove(c);
    }
    
    public static void broadcast(String message)
    {
        synchronized(_handlers)
        {
            for(ChatServerHandler c : _handlers)
            {
                try
                {
                    synchronized(c.getOutputStream())
                    {
                        c.getOutputStream().writeUTF(message);
                        c.getOutputStream().flush();
                    }
                }
                catch(IOException ex)
                {
                    System.err.println("Unable to broadcast message! Error = [" + ex.getLocalizedMessage() + "]");
                    c.interrupt();
                }
            }
        }
    }
}
