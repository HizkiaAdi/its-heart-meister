using UnityEngine;
using System.Collections;

namespace SAttackGameLevel
{
    public class SAttackLevelManufacturer
    {
        public void Construct(SAttackLevelBuilder sAttackLevelBuilder)
        {
            sAttackLevelBuilder.BuildObstacle();
        }
    }
}