using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SDefenseGameLevel;
using MiniGameModel;

namespace MiniGame
{
    public class SpecialDefenseGameManager : MonoBehaviour
    {

        public GameObject ballObject;
        Transform ball;
        public static int specialDefense;
        public GUIText completetext, failedText, scoreText, magicDefenseText;
        bool isComplete, isGameOver, releaseBall;
        float delay, maxDelay;
        int playerScore, enemyScore;

        // Use this for initialization
        void Start()
        {
            MiniGameLevel level = MiniGameLevel.CreateMiniGameSingleton();

            if (level.Level != 1)
            {
                SDefenseLevelManufacturer newManufacturer = new SDefenseLevelManufacturer();
                SDefenseLevelBuilder levelBuilder = null;

                if (level.Level == 2)
                    levelBuilder = new Level2();
                else
                    levelBuilder = new Level3();

                newManufacturer.Construct(levelBuilder);

                foreach (GameObject i in levelBuilder.level.Obstacle)
                {
                    Instantiate(i, i.transform.position, i.transform.rotation);
                }
            }

            Init();
        }

        // Update is called once per frame
        void Update()
        {
            if (releaseBall)
                ReleaseBall(delay += Time.deltaTime);

            CheckBallPosition();

            scoreText.text = playerScore.ToString() + " - " + enemyScore.ToString();
            magicDefenseText.text = "S. Defense: " + specialDefense.ToString();

            if (playerScore >= 2)
            {
                isComplete = true;
                GameOver();
            }

            if (enemyScore >= 2)
            {
                GameOver();
            }
        }

        void ReleaseBall(float time)
        {
            if (time >= maxDelay)
            {
                Instantiate(ballObject, new Vector2(0f, 0f), transform.rotation);
                releaseBall = false;
                delay = 0f;
            }
        }

        void CheckBallPosition()
        {
            if (GameObject.FindWithTag("Ball"))
            {
                ball = GameObject.FindWithTag("Ball").transform;

                if (ball.localPosition.x < -8)
                {
                    enemyScore++;
                    releaseBall = true;
                }

                if (ball.localPosition.x > 8)
                {
                    playerScore++;
                    releaseBall = true;
                }
            }
        }

        void Init()
        {
            playerScore = enemyScore = 0;
            specialDefense = 3;
            isComplete = isGameOver = false;
            releaseBall = true;
            completetext.enabled = failedText.enabled = false;
            delay = 0f;
            maxDelay = 1.0f;
        }

        void GameOver()
        {
            isGameOver = true;
            if (isComplete)
            {
                completetext.enabled = true;
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