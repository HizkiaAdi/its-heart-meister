using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class DefenseObstacle2 : MonoBehaviour
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
            transform.Translate(Vector2.right * speed);

            nextShoot += Time.deltaTime;
            if (nextShoot > shootDelay)
            {
                Instantiate(magicBall, new Vector2(transform.position.x, transform.position.y - 1f), transform.rotation);
                nextShoot = 0;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Boundary")
                speed *= -1;
        }
    }
}