using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public class TileSolver
    {
        TileData tileData;
        bool[,] flag = new bool[6, 7];

        public TileSolver()
        {
            tileData = TileData.CreateTileSingleton();
        }

        void InitFlag()
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 7; j++)
                    flag[i, j] = false;
        }

        // Check if any matchthree tiles found
        public void SolveTheGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (tileData.GridTile[i,j]  < 6)
                    {
                        InitFlag();
                        CheckMatched(i, j, tileData.GridTile[i, j]);
                        if (MatchCount() >= 3)
                        {
                            DeleteMatched();
                        }
                    }
                }
            }
        }

        // Delete the matchthree tiles
        void DeleteMatched()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (flag[i, j])
                    {
                        tileData.GridTile[i, j] = 99;
                    }
                }
            }
        }

        // Check the number of matched tiles
        int MatchCount()
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

        // DFS to check matched tiles
        void CheckMatched(int i, int j, int value)
        {
            flag[i, j] = true;

            if (i - 1 >= 0 && tileData.GridTile[i - 1, j] == value && !flag[i - 1, j])
                CheckMatched(i - 1, j, value);

            if (j + 1 < 7 && tileData.GridTile[i, j + 1] == value && !flag[i, j + 1])
                CheckMatched(i, j + 1, value);

            if (i + 1 < 6 && tileData.GridTile[i + 1, j] == value && !flag[i + 1, j])
                CheckMatched(i + 1, j, value);

            if (j - 1 >= 0 && tileData.GridTile[i, j - 1] == value && !flag[i, j - 1])
                CheckMatched(i, j - 1, value);
        }
    }
}