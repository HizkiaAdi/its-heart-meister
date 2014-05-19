using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpeedGameLevel
{
    public class Level2 : SpeedLevelBuilder
    {
        GameObject otherObjectSpawner;

        public Level2()
        {
            otherObjectSpawner = Resources.Load("MiniGamePrefabs/OtherObjectSpawner") as GameObject;
            level = new SpeedLevel();
        }

        public override void CreateSpawner()
        {
            otherObjectSpawner.transform.position = new Vector2(8.5f, 0f);
            level.Spawner.Add(otherObjectSpawner);
        }
    }
}