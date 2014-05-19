using UnityEngine;
using System.Collections;

namespace SpeedGameLevel
{
    public class SpeedLevelManufacturer
    {
        public void Construct(SpeedLevelBuilder speedLevelBuilder)
        {
            speedLevelBuilder.CreateSpawner();
        }
    }
}