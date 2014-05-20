using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpeedGameLevel
{
    public class Level3 : SpeedLevelBuilder
    {
        GameObject enemySpawner, otherObjectSpawner;

        public Level3()
        {
            enemySpawner = Resources.Load("MiniGamePrefabs/EnemySpawner") as GameObject;
            otherObjectSpawner = Resources.Load("MiniGamePrefabs/OtherObjectSpawner") as GameObject;
            level = new SpeedLevel();
        }

        public override void CreateSpawner()
        {
            enemySpawner.transform.position = new Vector2(9f, 0f);
            level.Spawner.Add(enemySpawner);
            otherObjectSpawner.transform.position = new Vector2(8.5f, 0f);
            level.Spawner.Add(otherObjectSpawner);
        }
    }
}