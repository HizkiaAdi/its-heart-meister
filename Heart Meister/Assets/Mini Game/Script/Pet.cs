using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MiniGame
{
    public class Pet
    {
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
    }
}