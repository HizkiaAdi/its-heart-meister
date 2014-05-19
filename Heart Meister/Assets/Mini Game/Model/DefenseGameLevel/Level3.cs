using UnityEngine;
using System.Collections;

namespace DefenseGameLevel
{
    public class Level3 : DefenseLevelBuilder
    {
        GameObject obstacle;

        public Level3()
        {
            obstacle = Resources.Load("MiniGamePrefabs/DefenseObstacle2") as GameObject;
            level = new DefenseLevel();
        }

        public override void BuildObstacle()
        {
            obstacle.transform.position = new Vector2(0f, 4f);
            level.Obstacle.Add(obstacle);
        }
    }
}