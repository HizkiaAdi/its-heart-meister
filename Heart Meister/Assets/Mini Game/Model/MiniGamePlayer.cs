using UnityEngine;
using System.Collections;

namespace MiniGameModel
{
    public abstract class MiniGamePlayer : MovingObject
    {
        int lifes;

        public int Lifes
        {
            get { return lifes; }
            set { lifes = value; }
        }

        float shootingRate;

        public float ShootingRate
        {
            get { return shootingRate; }
            set { shootingRate = value; }
        }

        public MiniGamePlayer(float speed, int lifes)
            : base(speed)
        {
            this.Lifes = lifes;
        }

        public MiniGamePlayer(float speed,int lifes,float shootingRate)
            : this(speed, lifes)
        {
            this.ShootingRate = shootingRate;
        }
    }
}