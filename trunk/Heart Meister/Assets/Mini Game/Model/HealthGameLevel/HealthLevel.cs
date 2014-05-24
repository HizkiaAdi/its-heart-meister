using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HealthGameLevel
{
    public class HealthLevel
    {
        List<GameObject> obstacle;

        public List<GameObject> Obstacle
        {
            get { return obstacle; }
            set { obstacle = value; }
        }

        public HealthLevel()
        {
            obstacle = new List<GameObject>();
        }
    }
}