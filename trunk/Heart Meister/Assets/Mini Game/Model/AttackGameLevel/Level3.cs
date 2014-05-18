using UnityEngine;
using System.Collections;

namespace AttackGameLevel
{
    public class Level3 : AttackLevelBuilder
    {
        GameObject obstacle2, blackHole;

        public Level3()
        {
            obstacle2 = Resources.Load("MiniGamePrefabs/Obstacle2") as GameObject;
            blackHole = Resources.Load("MiniGamePrefabs/BlackHole") as GameObject;
            level = new AttackLevel();
        }

        public override void BuildObstacle()
        {
            obstacle2.transform.position = new Vector2(Random.Range(-6.0f, 6.0f), 0.5f);
            level.Obstacle.Add(obstacle2);
            blackHole.transform.position = new Vector2(0f, 2.0f);
            level.Obstacle.Add(blackHole);
        }
    }
}