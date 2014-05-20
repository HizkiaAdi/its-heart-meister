using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAttackGameLevel
{
    public class SAttackLevel
    {
        List<GameObject> obstacle;

        public List<GameObject> Obstacle
        {
            get { return obstacle; }
            set { obstacle = value; }
        }

        public SAttackLevel()
        {
            obstacle = new List<GameObject>();
        }
    }
}