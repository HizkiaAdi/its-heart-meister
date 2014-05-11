using UnityEngine;
using System.Collections;
using MiniGameModel;

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
            float buttonSize = Screen.height / 10;
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
