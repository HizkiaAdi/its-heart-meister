using UnityEngine;
using System.Collections;

namespace HealthGameLevel
{
    public class HealthlevelManufacturer
    {
        public void Construct(HealthLevelBuilder healthLevelBuilder)
        {
            healthLevelBuilder.BuildObstacle();
        }
    }
}