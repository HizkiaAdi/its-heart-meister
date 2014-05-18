using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AttackGameLevel
{
    public class Level2 : AttackLevelBuilder
    {
        GameObject obstacle;

        public Level2()
        {
            obstacle = Resources.Load("MiniGamePrefabs/Obstacle1") as GameObject;
            Debug.Log("AttackLevel2: " + obstacle.name);
            level = new AttackLevel();
        }

        public override void BuildObstacle()
        {
            obstacle.transform.position = new Vector2(0f, 2.0f);
            level.Obstacle.Add(obstacle);
        }
    }
}