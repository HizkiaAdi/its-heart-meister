using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniGameModel;
using SAttackGameLevel;

namespace MiniGame
{
    public class SpecialAttackGameManager : MonoBehaviour
    {

        public GUIText progressText, timeText;
        public GameObject result, completeBoard;
        public GameObject target, specialAttack;
        public static int progress;
        int finishTime, restTime;
        bool isGameOver, attackRelease, flag;

        ResultCalculator calculator;

        // Use this for initialization
        void Start()
        {
            calculator = new ResultCalculator();

            isGameOver = false;
            flag = false;
            attackRelease = false;
            progress = 0;
            finishTime = (int)Time.time + 60;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameOver)
            {
                UpdateTime();
                progressText.text = ": " + (progress * 100 / 30).ToString() + "%";
                if (progress >= 30)
                {
                    Instantiate(completeBoard);
                    progressText.text = ": 100%";
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
                GameOver();
            }
        }

        void GameOver()
        {
            isGameOver = true;
            
            if(!flag)
            {
                flag = true;
                audio.enabled = false;
                GameObject tResult = Instantiate(result, result.transform.position, result.transform.rotation) as GameObject;
                tResult.SendMessage("SetAttribut", "special attack");
                calculator.CalculateSpecialAttack(float.Parse(restTime.ToString()));
            }
        }
    }
}