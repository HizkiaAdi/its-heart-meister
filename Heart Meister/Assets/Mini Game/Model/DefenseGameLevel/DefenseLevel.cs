using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DefenseGameLevel
{
    public class DefenseLevel
    {
        List<GameObject> obstacle;

        public List<GameObject> Obstacle
        {
            get { return obstacle; }
            set { obstacle = value; }
        }

        public DefenseLevel()
        {
            obstacle = new List<GameObject>();
        }
    }
}