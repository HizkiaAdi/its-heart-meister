using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AttackGameLevel;

namespace MiniGame
{
    public class AttackGameManager : MonoBehaviour
    {

        public GameObject[] target;
        public GUIText completeText, failedText, timerText, chanceText, scoreText;
        int finishTime, restTime;
        bool isCompleted, isGameOver;

        // Use this for initialization
        void Start()
        {
            //Instantiate(Resources.Load("/MiniGamePrefabs/Obstacle1") as GameObject);
            Object o = Resources.Load("/MiniGamePrefabs/Ball");
            if (o == null) Debug.Log("Load failed");

            // Create Director
            AttackLevelManufacturer newManufacturer = new AttackLevelManufacturer();
            // Lets have the Builder class ready
            AttackLevelBuilder levelBuilder = null;

            // Create level
            
            levelBuilder = new AttackLevel2();
            newManufacturer.Construct(levelBuilder);
            List<GameObject> obstacles = levelBuilder.Level.CreateLevel();

            foreach(GameObject i in obstacles)
            {
                Instantiate(i, i.transform.position, i.transform.rotation);
            }

            GameStart();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameOver)
            {
                restTime = finishTime - (int)Time.time;
                
                if (restTime >= 0)
                {
                    timerText.text = restTime.ToString();
                }
                else
                {
                    timerText.text = "0";
                    GameOver();
                }

                chanceText.text = "Chance: " + AttackPlayer.lives.ToString();
                if (AttackPlayer.lives == 0)
                {
                    GameOver();
                }

                scoreText.text = AttackPlayer.points + "/10";
                if (AttackPlayer.points == 10)
                {
                    isCompleted = true;
                    GameOver();
                }
            }
        }

        void GameStart()
        {
            isCompleted = false;
            isGameOver = false;
            completeText.enabled = false;
            failedText.enabled = false;

            finishTime = (int)Time.time + 30;
        }

        void GameOver()
        {
            isGameOver = true;
            if (isCompleted)
                completeText.enabled = true;
            else failedText.enabled = true;
        }

        void OnGUI()
        {
            float buttonSize = Screen.height / 9;
            if (isGameOver)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - buttonSize / 2, Screen.height / 2, buttonSize, buttonSize), "OK"))
                {
                    Application.LoadLevel("Home");
                }
            }
        }
    }
}
