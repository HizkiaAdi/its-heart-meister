using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SDefenseGameLevel;
using MiniGameModel;

namespace MiniGame
{
    public class SpecialDefenseGameManager : MonoBehaviour
    {

        public GameObject ballObject, result;
        Transform ball;
        public static int specialDefense;
        public GUIText scoreText, magicDefenseText;
        bool isGameOver, releaseBall;
        float delay, maxDelay;
        int playerScore, enemyScore;

        // Use this for initialization
        void Start()
        {
            TrainingPetAttributs petInfo = TrainingPetAttributs.CreateTrainingAtributSingleton();

            if (petInfo.GetTrainingLevel() != 1)
            {
                SDefenseLevelManufacturer newManufacturer = new SDefenseLevelManufacturer();
                SDefenseLevelBuilder levelBuilder = null;

                if (petInfo.GetTrainingLevel() == 2)
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
            if (!isGameOver)
            {
                if (releaseBall)
                    ReleaseBall(delay += Time.deltaTime);

                CheckBallPosition();

                scoreText.text = playerScore.ToString() + " - " + enemyScore.ToString();
                magicDefenseText.text = "S. Defense: " + specialDefense.ToString();

                if (playerScore >= 2 || enemyScore >= 2)
                {
                    GameOver();
                }
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
            isGameOver = false;
            releaseBall = true;
            delay = 0f;
            maxDelay = 1.0f;
        }

        void GameOver()
        {
            isGameOver = true;
            Instantiate(result, result.transform.position, result.transform.rotation);
            ResultCalculator calculator = new ResultCalculator();
            calculator.CalculateSpecialDefense(playerScore, specialDefense);
        }
    }
}