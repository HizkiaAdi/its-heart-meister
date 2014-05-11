using UnityEngine;
using System.Collections;

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
            playerScore = enemyScore = 0;
            specialDefense = 3;
            isComplete = isGameOver = false;
            releaseBall = true;
            completetext.enabled = failedText.enabled = false;
            delay = 0f;
            maxDelay = 1.0f;
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