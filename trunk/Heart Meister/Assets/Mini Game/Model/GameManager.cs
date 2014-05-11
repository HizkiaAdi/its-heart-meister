using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public abstract class GameManager
    {
        int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        int timer;

        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public GameManager(int score)
        {
            this.Score = score;
        }

        public GameManager(int score,int timer)
            : this(score)
        {
            this.Timer = timer;
        }
    }
}