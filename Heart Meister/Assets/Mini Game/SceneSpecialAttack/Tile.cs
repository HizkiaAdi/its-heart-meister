using UnityEngine;
using System.Collections;

public class Tile {

    static readonly float[] xPos = { -7.3f, -6.0f, -4.7f, -3.4f, -2.1f, -0.85f, 0.4f };
    static readonly float[] yPos = { 2.18f, 0.9f, -0.35f, -1.6f, -2.9f, -4.2f };
    static int[,] gridTile = new int[6, 7];
    static bool[,] flag = new bool[6, 7];

    public Tile()
    {
        InitGrid();
    }

    public void InitGrid()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                gridTile[i, j] = Random.Range(0, 16);
            }
        }
    }

    public static int GetTileNumber(int i, int j)
    {
        return gridTile[i, j];
    }

    public static void SetTileNumber(int i, int j, int value)
    {
        gridTile[i, j] = value;
    }

    public static Vector2 GetTileIndex(float x, float y)
    {
        Vector2 tileIndex = new Vector2(0, 0);

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (xPos[j] == x && yPos[i] == y)
                    tileIndex = new Vector2(i, j);
            }
        }
        return tileIndex;
    }

    public static Vector2 GetPosition(int i, int j)
    {
        return new Vector2(xPos[i], yPos[j]);
    }

    public static void SolveTheGrid()
    {
        //InitMatchedGrid();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (gridTile[i, j] < 6)
                {
                    InitFlag();
                    CheckMatched(i, j, gridTile[i, j]);
                    if (MatchCount() >= 3)
                        DeleteMatched();
                }
            }
        }
    }

    static void DeleteMatched()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (flag[i, j])
                    gridTile[i, j] = 99;
            }
        }
    }

    static int MatchCount()
    {
        int match = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (flag[i, j])
                    match++;
            }
        }

        return match;
    }

    static void CheckMatched(int i, int j, int value)
    {
        flag[i, j] = true;

        if (i - 1 >= 0 && gridTile[i - 1, j] == value && !flag[i - 1, j])
            CheckMatched(i - 1, j, value);

        if (j + 1 < 7 && gridTile[i, j + 1] == value && !flag[i, j + 1])
            CheckMatched(i, j + 1, value);

        if (i + 1 < 6 && gridTile[i + 1, j] == value && !flag[i + 1, j])
            CheckMatched(i + 1, j, value);

        if (j - 1 >= 0 && gridTile[i, j - 1] == value && !flag[i, j - 1])
            CheckMatched(i, j - 1, value);
    }

    static void InitFlag()
    {
        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 7; j++)
                flag[i, j] = false;
    }
}
