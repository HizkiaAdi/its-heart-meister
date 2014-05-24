using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniGameModel;
using HealthGameLevel;

namespace MiniGame
{
    public class HealthGameManager : MonoBehaviour
    {
        public GUIText completeText, failedText, scoreText;
        public static int score;
        bool isComplete, isGameOver;
        public static bool playerFall;

        // Use this for initialization
        void Start()
        {
            MiniGameLevel level = MiniGameLevel.CreateMiniGameSingleton();

            HealthlevelManufacturer newManufacturer = new HealthlevelManufacturer();
            HealthLevelBuilder levelBuilder = null;

            switch(level.Level)
            {
                case 1: levelBuilder = new Level1(); break;
                case 2: levelBuilder = new Level2(); break;
                case 3: levelBuilder = new Level3(); break;
            }

            newManufacturer.Construct(levelBuilder);
            foreach(GameObject i in levelBuilder.level.Obstacle)
            {
                Instantiate(i, i.transform.position, i.transform.rotation);
            }

            Init();
        }

        // Update is called once per frame
        void Update()
        {
            if (score < 10)
            {
                scoreText.text = score.ToString() + "/10";
            }
            else
            {
                scoreText.text = "10/10";
                isComplete = true;
            }

            if (score == 10 || playerFall)
            {
                isGameOver = true;
                //GameEventManager.TriggerGameOver();
                GameOver();
            }
        }

        void Init()
        {
            score = 0;
            isGameOver = false;
            isComplete = false;
            playerFall = false;

            completeText.enabled = false;
            failedText.enabled = false;
        }

        void GameOver()
        {
            if (isComplete)
            {
                completeText.enabled = true;
            }
            else
            {
                failedText.enabled = true;
            }
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