using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class DefenseObstacle1 : MonoBehaviour
    {
        public GameObject magicBall;
        float speed = 0.05f;
        float nextShoot, shootDelay = 2;
        // Use this for initialization
        void Start()
        {
            nextShoot = 0;
        }

        // Update is called once per frame
        void Update()
        {
            nextShoot += Time.deltaTime;
            if (nextShoot > shootDelay)
            {
                Instantiate(magicBall, new Vector2(transform.position.x, transform.position.y - 1f), transform.rotation);
                nextShoot = 0;
            }
        }
    }
}