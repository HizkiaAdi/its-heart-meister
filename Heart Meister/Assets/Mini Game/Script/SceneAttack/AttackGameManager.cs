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
        public GameObject result, tutorial;
        int finishTime, restTime;
        bool isGameOver;

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

            isGameOver = false;
            finishTime = (int)Time.time + 30;
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
                    GameOver();
                }
            }
        }
        
        
        void GameOver()
        {
            isGameOver = true;
            GameObject tResult = Instantiate(result, result.transform.position, result.transform.rotation) as GameObject;
            tResult.SendMessage("SetAttribut", "attack");
            calculator.CalculateAttack(AttackPlayer.lives, AttackPlayer.points);
            audio.enabled = false;
        }

    }
}
