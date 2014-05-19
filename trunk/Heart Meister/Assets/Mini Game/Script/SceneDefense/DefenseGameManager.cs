using UnityEngine;
using System.Collections;
using DefenseGameLevel;
using MiniGameModel;

namespace MiniGame
{
    public class DefenseGameManager : MonoBehaviour
    {

        public GUIText completeText, failedText;
        public static bool isGameOver, isComplete;
        // Use this for initialization
        void Start()
        {
            MiniGameLevel level = MiniGameLevel.CreateMiniGameSingleton();

            if(level.Level!=1)
            {
                DefenseLevelManufacturer newManufacturer = new DefenseLevelManufacturer();
                DefenseLevelBuilder levelBuilder = null;

                if (level.Level == 2)
                    levelBuilder = new Level2();
                else levelBuilder = new Level3();

                newManufacturer.Construct(levelBuilder);

                foreach(GameObject i in levelBuilder.Level.Obstacle)
                {
                    Instantiate(i, i.transform.position, i.transform.rotation);
                }
            }

            GameStart();
        }

        // Update is called once per frame
        void Update()
        {
            if (isGameOver)
            {
                GameOver();
            }
        }

        void GameStart()
        {
            isGameOver = false;
            isComplete = false;
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
