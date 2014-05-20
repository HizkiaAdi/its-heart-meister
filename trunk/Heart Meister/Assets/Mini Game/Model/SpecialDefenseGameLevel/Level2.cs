using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SDefenseGameLevel
{
    public class Level2 : SDefenseLevelBuilder
    {
        GameObject obstacle;

        public Level2()
        {
            obstacle = Resources.Load("MiniGamePrefabs/SDobstacle1") as GameObject;
            obstacle.transform.position = new Vector2(4.5f, 0f);
            
            level = new SDefenseLevel();
        }

        public override void BuildObstacle()
        {
            level.Obstacle.Add(obstacle);
        }
    }
}