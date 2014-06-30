using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AttackGameLevel;
using MiniGameModel;

namespace MiniGame
{
    public class AttackGameManager : MonoBehaviour
    {
        public GUIText timerText, chanceText, scoreText;
        public GameObject result;
        int finishTime, restTime;
        bool isCompleted, isGameOver;

        TrainingPetAttributs petInfo;
        ResultCalculator calculator;

        // Use this for initialization
        void Start()
        {

            petInfo = TrainingPetAttributs.CreateTrainingAtributSingleton();
            calculator = new ResultCalculator();

            if (petInfo.GetTrainingLevel() != 1)
            {
                // Create Director
                AttackLevelManufacturer newManufacturer = new AttackLevelManufacturer();
                // Lets have the Builder class ready
                AttackLevelBuilder levelBuilder = null;

                // Create level
                if (petInfo.GetTrainingLevel() == 2)
                {
                    levelBuilder = new Level2();
                }
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

                chanceText.text = ": " + AttackPlayer.lives.ToString();
                if (AttackPlayer.lives == 0)
                {
                    GameOver();
                }

                scoreText.text = ": " + AttackPlayer.points + "/10";
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

            finishTime = (int)Time.time + 30;
        }

        void GameOver()
        {
            isGameOver = true;
            Instantiate(result, result.transform.position, result.transform.rotation);
            calculator.CalculateAttack(AttackPlayer.lives, AttackPlayer.points);
            audio.enabled = false;
        }
    }
}
