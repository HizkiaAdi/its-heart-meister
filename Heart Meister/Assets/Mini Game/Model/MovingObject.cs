using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public abstract class MovingObject
    {
        float speed;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public MovingObject(float speed)
        {
            this.Speed = speed;
        }
    }
}