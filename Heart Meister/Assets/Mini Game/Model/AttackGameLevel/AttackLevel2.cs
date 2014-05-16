using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AttackGameLevel
{
    public class AttackLevel2 : AttackLevelBuilder
    {
        private AttackLevel level;

        public AttackLevel Level
        {
            get { return level; }
        }

        GameObject obstacle;

        public AttackLevel2()
        {
            obstacle = (GameObject)Resources.Load("/MiniGamePrefabs/Obstacle1");
            if(obstacle==null) Debug.Log("obstacle null");
            level = new AttackLevel();
        }

        public override void BuildObstacle()
        {
            obstacle.transform.position = new Vector2(2.0f, 2.0f);
            level.Obstacle.Add(obstacle);
        }
    }
}