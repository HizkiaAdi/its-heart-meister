using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpeedGameLevel;
using MiniGameModel;

namespace MiniGame
{
    public class SpeedGameManager : MonoBehaviour
    {
        public GameObject result;
        public GUIText chanceText, scoreText;
        public static int score, chance;
        bool isGameOver;

        // Use this for initialization
        void Start()
        {
            TrainingPetAttributs petInfo = TrainingPetAttributs.CreateTrainingAtributSingleton();

            if(petInfo.GetTrainingLevel() != 1)
            {
                SpeedLevelManufacturer newManufacturer = new SpeedLevelManufacturer();
                SpeedLevelBuilder levelBuilder = null;

                if (petInfo.GetTrainingLevel() == 2)
                    levelBuilder = new Level2();
                else levelBuilder = new Level3();

                newManufacturer.Construct(levelBuilder);

                foreach(GameObject i in levelBuilder.level.Spawner)
                {
                    Instantiate(i, i.transform.position, i.transform.rotation);
                }
            }

            score = 0;
            chance = 3;
            isGameOver = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameOver)
            {
                scoreText.text = ": " + score + "/30";
                chanceText.text = ": " + chance;

                if (score == 30 || chance <= 0)
                {
                    GameOver();
                }

                RaycastHit2D tapEnemy = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && tapEnemy.collider != null)
                {
                    if (tapEnemy.collider.tag == "Enemy")
                    {
                        Destroy(tapEnemy.collider.gameObject);
                        score++;
                    }

                    else if (tapEnemy.collider.tag == "OtherObject")
                    {
                        Destroy(tapEnemy.collider.gameObject);
                        chance--;
                    }
                }
            }
        }

        void GameOver()
        {
            isGameOver = true;
            audio.enabled = false;
            GameObject tResult = Instantiate(result, result.transform.position, result.transform.rotation) as GameObject;
            tResult.SendMessage("SetAttribut", "speed");
            ResultCalculator calculator = new ResultCalculator();
            calculator.CalculateSpeed(chance, score);
        }
    }
}