using UnityEngine;
using System.Collections;

namespace AttackGameLevel
{
    public class AttackLevelManufacturer
    {
        public void Construct(AttackLevelBuilder attackLevelBuilder)
        {
            attackLevelBuilder.BuildObstacle();
        }
    }
}