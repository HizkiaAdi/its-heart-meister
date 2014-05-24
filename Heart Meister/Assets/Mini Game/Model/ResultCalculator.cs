using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public class ResultCalculator
    {
        public ResultCalculator()
        {
            MiniGameResult result = MiniGameResult.CreateSingleton();

            result.Attack = 0;
            result.Defense = 0;
            result.Health = 0;
            result.SpecialAttack = 0;
            result.SpecialDefense = 0;
            result.Speed = 0;
        }

        public void CalculateAttack(int chance, int score)
        {

        }

        public void CalculateDefense()
        {

        }

        public void CalculateSpeed(int chance, int score)
        {

        }

        public void CalculateHealth(int score)
        {

        }

        public void CalculateSpecialAttack(int restTime)
        {

        }

        public void CalculateSpecialDefense(int score, int sDefense)
        {

        }
    }
}