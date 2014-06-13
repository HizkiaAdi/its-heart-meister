using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public class TrainingPetAttributs
    {
        private TrainingPetAttributs() { }

        private static TrainingPetAttributs singleton;

        public static TrainingPetAttributs CreateTrainingAtributSingleton()
        {
            if(singleton == null)
            {
                singleton = new TrainingPetAttributs();
            }
            return singleton;
        }

        #region Pet's Info

        int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        int attack;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        int defense;

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        int specialAttack;

        public int SpecialAttack
        {
            get { return specialAttack; }
            set { specialAttack = value; }
        }

        int specialDefense;

        public int SpecialDefense
        {
            get { return specialDefense; }
            set { specialDefense = value; }
        }

        int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        #endregion

        public int GetTrainingLevel()
        {
            if (level <= 15)
            {
                return 1;
            }
            else if (level <= 30)
            {
                return 2;
            }
            else return 3;
        }
    }
}