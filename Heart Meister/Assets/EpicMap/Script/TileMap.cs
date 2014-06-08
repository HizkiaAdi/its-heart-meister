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

	// Use this for initialization
	void Start () 
    {
        InitGridMap();
        Generate();
        showDestination();
        //List<Node> listNode = new List<Node>();
        //listNode = BaseMapModel.GetNode();

        //foreach (Node i in listNode)
        //{
        //    Debug.Log(i.Destination);
        //}
	}

    public void showDestination()
    {
        foreach (var i in node)
        {
            foreach (var j in i.GetComponent<TileBehaviour>().Destination)
            {
                Debug.Log("Origin "+i.GetComponent<TileBehaviour>().index+" destination"+j.GetComponent<TileBehaviour>().index);
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

   //int tileNumber = Random.Range(0, 2);               

    void Generate()
    {
        node = new List<GameObject>();
        level = 23;
        int[,] gridTile = new int[7, 7];
        float x = -3, y = 3;
        int c=0;

        if (level <= 10)
        {
            for (int i = 0; i < 7; i++)
            {
                x = -4;
                for (int j = 0; j < 7; j++)
                {
                    if (BaseMapModel.GetGridStatus(i, j) == 1)
                    {
                        RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                        selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().index=c;
                        selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().Weight = Random.Range(0, 5);
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
            node[0].GetComponent<TileBehaviour>().Destination.Add(node[1]);
            node[0].GetComponent<TileBehaviour>().Destination.Add(node[2]);
            node[0].GetComponent<TileBehaviour>().Destination.Add(node[3]);

            node[1].GetComponent<TileBehaviour>().Destination.Add(node[2]);
            node[1].GetComponent<TileBehaviour>().Destination.Add(node[4]);

            node[2].GetComponent<TileBehaviour>().Destination.Add(node[4]);

            node[3].GetComponent<TileBehaviour>().Destination.Add(node[2]);
            node[3].GetComponent<TileBehaviour>().Destination.Add(node[4]);
        } 
        else
            if (level > 10 && level <= 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    x = -4;
                    for (int j = 0; j < 7; j++)
                    {
                        if (BaseMapModel.GetGridStatus2(i, j) == 1)
                        {
                            RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                            selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().index = c;
                            selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().Weight = Random.Range(0, 5);
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
                node[0].GetComponent<TileBehaviour>().Destination.Add(node[1]);
                node[0].GetComponent<TileBehaviour>().Destination.Add(node[2]);

                node[1].GetComponent<TileBehaviour>().Destination.Add(node[2]);
                node[1].GetComponent<TileBehaviour>().Destination.Add(node[3]);
                node[1].GetComponent<TileBehaviour>().Destination.Add(node[4]);

                node[2].GetComponent<TileBehaviour>().Destination.Add(node[3]);
                node[2].GetComponent<TileBehaviour>().Destination.Add(node[4]);

                node[3].GetComponent<TileBehaviour>().Destination.Add(node[4]);
                node[3].GetComponent<TileBehaviour>().Destination.Add(node[5]);

                node[4].GetComponent<TileBehaviour>().Destination.Add(node[5]);
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
                                RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                                selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().index = c;
                                selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().Weight = Random.Range(0, 5);
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
                    node[0].GetComponent<TileBehaviour>().Destination.Add(node[1]);

                    node[1].GetComponent<TileBehaviour>().Destination.Add(node[2]);
                    node[1].GetComponent<TileBehaviour>().Destination.Add(node[3]);

                    node[2].GetComponent<TileBehaviour>().Destination.Add(node[3]);
                    node[2].GetComponent<TileBehaviour>().Destination.Add(node[4]);
                    node[2].GetComponent<TileBehaviour>().Destination.Add(node[5]);

                    node[3].GetComponent<TileBehaviour>().Destination.Add(node[4]);
                    node[3].GetComponent<TileBehaviour>().Destination.Add(node[5]);

                    node[4].GetComponent<TileBehaviour>().Destination.Add(node[5]);
                    node[4].GetComponent<TileBehaviour>().Destination.Add(node[6]);

                    node[5].GetComponent<TileBehaviour>().Destination.Add(node[6]);
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
                                    RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                                    selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().index = c;
                                    selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().Weight = Random.Range(0, 5);
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
                        node[0].GetComponent<TileBehaviour>().Destination.Add(node[1]);
                        node[0].GetComponent<TileBehaviour>().Destination.Add(node[2]);

                        node[1].GetComponent<TileBehaviour>().Destination.Add(node[3]);
                        node[1].GetComponent<TileBehaviour>().Destination.Add(node[4]);

                        node[2].GetComponent<TileBehaviour>().Destination.Add(node[3]);
                        node[2].GetComponent<TileBehaviour>().Destination.Add(node[4]);

                        node[3].GetComponent<TileBehaviour>().Destination.Add(node[5]);
                        node[3].GetComponent<TileBehaviour>().Destination.Add(node[6]);

                        node[4].GetComponent<TileBehaviour>().Destination.Add(node[5]);
                        node[4].GetComponent<TileBehaviour>().Destination.Add(node[6]);

                        node[5].GetComponent<TileBehaviour>().Destination.Add(node[7]);

                        node[6].GetComponent<TileBehaviour>().Destination.Add(node[7]);
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
                                        RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                                        selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().index = c;
                                        selectedGrid.transform.gameObject.GetComponent<TileBehaviour>().Weight = Random.Range(0, 5);
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
                            node[0].GetComponent<TileBehaviour>().Destination.Add(node[1]);
                            node[0].GetComponent<TileBehaviour>().Destination.Add(node[2]);
                            node[0].GetComponent<TileBehaviour>().Destination.Add(node[3]);

                            node[1].GetComponent<TileBehaviour>().Destination.Add(node[2]);
                            node[1].GetComponent<TileBehaviour>().Destination.Add(node[4]);

                            node[2].GetComponent<TileBehaviour>().Destination.Add(node[4]);
                            node[2].GetComponent<TileBehaviour>().Destination.Add(node[5]);

                            node[3].GetComponent<TileBehaviour>().Destination.Add(node[2]);
                            node[3].GetComponent<TileBehaviour>().Destination.Add(node[5]);

                            node[4].GetComponent<TileBehaviour>().Destination.Add(node[6]);
                            node[4].GetComponent<TileBehaviour>().Destination.Add(node[7]);

                            node[5].GetComponent<TileBehaviour>().Destination.Add(node[6]);
                            node[5].GetComponent<TileBehaviour>().Destination.Add(node[7]);

                            node[6].GetComponent<TileBehaviour>().Destination.Add(node[8]);

                            node[7].GetComponent<TileBehaviour>().Destination.Add(node[8]);
                        }
    }

    public void SetDestination(int originNode,int destinationNode)
    {
        node[originNode].GetComponent<TileBehaviour>().Destination.Add(node[destinationNode]);
    }
}