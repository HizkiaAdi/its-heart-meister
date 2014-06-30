package playerudpserver;

/**
 *
 * @author Voron
 */

public class Player
{
    private String id;
    private String name;
    private float x;
    private float y;
    private float vectorX;
    private float vectorY;
    private int state;
    private long last;
    
    public Player(String id, String name, float x, float y, int state)
    {
        this.id = id;
        this.name = name;
        this.x = x;
        this.y = y;
        this.state = state;
        this.last = System.currentTimeMillis();
    }
    
    public Player(String id, float x, float y)
    {
        this.id = id;
        this.x = x;
        this.y = y;
        this.last = System.currentTimeMillis();
    }
    
    public void SetNew(float xNew, float yNew)
    {
        Long now = System.currentTimeMillis();
        if(xNew - this.y != 0)
            this.vectorX = (xNew - this.x) / 0.5f;
        else
            this.vectorX = 0.0f;
        if(yNew - this.y != 0)
            this.vectorY = (xNew - this.y) / 0.5f;
        else
            this.vectorY = 0.0f;
        this.x = xNew;
        this.y = yNew;
        this.last = now;
        /*System.out.println("pos: (" + this.x + "," + this.y + ")\n" + 
                "vector: (" + String.valueOf(this.vectorX) + "," + String.valueOf(this.vectorY) + ")");*/
    }
    
    public String getID() {return this.id;}
    
    public String getName() {return this.name;}
    
    public int getState() {return this.state;}
    
    public float getX() {return this.x;}
    
    public float getY() {return this.y;}
    
    public float getVectorX() {return this.vectorX;}
    
    public float getVectorY() {return this.vectorY;}
    
    public Long getLastUpdateTime() {return this.last;}
}
