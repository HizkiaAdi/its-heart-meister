using UnityEngine;
using System.Collections;

namespace AttackGameLevel
{
    public abstract class AttackLevelBuilder
    {
       public virtual void BuildObstacle() { }
       
       public AttackLevel level;

        public AttackLevel Level
        {
            get { return level; }
        }
    }
}