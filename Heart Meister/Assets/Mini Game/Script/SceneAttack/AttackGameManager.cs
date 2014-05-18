using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AttackGameLevel;
using MiniGameModel;

namespace MiniGame
{
    public class AttackGameManager : MonoBehaviour
    {
        public GUIText completeText, failedText, timerText, chanceText, scoreText;
        int finishTime, restTime;
        bool isCompleted, isGameOver;

        // Use this for initialization
        void Start()
        {
            MiniGameLevel level = MiniGameLevel.CreateMiniGameSingleton();

            if (level.Level != 1)
            {
                // Create Director
                AttackLevelManufacturer newManufacturer = new AttackLevelManufacturer();
                // Lets have the Builder class ready
                AttackLevelBuilder levelBuilder = null;

                // Create level
                if (level.Level == 2)
                    levelBuilder = new Level2();
                else levelBuilder = new Level3();

                newManufacturer.Construct(levelBuilder);

                foreach (GameObject i in levelBuilder.Level.Obstacle)
                {
                    Instantiate(i, i.transform.position, i.transform.rotation);
                }
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
