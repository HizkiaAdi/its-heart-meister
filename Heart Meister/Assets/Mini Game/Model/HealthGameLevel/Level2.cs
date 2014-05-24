﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HealthGameLevel
{
    public class Level2 : HealthLevelBuilder
    {
        GameObject groundSpawner, birdSpawner;

        public Level2()
        {
            groundSpawner = Resources.Load("MiniGamePrefabs/GroundSpawner1") as GameObject;
            groundSpawner.transform.position = new Vector2(9f, 0f);

            birdSpawner = Resources.Load("MiniGamePrefabs/BirdSpawner") as GameObject;
            birdSpawner.transform.position = new Vector2(10f, 0f);

            level = new HealthLevel();
        }

        public override void BuildObstacle()
        {
            level.Obstacle.Add(groundSpawner);
            level.Obstacle.Add(birdSpawner);
        }
    }
}