using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public class ResultCalculator
    {
        TrainingPetAttributs attribut;
        int trainingResult;

        public ResultCalculator()
        {
            attribut = TrainingPetAttributs.CreateTrainingAtributSingleton();
        }

        public void CalculateAttack(int chance, int score)
        {
            trainingResult = (score / 5) + (score / 10 * (chance / 3));
            attribut.Attack += trainingResult;
        }

        public void CalculateDefense(float distance)
        {
            trainingResult = (int)(distance / 4.35f);
            attribut.Defense += trainingResult;
        }

        public void CalculateSpeed(int chance, int score)
        {
            trainingResult = (score / 15) + (chance / 3);
            attribut.Speed += trainingResult;
        }

        public void CalculateHealth(int score)
        {
            trainingResult = (score - 1) / 3;
            attribut.Health += trainingResult;
        }

        public void CalculateSpecialAttack(float restTime)
        {
            trainingResult = Mathf.CeilToInt(restTime / 5.0f);
            trainingResult = trainingResult > 3 ? 3 : trainingResult;
            attribut.SpecialAttack += trainingResult;
        }

        public void CalculateSpecialDefense(int score, int sDefense)
        {
            trainingResult = score + sDefense > 0 ? 1 : 0;
            attribut.SpecialDefense += trainingResult;
        }
    }
}