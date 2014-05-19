using UnityEngine;
using System.Collections;

namespace DefenseGameLevel
{
    public class DefenseLevelManufacturer
    {
        public void Construct(DefenseLevelBuilder defenseLevelBuilder)
        {
            defenseLevelBuilder.BuildObstacle();
        }
    }
}