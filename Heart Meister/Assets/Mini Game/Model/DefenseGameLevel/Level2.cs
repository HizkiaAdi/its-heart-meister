using UnityEngine;
using System.Collections;

namespace DefenseGameLevel
{
    public class Level2 : DefenseLevelBuilder
    {
        GameObject obstacle;

        public Level2()
        {
            obstacle = Resources.Load("MiniGamePrefabs/DefenseObstacle1") as GameObject;
            level = new DefenseLevel();
        }

        public override void BuildObstacle()
        {
            obstacle.transform.position = new Vector2(0f, 4f);
            level.Obstacle.Add(obstacle);
        }
    }
}