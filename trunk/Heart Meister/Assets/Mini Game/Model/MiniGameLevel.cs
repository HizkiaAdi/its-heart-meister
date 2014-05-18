using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public class MiniGameLevel
    {
        private MiniGameLevel() { }

        private static MiniGameLevel singleton;

        public static MiniGameLevel CreateMiniGameSingleton()
        {
            if(singleton == null)
            {
                singleton = new MiniGameLevel();
            }

            return singleton;
        }

        private int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
    }
}