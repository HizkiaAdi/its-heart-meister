using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniGameModel;

namespace MiniGame
{
    public class LevelOption : MonoBehaviour
    {
        //MiniGameLevel gameLevel = MiniGameLevel.CreateMiniGameSingleton();
        TrainingPetAttributs petInfo = TrainingPetAttributs.CreateTrainingAtributSingleton();
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public string level = "0", attack = "0", defense = "0", speed = "0", health = "0", sAttack = "0", sDefense = "0";
        void OnGUI()
        {
            float buttonHeight = Screen.height / 5;
            float buttonWidth = Screen.width / 4;
            /*
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
            */

            float textHeight = Screen.height / 10;
            float textWidth = Screen.width / 10;
            float xPos=Screen.width/2;
            float yPos = (Screen.height / 10) * 2.6f;

            level = GUI.TextField(new Rect(xPos, yPos, textWidth, textHeight), level);
            yPos += textHeight;

            attack = GUI.TextField(new Rect(xPos, yPos, textWidth, textHeight), attack);
            yPos += textHeight;

            defense = GUI.TextField(new Rect(xPos, yPos, textWidth, textHeight), defense);
            yPos += textHeight;

            speed = GUI.TextField(new Rect(xPos, yPos, textWidth, textHeight), speed);
            yPos += textHeight;

            health = GUI.TextField(new Rect(xPos, yPos, textWidth, textHeight), health);
            yPos += textHeight;

            sAttack = GUI.TextField(new Rect(xPos, yPos, textWidth, textHeight), sAttack);
            yPos += textHeight;

            sDefense = GUI.TextField(new Rect(xPos, yPos, textWidth, textHeight), sDefense);
            yPos += textHeight;

            if(GUI.Button(new Rect(Screen.width- Screen.width/8.5f,Screen.height- Screen.height/9,Screen.width/8.5f,Screen.height/9),"Next"))
            {
                petInfo.Level = int.Parse(level);
                petInfo.Attack = int.Parse(attack);
                petInfo.Defense = int.Parse(defense);
                petInfo.Speed = int.Parse(speed);
                petInfo.SpecialAttack = int.Parse(sAttack);
                petInfo.SpecialDefense = int.Parse(sDefense);
                petInfo.Health = int.Parse(health);

                /*Debug.Log(petInfo.Level);
                Debug.Log(petInfo.Attack);
                Debug.Log(petInfo.Defense);
                Debug.Log(petInfo.Speed);
                Debug.Log(petInfo.SpecialAttack);
                Debug.Log(petInfo.SpecialDefense);
                Debug.Log(petInfo.Health);*/
                Application.LoadLevel("MiniGameMenu");
            }
        }
    }
}