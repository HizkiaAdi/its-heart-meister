using UnityEngine;
using System.Collections;

namespace SAttackGameLevel
{
    public abstract class SAttackLevelBuilder
    {
        public virtual void BuildObstacle() { }

        public SAttackLevel level;
    }
}