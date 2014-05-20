using UnityEngine;
using System.Collections;

namespace SDefenseGameLevel
{
    public class SDefenseLevelManufacturer
    {
        public void Construct(SDefenseLevelBuilder sDefenseLevelBuilder)
        {
            sDefenseLevelBuilder.BuildObstacle();
        }
    }
}