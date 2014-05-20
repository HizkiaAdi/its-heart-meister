using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniGameModel;
using SAttackGameLevel;

namespace MiniGame
{
    public class MatchThree : MonoBehaviour
    {

        public GameObject grid;
        public Sprite[] spriteTile;
        Vector2 selectedGrid;
        public GUIText checkGrid;
        int tileNow;
        SpriteRenderer tileSprite;

        // Use this for initialization
        void Start()
        {
            Tile tiles = new Tile();

            GenerateGrid();
            InitTile();
            UpdatePresentTile();
            Tile.SolveTheGrid();
            UpdateGrid();

            SAttackLevelManufacturer newManufacturer = new SAttackLevelManufacturer();
            SAttackLevelBuilder levelBuilder = null;

            levelBuilder = new Level2();

            newManufacturer.Construct(levelBuilder);

            foreach(GameObject i in levelBuilder.level.Obstacle)
            {
                int x = Random.Range(0, 7);
                int y = Random.Range(0, 6);
                Vector2 pos = Tile.GetPosition(x, y);

                Instantiate(i, new Vector3(pos.x, pos.y, -1), i.transform.rotation);
                Tile.SetTileNumber(y, x, 99);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                Debug.Log(click.collider.tag);
                if (click.collider != null && click.collider.tag == "Grid")
                {
                    selectedGrid = click.collider.gameObject.transform.position;

                    tileSprite = click.collider.gameObject.GetComponent<SpriteRenderer>();

                    if (tileSprite.sprite == null)
                    {
                        Debug.Log("sprite = null");
                        tileSprite.sprite = spriteTile[tileNow];

                        Vector2 tileIndex = Tile.GetTileIndex(selectedGrid.x, selectedGrid.y);
                        Tile.SetTileNumber((int)tileIndex.x, (int)tileIndex.y, tileNow);

                        checkGrid.text = "";
                        UpdatePresentTile();
                        Tile.SolveTheGrid();
                        UpdateGrid();
                    }
                    else Debug.Log("sprite != null");
                }
            }
        }

        void GenerateGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Vector2 gridPosition = Tile.GetPosition(j, i);
                    Instantiate(grid, gridPosition, transform.rotation);
                }
            }
        }

        void InitTile()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int tileNumber = Tile.GetTileNumber(i, j);
                    checkGrid.text += tileNumber.ToString() + " ";

                    Vector2 tilePosition = Tile.GetPosition(j, i);
                    RaycastHit2D selectedTile = Physics2D.Raycast(tilePosition, Vector2.zero);
                    tileSprite = selectedTile.collider.gameObject.GetComponent<SpriteRenderer>();

                    if (tileNumber < 6)
                    {
                        tileSprite.sprite = spriteTile[tileNumber];
                    }
                    else tileSprite.sprite = null;
                }
                checkGrid.text += "\n";
            }
        }

        void UpdateGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int tileNumber = Tile.GetTileNumber(i, j);
                    checkGrid.text += tileNumber.ToString() + " ";

                    if (tileNumber == 99)
                    {
                        RaycastHit2D selectedTile = Physics2D.Raycast(Tile.GetPosition(j, i), Vector2.zero);

                        if (selectedTile.collider != null && selectedTile.collider.tag == "Grid")
                        {
                            tileSprite = selectedTile.collider.gameObject.GetComponent<SpriteRenderer>();
                            if (tileSprite.sprite != null)
                            {
                                SpecialAttackGameManager.progress++;

                                tileSprite.sprite = null;
                            }
                        }
                    }
                }
                checkGrid.text += "\n";
            }
        }

        void UpdatePresentTile()
        {
            tileNow = Random.Range(0, 6);

            Vector2 position = new Vector2(-3.4f, 3.7f);
            RaycastHit2D presentTile = Physics2D.Raycast(position, Vector2.zero);
            if (presentTile.collider != null && presentTile.collider.tag == "Tile")
            {
                tileSprite = presentTile.collider.gameObject.GetComponent<SpriteRenderer>();
                tileSprite.sprite = spriteTile[tileNow];
            }
        }
    }
}