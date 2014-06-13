using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public class TileData
    {
        private TileData() { }

        private static TileData singleton;

        public static TileData CreateTileSingleton()
        {
            if(singleton==null)
            {
                singleton = new TileData();
            }
            return singleton;
        }

        float[] xPos = { -7.3f, -6.0f, -4.7f, -3.4f, -2.1f, -0.85f, 0.4f };
        float[] yPos = { 2.18f, 0.9f, -0.35f, -1.6f, -2.9f, -4.2f };
        int[,] gridTile = new int[6, 7];
        bool[,] flag = new bool[6, 7];

        public int[,] GridTile
        {
            get { return gridTile; }
            set { gridTile = value; }
        }

        // Generate grid number
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

        // Get Tile index based on it's position
        public Vector2 GetTileIndex(float x, float y)
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

        // Get Tile position based on it's index
        public Vector2 GetPosition(int i, int j)
        {
            return new Vector2(xPos[i], yPos[j]);
        }
    }
}