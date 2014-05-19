using UnityEngine;
using System.Collections;

namespace DefenseGameLevel
{
    public abstract class DefenseLevelBuilder
    {
        public virtual void BuildObstacle() { }

        public DefenseLevel level;

        public DefenseLevel Level
        {
            get { return level; }
        }
    }
}