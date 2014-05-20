using UnityEngine;
using System.Collections;

namespace SDefenseGameLevel
{
    public abstract class SDefenseLevelBuilder
    {
        public virtual void BuildObstacle() { }

        public SDefenseLevel level;
    }
}