using UnityEngine;
using System.Collections;
using MiniGameModel;

namespace MiniGame
{
    public class LevelOption : MonoBehaviour
    {
        MiniGameLevel gameLevel = MiniGameLevel.CreateMiniGameSingleton();
        // Use this for initialization
        void Start()
        {
            //level = MiniGameLevel.CreateMiniGameSingleton();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            float buttonHeight = Screen.height / 5;
            float buttonWidth = Screen.width / 4;

            if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 5, buttonWidth, buttonHeight), "Level 1 - 15"))
            {
                gameLevel.Level = 1;
                Application.LoadLevel("MiniGameMenu");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 5 + buttonHeight, buttonWidth, buttonHeight), "Level 16 - 30"))
            {
                gameLevel.Level = 2;
                Application.LoadLevel("MiniGameMenu");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 5 + 2 * buttonHeight, buttonWidth, buttonHeight), "Level 31 - 50"))
            {
                gameLevel.Level = 3;
                Application.LoadLevel("MiniGameMenu");
            }
        }
    }
}