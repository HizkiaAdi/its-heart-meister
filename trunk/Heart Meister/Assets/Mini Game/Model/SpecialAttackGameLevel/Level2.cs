using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAttackGameLevel
{
    public class Level2 : SAttackLevelBuilder
    {
        List<GameObject> obstacle;

        public Level2()
        {
            obstacle = new List<GameObject>();

            for (int i = 0; i < 5; i++)
                obstacle.Add(Resources.Load("MiniGamePrefabs/SAobstacle") as GameObject);

            level = new SAttackLevel();
        }

        public override void BuildObstacle()
        {
            foreach(GameObject i in obstacle)
            {
                level.Obstacle.Add(i);
            }
        }
    }
}