package chatserver;

/**
 *
 * @author Voron
 */

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.*;

public class ChatServerHandler extends Thread
{
    private Socket _socket;
    private DataInputStream _inputStream;
    private DataOutputStream _outputStream;
    
    public ChatServerHandler(Socket s) throws IOException
    {
        _socket = s;
        _inputStream = new DataInputStream(new BufferedInputStream(s.getInputStream()));
        _outputStream = new DataOutputStream(new BufferedOutputStream(s.getOutputStream()));
    }
    
    public DataOutputStream getOutputStream()
    {
        return this._outputStream;
    }
    
    public DataInputStream getInputStream()
    {
        return this._inputStream;
    }
    
    @Override
    public void run()
    {
        try 
        {
            ChatServerConnectionManager.addHandler(this);
            while (true) 
            {
                String message = _inputStream.readUTF();
                System.out.println("Received message from [" + 
                        _socket.getInetAddress() + "]. Message = [" + message + "].");
                ChatServerConnectionManager.broadcast(message);
            }
        }
        catch (IOException ex) 
        {
            System.err.println("Error in ChatServerHandler. Error = [" + ex.getLocalizedMessage() + " ].");
            //ex.printStackTrace()
        }
        finally
        {
            ChatServerConnectionManager.removeHandler(this);
            try
            {
                _socket.close();
            }
            catch (IOException ex) 
            {
                System.err.println("Unable to close socket. Error = [" + ex.getLocalizedMessage() + "].");
            }
        }
    }
}
