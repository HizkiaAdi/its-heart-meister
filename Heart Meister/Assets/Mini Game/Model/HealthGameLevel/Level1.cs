using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HealthGameLevel
{
    public class Level1 : HealthLevelBuilder
    {
        GameObject groundSpawner;

        public Level1()
        {
            groundSpawner = Resources.Load("MiniGamePrefabs/GroundSpawner1") as GameObject;
            groundSpawner.transform.position = new Vector2(9f, 0f);

            level = new HealthLevel();
        }

        public override void BuildObstacle()
        {
            level.Obstacle.Add(groundSpawner);
        }
    }
}