using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DungeonGenerator;

public class TileMap : MonoBehaviour {

    public GameObject grid;
    public Sprite[] mapTile;
    SpriteRenderer mapSprite;
    public int level;
    
	// Use this for initialization
	void Start () 
    {
        InitGridMap();
        //GenerateMap();
        Generate2();
        List<Node> listNode = new List<Node>();
        listNode = BaseMapModel.GetNode();

        foreach (Node i in listNode)
        {
            Debug.Log(i.Destination);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    //public class map
    //{
    //    class Matrix
    //    {
    //        public float[,] matrix;
    //        public int rows;
    //        public int cols;

    //        public Matrix(int rows, int cols)
    //        {
    //            this.matrix = new float[rows, cols];
    //            this.rows = rows;
    //            this.cols = cols;
    //        }

    //        public Matrix(float[,] matrix)
    //        {
    //            this.matrix = matrix;
    //            this.rows = matrix.GetLength(0);
    //            this.cols = matrix.GetLength(1);
    //        }

    //        protected static float[,] Multiply(Matrix matrix, float scalar)
    //        {
    //            int rows = matrix.rows;
    //            int cols = matrix.cols;
    //            float[,] m1 = matrix.matrix;
    //            float[,] m2 = new float[rows, cols];
    //            for (int i = 0; i < rows; ++i)
    //            {
    //                for (int j = 0; j < cols; ++j)
    //                {
    //                    m2[i, j] = m1[i, j] * scalar;
    //                }
    //            }
    //            return m2;
    //        }

    //        protected static float[,] Multiply(Matrix matrix1, Matrix matrix2)
    //        {
    //            int m1rows = matrix1.rows;
    //            int m1cols = matrix1.cols;
    //            int m2rows = matrix2.rows;
    //            int m2cols = matrix2.cols;
    //            if (m1cols != m2rows)
    //            {
    //                throw new ArgumentException();
    //            }
    //            float[,] m1 = matrix1.matrix;
    //            float[,] m2 = matrix2.matrix;
    //            float[,] m3 = new float[m1rows, m2cols];
    //            for (int i = 0; i < m1rows; ++i)
    //            {
    //                for (int j = 0; j < m2cols; ++j)
    //                {
    //                    float sum = 0;
    //                    for (int it = 0; it < m1cols; ++it)
    //                    {
    //                        sum += m1[i, it] * m2[it, j];
    //                    }
    //                    m3[i, j] = sum;
    //                }
    //            }
    //            return m3;
    //        }

    //        public static Matrix operator *(Matrix m, float scalar)
    //        {
    //            return new Matrix(Multiply(m, scalar));
    //        }

    //        public static Matrix operator *(Matrix m1, Matrix m2)
    //        {
    //            return new Matrix(Multiply(m1, m2));
    //        }

    //        public override string ToString()
    //        {
    //            string res = "";
    //            for (int i = 0; i < rows; ++i)
    //            {
    //                if (i > 0)
    //                {
    //                    res += "|";
    //                }
    //                for (int j = 0; j < cols; ++j)
    //                {
    //                    if (j > 0)
    //                    {
    //                        res += ",";
    //                    }
    //                    res += matrix[i, j];
    //                }
    //            }
    //            return "(" + res + ")";
    //        }
    //    }

    //    class Matrix4 : Matrix
    //    {
    //        public static Matrix4 I = NewI();

    //        public Matrix4()
    //            : base(4, 4)
    //        {
    //        }

    //        public Matrix4(float[,] matrix)
    //            : base(matrix)
    //        {
    //            if (rows != 4 || cols != 4)
    //            {
    //                throw new ArgumentException();
    //            }
    //        }

    //        public static Matrix4 NewI()
    //        {
    //            return new Matrix4(new float[,] { 
    //    { 1.0f, 0.0f, 0.0f, 0.0f }, 
    //    { 0.0f, 1.0f, 0.0f, 0.0f }, 
    //    { 0.0f, 0.0f, 1.0f, 0.0f },
    //    { 0.0f, 0.0f, 0.0f, 1.0f } });
    //        }

    //        public static Vector3 operator *(Matrix4 matrix4, Vector3 v)
    //        {
    //            float[,] m = matrix4.matrix;
    //            float w = m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3];
    //            return new Vector3(
    //                (m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3]) / w,
    //                (m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3]) / w,
    //                (m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3]) / w
    //                );
    //        }

    //        public static Matrix4 operator *(Matrix4 mat1, Matrix4 mat2)
    //        {
    //            float[,] m1 = mat1.matrix;
    //            float[,] m2 = mat2.matrix;
    //            float[,] m3 = new float[4, 4];
    //            m3[0, 0] = m1[0, 0] * m2[0, 0] + m1[0, 1] * m2[1, 0] + m1[0, 2] * m2[2, 0] + m1[0, 3] * m2[3, 0];
    //            m3[0, 1] = m1[0, 0] * m2[0, 1] + m1[0, 1] * m2[1, 1] + m1[0, 2] * m2[2, 1] + m1[0, 3] * m2[3, 1];
    //            m3[0, 2] = m1[0, 0] * m2[0, 2] + m1[0, 1] * m2[1, 2] + m1[0, 2] * m2[2, 2] + m1[0, 3] * m2[3, 2];
    //            m3[0, 3] = m1[0, 0] * m2[0, 3] + m1[0, 1] * m2[1, 3] + m1[0, 2] * m2[2, 3] + m1[0, 3] * m2[3, 3];
    //            m3[1, 0] = m1[1, 0] * m2[0, 0] + m1[1, 1] * m2[1, 0] + m1[1, 2] * m2[2, 0] + m1[1, 3] * m2[3, 0];
    //            m3[1, 1] = m1[1, 0] * m2[0, 1] + m1[1, 1] * m2[1, 1] + m1[1, 2] * m2[2, 1] + m1[1, 3] * m2[3, 1];
    //            m3[1, 2] = m1[1, 0] * m2[0, 2] + m1[1, 1] * m2[1, 2] + m1[1, 2] * m2[2, 2] + m1[1, 3] * m2[3, 2];
    //            m3[1, 3] = m1[1, 0] * m2[0, 3] + m1[1, 1] * m2[1, 3] + m1[1, 2] * m2[2, 3] + m1[1, 3] * m2[3, 3];
    //            m3[2, 0] = m1[2, 0] * m2[0, 0] + m1[2, 1] * m2[1, 0] + m1[2, 2] * m2[2, 0] + m1[2, 3] * m2[3, 0];
    //            m3[2, 1] = m1[2, 0] * m2[0, 1] + m1[2, 1] * m2[1, 1] + m1[2, 2] * m2[2, 1] + m1[2, 3] * m2[3, 1];
    //            m3[2, 2] = m1[2, 0] * m2[0, 2] + m1[2, 1] * m2[1, 2] + m1[2, 2] * m2[2, 2] + m1[2, 3] * m2[3, 2];
    //            m3[2, 3] = m1[2, 0] * m2[0, 3] + m1[2, 1] * m2[1, 3] + m1[2, 2] * m2[2, 3] + m1[2, 3] * m2[3, 3];
    //            m3[3, 0] = m1[3, 0] * m2[0, 0] + m1[3, 1] * m2[1, 0] + m1[3, 2] * m2[2, 0] + m1[3, 3] * m2[3, 0];
    //            m3[3, 1] = m1[3, 0] * m2[0, 1] + m1[3, 1] * m2[1, 1] + m1[3, 2] * m2[2, 1] + m1[3, 3] * m2[3, 1];
    //            m3[3, 2] = m1[3, 0] * m2[0, 2] + m1[3, 1] * m2[1, 2] + m1[3, 2] * m2[2, 2] + m1[3, 3] * m2[3, 2];
    //            m3[3, 3] = m1[3, 0] * m2[0, 3] + m1[3, 1] * m2[1, 3] + m1[3, 2] * m2[2, 3] + m1[3, 3] * m2[3, 3];
    //            return new Matrix4(m3);
    //        }

    //        public static Matrix4 operator *(Matrix4 m, float scalar)
    //        {
    //            return new Matrix4(Multiply(m, scalar));
    //        }
    //    }
    //}

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

    void GenerateMap()
    {
        int[,] gridTile= new int[7,7];
        float x = -3, y = 3;
        for (int i = 0; i < 7; i++)
        {
            x = -3;
            for (int j = 0; j < 7; j++)
            {
                int tileNumber = Random.Range(0, 2);               
                RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);
                
                //generate disini
                if (selectedGrid.collider != null)
                {
                    mapSprite = selectedGrid.collider.gameObject.GetComponent<SpriteRenderer>();
                    mapSprite.sprite = mapTile[tileNumber];
                }
                x++;
            }
            y--;
        }
    }

    void Generate2()
    {
        level = 5;
        int[,] gridTile = new int[7, 7];
        float x = -3, y = 3;

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
                    }
                    x+=1.4f;
                }
                y-=1.2f;
            }
        } else
            if (level > 10 && level <= 20)
            {
                for (int i = 0; i < 7; i++)
                {
                    x = -3;
                    for (int j = 0; j < 7; j++)
                    {
                        if (BaseMapModel.GetGridStatus2(i, j) == 1)
                        {
                            int tileNumber = Random.Range(0, 2);
                            RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);

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
                        }
                        x++;
                    }
                    y--;
                }
            }else
                if (level > 20 && level <=30)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        x = -3;
                        for (int j = 0; j < 7; j++)
                        {
                            if (BaseMapModel.GetGridStatus3(i, j) == 1)
                            {
                                int tileNumber = Random.Range(0, 2);
                                RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);

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
                            }
                            x++;
                        }
                        y--;
                    }
                }else
                    if (level > 30 && level <= 40)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            x = -3;
                            for (int j = 0; j < 7; j++)
                            {
                                if (BaseMapModel.GetGridStatus4(i, j) == 1)
                                {
                                    int tileNumber = Random.Range(0, 2);
                                    RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);

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
                                }
                                x++;
                            }
                            y--;
                        }
                    }else
                        if (level > 40 && level <= 50)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                x = -3;
                                for (int j = 0; j < 7; j++)
                                {
                                    if (BaseMapModel.GetGridStatus5(i, j) == 1)
                                    {
                                        int tileNumber = Random.Range(0, 2);
                                        RaycastHit2D selectedGrid = Physics2D.Raycast(new Vector2(x, y), Vector2.zero);

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
                                    }
                                    x++;
                                }
                                y--;
                            }
                        }
    }
}