using UnityEngine;
using System.Collections;

namespace SpeedGameLevel
{
    public abstract class SpeedLevelBuilder
    {
        public virtual void CreateSpawner() { }

        public SpeedLevel level;

        /*public SpeedLevel Level
        {
            get { return level; }
        }*/
    }
}