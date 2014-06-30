package playerudpserver;

/**
 *
 * @author Hizkia Simarmata
 */

import java.net.*;

public class PlayerServerHandler
{
    private final InetAddress _host;
    private final int _port;
    private Player _player;
    private String _id;
    
    public PlayerServerHandler(InetAddress address, int port, Player player)
    {
        _host = address;
        _port = port;
        _player = player;
    }
    
    public InetAddress GetAddress()
    {
        return this._host;
    }
    
    public int GetPort()
    {
        return this._port;
    }
    
    public Player getPlayer()
    {
        return this._player;
    }
    
    public Long getLastUpdateTime()
    {
        return this._player.getLastUpdateTime();
    }
}