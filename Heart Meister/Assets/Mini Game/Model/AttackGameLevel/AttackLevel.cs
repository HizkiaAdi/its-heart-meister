using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AttackGameLevel
{
    public class AttackLevel
    {
        List<GameObject> obstacle;

        public List<GameObject> Obstacle
        {
            get { return obstacle; }
            set { obstacle = value; }
        }

        public List<GameObject> CreateLevel()
        {
            return obstacle;
        }
        
        public AttackLevel()
        {
            obstacle = new List<GameObject>();
        }
    }
}