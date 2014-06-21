using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DungeonGenerator;

public class TileMap : MonoBehaviour {

    public GameObject grid;
    public Sprite[] mapTile;
    SpriteRenderer mapSprite;
    public int level;
    public List<GameObject> node;
    Node vertex;
    GraphData graphData;

	// Use this for initialization
	void Start() 
    {
        graphData = GraphData.CreateGraphSingleton();
        InitGridMap();
        Generate();
        ShowDestination();
        //ShowDestination2();
	}

    void ShowDestination()
    {
        foreach (var i in graphData.Nodes)
        {
            //Debug.Log("connection count: " + i.Connection.Count);
            Debug.Log("node: " + i.Id + " weight: " + i.Weight);
            foreach (var j in i.Connection)
            {
                Debug.Log(i.Id+" destination: " + j.Id);
            }
        }
    }

    public void showDestination2()
    {
        foreach (var i in node)
        {
            foreach (var j in i.GetComponent<TileBehaviour>().Destination)
            {
                Debug.Log("Origin "+i.GetComponent<TileBehaviour>().index+",  destination"+j.GetComponent<TileBehaviour>().index);
                Debug.Log("Weight "+i.GetComponent<TileBehaviour>().Weight);
            }
        }
    }
	
    // Update is called once per frame
	void Update () 
    {
	
	}

    void InitGridMap()
    {
        float x = -3, y = 3;
        for (int i = 0; i < 7; i++)
        {
            x = -4;
            for (int j = 0; j < 7; j++)
            {
                Instantiate(grid, new Vector2(x, y), transform.rotation);
                x+=1.4f;
            }
            y-=1.2f;
        }
    }

    void Generate()
    {
        node = new List<GameObject>();
        level = 43;
        int[,] gridTile = new int[7, 7];
        float x = -3, y = 3;
        int c=0, count=0;
        
        GraphData graphData = GraphData.CreateGraphSingleton();

        if (level <= 10)
        {
            for (int i = 0; i < 7; i++)
            {
                x = -4;
                for (int j = 0; j < 7; j++)
                {
                    if (BaseMapModel.GetGridStatus(j, i) == 1)
                    {
                        vertex = new Node();
                        vertex.Id = count;
                        count++;
                        vertex.Weight = Random.Range(1, 10);
                        //graphData.Weight = vertex.Weight;
                        graphData.Nodes.Add(vertex);
                        RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                        node.Add(selectedGrid.transform.gameObject);
                        
                        //generate disini
                        if (selectedGrid.collider != null)
                        {                           
                            mapSprite = selectedGrid.collider.gameObject.GetComponent<SpriteRenderer>();
                            if (i == 6 || j == 6)
                            {
                                mapSprite.sprite = mapTile[0];
                            }
                            else
                                mapSprite.sprite = mapTile[1];
                        }
                        c++;
                    }
                    x+=1.4f;
                }
                y-=1.2f;
            }
            graphData.Nodes[0].Connection.Add(graphData.Nodes[1]);
            graphData.Nodes[0].Connection.Add(graphData.Nodes[2]);
            graphData.Nodes[0].Connection.Add(graphData.Nodes[3]);

            graphData.Nodes[1].Connection.Add(graphData.Nodes[2]);
            graphData.Nodes[1].Connection.Add(graphData.Nodes[4]);

            graphData.Nodes[2].Connection.Add(graphData.Nodes[4]);

            graphData.Nodes[3].Connection.Add(graphData.Nodes[2]);
            graphData.Nodes[3].Connection.Add(graphData.Nodes[4]);
        } 
        else
            if (level > 10 && level <= 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    x = -4;
                    for (int j = 0; j < 7; j++)
                    {
                        if (BaseMapModel.GetGridStatus2(j, i) == 1)
                        {
                            vertex = new Node();
                            vertex.Id = count;
                            count++;
                            vertex.Weight = Random.Range(1, 10);
                            //graphData.Weight = vertex.Weight;
                            graphData.Nodes.Add(vertex);
                            RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                            node.Add(selectedGrid.transform.gameObject);
                            
                            //generate disini
                            if (selectedGrid.collider != null)
                            {
                                mapSprite = selectedGrid.collider.gameObject.GetComponent<SpriteRenderer>();
                                if (i == 6 || j == 6)
                                {
                                    mapSprite.sprite = mapTile[0];
                                }
                                else
                                    mapSprite.sprite = mapTile[1];
                            }
                            c++;
                        }
                        x+=1.4f;
                    }
                    y-=1.2f;
                }
                graphData.Nodes[0].Connection.Add(graphData.Nodes[1]);
                graphData.Nodes[0].Connection.Add(graphData.Nodes[2]);

                graphData.Nodes[1].Connection.Add(graphData.Nodes[2]);
                graphData.Nodes[1].Connection.Add(graphData.Nodes[3]);
                graphData.Nodes[1].Connection.Add(graphData.Nodes[4]);

                graphData.Nodes[2].Connection.Add(graphData.Nodes[3]);
                graphData.Nodes[2].Connection.Add(graphData.Nodes[4]);

                graphData.Nodes[3].Connection.Add(graphData.Nodes[4]);
                graphData.Nodes[3].Connection.Add(graphData.Nodes[5]);

                graphData.Nodes[4].Connection.Add(graphData.Nodes[5]);
            }
            else
                if (level > 20 && level <=30)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        x = -4;
                        for (int j = 0; j < 7; j++)
                        {
                            if (BaseMapModel.GetGridStatus3(i, j) == 1)
                            {
                                vertex = new Node();
                                vertex.Id = count;
                                count++;
                                vertex.Weight = Random.Range(1, 10); ;
                                graphData.Nodes.Add(vertex);
                                RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                                node.Add(selectedGrid.transform.gameObject);
                                //generate disini
                                if (selectedGrid.collider != null)
                                {
                                    mapSprite = selectedGrid.collider.gameObject.GetComponent<SpriteRenderer>();
                                    if (i == 6 || j == 6)
                                    {
                                        mapSprite.sprite = mapTile[0];
                                    }
                                    else
                                        mapSprite.sprite = mapTile[1];
                                }
                                c++;
                            }
                            x+=1.4f;
                        }
                        y-=1.2f;
                    }
                    graphData.Nodes[0].Connection.Add(graphData.Nodes[1]);

                    graphData.Nodes[1].Connection.Add(graphData.Nodes[2]);
                    graphData.Nodes[1].Connection.Add(graphData.Nodes[3]);

                    graphData.Nodes[2].Connection.Add(graphData.Nodes[3]);
                    graphData.Nodes[2].Connection.Add(graphData.Nodes[4]);
                    graphData.Nodes[2].Connection.Add(graphData.Nodes[5]);

                    graphData.Nodes[3].Connection.Add(graphData.Nodes[4]);
                    graphData.Nodes[3].Connection.Add(graphData.Nodes[5]);

                    graphData.Nodes[4].Connection.Add(graphData.Nodes[5]);
                    graphData.Nodes[4].Connection.Add(graphData.Nodes[6]);

                    graphData.Nodes[5].Connection.Add(graphData.Nodes[6]);
                }
                else
                    if (level > 30 && level <= 40)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            x = -4;
                            for (int j = 0; j < 7; j++)
                            {
                                if (BaseMapModel.GetGridStatus4(i, j) == 1)
                                {
                                    vertex = new Node();
                                    vertex.Id = count;
                                    count++;
                                    vertex.Weight = Random.Range(1, 10);
                                    graphData.Nodes.Add(vertex);
                                    RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                                    node.Add(selectedGrid.transform.gameObject);
                                    //generate disini
                                    if (selectedGrid.collider != null)
                                    {
                                        mapSprite = selectedGrid.collider.gameObject.GetComponent<SpriteRenderer>();
                                        if (i == 6 || j == 6)
                                        {
                                            mapSprite.sprite = mapTile[0];
                                        }
                                        else
                                            mapSprite.sprite = mapTile[1];
                                    }
                                    c++;
                                }
                                x+=1.4f;
                            }
                            y-=1.2f;
                        }
                        graphData.Nodes[0].Connection.Add(graphData.Nodes[1]);
                        graphData.Nodes[0].Connection.Add(graphData.Nodes[2]);

                        graphData.Nodes[1].Connection.Add(graphData.Nodes[3]);
                        graphData.Nodes[1].Connection.Add(graphData.Nodes[4]);

                        graphData.Nodes[2].Connection.Add(graphData.Nodes[3]);
                        graphData.Nodes[2].Connection.Add(graphData.Nodes[4]);

                        graphData.Nodes[3].Connection.Add(graphData.Nodes[5]);
                        graphData.Nodes[3].Connection.Add(graphData.Nodes[6]);

                        graphData.Nodes[4].Connection.Add(graphData.Nodes[5]);
                        graphData.Nodes[4].Connection.Add(graphData.Nodes[6]);

                        graphData.Nodes[5].Connection.Add(graphData.Nodes[7]);

                        graphData.Nodes[6].Connection.Add(graphData.Nodes[7]);
                    }
                    else
                        if (level > 40 && level <= 50)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                x = -4;
                                for (int j = 0; j < 7; j++)
                                {
                                    if (BaseMapModel.GetGridStatus5(i, j) == 1)
                                    {
                                        vertex = new Node();
                                        vertex.Id = count;
                                        count++;
                                        vertex.Weight = Random.Range(1, 10);
                                        graphData.Nodes.Add(vertex);
                                        RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                                        node.Add(selectedGrid.transform.gameObject);
                                        //selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().index = c;
                                        //selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().Weight = Random.Range(0, 5);
                                        
                                        //generate disini
                                        if (selectedGrid.collider != null)
                                        {
                                            mapSprite = selectedGrid.collider.gameObject.GetComponent<SpriteRenderer>();
                                            if (i == 6 || j == 6)
                                            {
                                                mapSprite.sprite = mapTile[0];
                                            }
                                            else
                                                mapSprite.sprite = mapTile[1];
                                        }
                                        c++;
                                    }
                                    x+=1.4f;
                                }
                                y-=1.2f;
                            }
                            graphData.Nodes[0].Connection.Add(graphData.Nodes[1]);
                            graphData.Nodes[0].Connection.Add(graphData.Nodes[2]);
                            graphData.Nodes[0].Connection.Add(graphData.Nodes[3]);

                            graphData.Nodes[1].Connection.Add(graphData.Nodes[2]);
                            graphData.Nodes[1].Connection.Add(graphData.Nodes[4]);

                            graphData.Nodes[2].Connection.Add(graphData.Nodes[4]);
                            graphData.Nodes[2].Connection.Add(graphData.Nodes[5]);

                            graphData.Nodes[3].Connection.Add(graphData.Nodes[2]);
                            graphData.Nodes[3].Connection.Add(graphData.Nodes[5]);

                            graphData.Nodes[4].Connection.Add(graphData.Nodes[6]);
                            graphData.Nodes[4].Connection.Add(graphData.Nodes[7]);

                            graphData.Nodes[5].Connection.Add(graphData.Nodes[6]);
                            graphData.Nodes[5].Connection.Add(graphData.Nodes[7]);

                            graphData.Nodes[6].Connection.Add(graphData.Nodes[8]);

                            graphData.Nodes[7].Connection.Add(graphData.Nodes[8]);
                        }
    }
}