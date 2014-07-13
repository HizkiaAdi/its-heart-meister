using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniGameModel;
using HealthGameLevel;

namespace MiniGame
{
    public class HealthGameManager : MonoBehaviour
    {
        public GUIText scoreText;
        public GameObject result;
        public static int score;
        bool isComplete, isGameOver, flag;
        public static bool playerFall;

        TrainingPetAttributs petInfo;
        ResultCalculator calculator;

        // Use this for initialization
        void Start()
        {
            petInfo = TrainingPetAttributs.CreateTrainingAtributSingleton();
            calculator = new ResultCalculator();

            HealthlevelManufacturer newManufacturer = new HealthlevelManufacturer();
            HealthLevelBuilder levelBuilder = null;

            switch(petInfo.GetTrainingLevel())
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

            if ((score == 10 || playerFall) && !flag)
            {
                flag = true;
                isGameOver = true;
                GameOver();
            }
        }

        void Init()
        {
            score = 0;
            isGameOver = false;
            isComplete = false;
            playerFall = false;
            flag = false;

        }

        void GameOver()
        {
            audio.enabled = false;
            GameObject tResult = Instantiate(result, result.transform.position, result.transform.rotation) as GameObject;
            tResult.SendMessage("SetAttribut", "health");
            calculator.CalculateHealth(score);
        }
    }
}