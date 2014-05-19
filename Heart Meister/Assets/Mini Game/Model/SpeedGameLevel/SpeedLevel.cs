using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpeedGameLevel
{
    public class SpeedLevel
    {
        List<GameObject> spawner;

        public List<GameObject> Spawner
        {
            get { return spawner; }
            set { spawner = value; }
        }

        public SpeedLevel()
        {
            spawner = new List<GameObject>();
        }
    }
}