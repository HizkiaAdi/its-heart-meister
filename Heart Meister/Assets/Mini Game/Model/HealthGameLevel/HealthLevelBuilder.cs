using UnityEngine;
using System.Collections;

namespace HealthGameLevel
{
    public abstract class HealthLevelBuilder
    {
        public virtual void BuildObstacle() { }

        public HealthLevel level;
    }
}