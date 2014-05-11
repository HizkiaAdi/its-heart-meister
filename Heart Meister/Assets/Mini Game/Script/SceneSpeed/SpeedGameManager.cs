using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpeedGameManager : MonoBehaviour
    {

        public GUIText completeText, failedText, chanceText, scoreText;
        public static int score, chance;
        bool isComplete, isGameOver;
        // Use this for initialization
        void Start()
        {
            completeText.enabled = false;
            failedText.enabled = false;
            score = 0;
            chance = 3;
            isComplete = false;
            isGameOver = false;

            //GameEventManager.GameOver += GameOver;
        }

        // Update is called once per frame
        void Update()
        {
            if (score < 30)
            {
                scoreText.text = score.ToString() + "/30";
            }
            else
            {
                scoreText.text = "30/30";
                isComplete = true;
            }

            if (chance > 0)
                chanceText.text = "Chance: " + chance.ToString();
            else chanceText.text = "Chance: 0";

            if (score == 30 || chance <= 0)
            {
                isGameOver = true;
                GameOver();
                //GameEventManager.TriggerGameOver();
            }

            RaycastHit2D tapEnemy = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (Input.GetMouseButtonUp(0) && tapEnemy.collider != null)
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