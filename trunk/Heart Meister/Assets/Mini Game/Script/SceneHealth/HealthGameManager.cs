using UnityEngine;
using System.Collections;

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
            score = 0;
            isGameOver = false;
            isComplete = false;
            playerFall = false;
            //GameEventManager.GameStart += GameStart;
            //GameEventManager.GameOver += GameOver;

            //GameEventManager.TriggerGameStart();
            GameStart();
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

        void GameStart()
        {
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