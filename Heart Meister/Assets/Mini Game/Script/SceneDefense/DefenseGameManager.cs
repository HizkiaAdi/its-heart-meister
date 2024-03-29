﻿using UnityEngine;
using System.Collections;
using DefenseGameLevel;
using MiniGameModel;

namespace MiniGame
{
    public class DefenseGameManager : MonoBehaviour
    {
        public GameObject result;
        public static bool isGameOver;
        bool flag;

        TrainingPetAttributs petInfo;
        ResultCalculator calculator;
        // Use this for initialization
        void Start()
        {
            flag = false;
            isGameOver = false;
            petInfo = TrainingPetAttributs.CreateTrainingAtributSingleton();
            calculator = new ResultCalculator();

            if(petInfo.GetTrainingLevel() != 1)
            {
                DefenseLevelManufacturer newManufacturer = new DefenseLevelManufacturer();
                DefenseLevelBuilder levelBuilder = null;

                if (petInfo.GetTrainingLevel() == 2)
                    levelBuilder = new Level2();
                else levelBuilder = new Level3();

                newManufacturer.Construct(levelBuilder);

                foreach(GameObject i in levelBuilder.Level.Obstacle)
                {
                    Instantiate(i, i.transform.position, i.transform.rotation);
                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (isGameOver && !flag)
            {
                flag = true;
                audio.enabled = false;
                GameObject tResult = Instantiate(result, result.transform.position, result.transform.rotation) as GameObject;
                tResult.SendMessage("SetAttribut", "defense");
                calculator.CalculateDefense(DefensePlayer.maxPos - DefensePlayer.startPos);
            }
        }
    }
}
