using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SDefenseGameLevel
{
    public class SDefenseLevel
    {
        List<GameObject> obstacle;

        public List<GameObject> Obstacle
        {
            get { return obstacle; }
            set { obstacle = value; }
        }

        public SDefenseLevel()
        {
            obstacle = new List<GameObject>();
        }
    }
}