using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public class MiniGameResult
    {
        private MiniGameResult() { }

        private static MiniGameResult singleton;

        public static MiniGameResult CreateSingleton()
        {
            if(singleton == null)
            {
                singleton = new MiniGameResult();
            }

            return singleton;
        }

        private int attack;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        private int defense;

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        private int specialAttack;

        public int SpecialAttack
        {
            get { return specialAttack; }
            set { specialAttack = value; }
        }

        private int specialDefense;

        public int SpecialDefense
        {
            get { return specialDefense; }
            set { specialDefense = value; }
        }
    }
}