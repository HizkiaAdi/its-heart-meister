using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SDefenseGameLevel
{
    public class Level3 : SDefenseLevelBuilder
    {
        GameObject obstacle1, obstacle2;

        public Level3()
        {
            obstacle1 = Resources.Load("MiniGamePrefabs/SDobstacle1") as GameObject;
            obstacle1.transform.position = new Vector2(4.5f, 0f);
            
            obstacle2 = Resources.Load("MiniGamePrefabs/SDObstacle2") as GameObject;
            obstacle2.transform.position = new Vector2(0f, 2f);

            level = new SDefenseLevel();
        }

        public override void BuildObstacle()
        {
            level.Obstacle.Add(obstacle1);
            level.Obstacle.Add(obstacle2);
        }
    }
}