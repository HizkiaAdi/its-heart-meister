using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpecialAttackGameManager : MonoBehaviour
    {

        public GUIText progressText, timeText, completeText, failedText;
        public GameObject target, specialAttack;
        public static int progress;
        int finishTime, restTime;
        bool isGameOver, isComplete, attackRelease;

        // Use this for initialization
        void Start()
        {
            isGameOver = isComplete = false;
            attackRelease = false;
            completeText.enabled = failedText.enabled = false;
            progress = 0;
            finishTime = (int)Time.time + 60;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameOver)
            {
                UpdateTime();
                progressText.text = "S. Attack: " + (progress * 100 / 30).ToString() + "%";
                if (progress >= 30)
                {
                    progressText.text = "S. Attack: 100%";
                    if (!attackRelease)
                    {
                        Instantiate(specialAttack, new Vector2(4.5f, -2.5f), transform.rotation);
                        attackRelease = true;
                    }

                    CheckTarget();
                }
            }
        }

        void UpdateTime()
        {
            restTime = finishTime - (int)Time.time;
            if (restTime > 0)
            {
                timeText.text = restTime.ToString();
            }
            else
            {
                timeText.text = "0";
                GameOver();
            }
        }

        void CheckTarget()
        {
            RaycastHit2D targetPoint = Physics2D.Raycast(new Vector2(4.3f, 4.2f), Vector2.zero);

            if (targetPoint.collider == null)
            {
                isComplete = true;
                GameOver();
            }
        }

        void GameOver()
        {
            isGameOver = true;
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